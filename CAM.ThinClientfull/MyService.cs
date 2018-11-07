using CAM.Entities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
namespace CAM.ThinClient
{
    public class MyService
    {
        HttpClient client = new HttpClient();
        public void Start()
        {
            // write code here that runs when the Windows Service starts up.  
            Timer myTimer = new Timer(OnTimerEvent, null, 0, 5000);
            // WindowsServiceSchedler(_myTimer);

        }
        private void OnTimerEvent(object state)
        {
            InstalledApps();
        }
        public void Stop()
        {
            // write code here that runs when the Windows Service stops.  
        }
        private void InstalledApps()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            int index = 1;
            foreach (ManagementObject mo in mos.Get())
            {
                Console.WriteLine(" " + index + " Software  " + mo["Name"]);
                index++;
                Create(new Software { Id = index, Name = (string)mo["Name"], InstalledDate = DateTime.Now.ToShortDateString() });
            }
        }
        private Software Create(Software model)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51855");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.PostAsJsonAsync("/api/Softwares", model).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                Software data = JsonConvert.DeserializeObject<Software>(stringData);
                return data;
            }

        }
        private string getSystemInfo()
        {

            String strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            //Console.WriteLine("Local Machine's Host Name: " + strHostName);
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[0].ToString();
        }
        private static void WindowsServiceSchedler(System.Timers.Timer _timer)
        {
            string _runweekly = Convert.ToString(ConfigurationManager.AppSettings["Weekly"]);
            string _weeklyeventTriggerTime = Convert.ToString(ConfigurationManager.AppSettings["WeeklyeventTriggerTime"]);
            string _dayOfWeek = Convert.ToString(ConfigurationManager.AppSettings["DayOfWeek"]);
            DayOfWeek MyDays = (DayOfWeek)DayOfWeek.Parse(typeof(DayOfWeek), _dayOfWeek);
            string _DailyEventTriggerTime = Convert.ToString(ConfigurationManager.AppSettings["DailyEventTriggerTime"]);
            Scheduler sch = new Scheduler("WindowsService");
            if (_runweekly == "true")
            {

                sch.ScheduleWeekly(MyDays, _weeklyeventTriggerTime, _timer);
            }
            else
            {
                sch.ScheduleDaily(_DailyEventTriggerTime, _timer);
            }
        }
    }

    /// <summary>
    /// Makes it easy to schedule windows services
    /// </summary>
    public class Scheduler
    {
        #region Fields
        /// <summary>
        /// This event is fired whenever the scheduling criteria is met.
        /// Run your code in the handler.
        /// </summary>     

        private ScheduleInterval _interval;
        private string _timeString;
        private DayOfWeek _dayOfWeek;
        private int _dayOfMonth;
        #endregion

        #region Constructors
        /// <summary>
        /// Makes it easy to schedule windows services
        /// </summary>
        /// <param name="serviceName">Name of the service. Without white spaces</param>
        public Scheduler(string serviceName)
        {
            //_timer = new System.Timers.Timer();
            //_timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);

        }
        #endregion

        private double GetNextInterval()
        {

            int hours = Convert.ToInt32(_timeString);
            DateTime t = DateTime.Now.Date.Add(TimeSpan.FromHours(hours));
            //
            TimeSpan ts = new TimeSpan();
            int x;

            switch (_interval)
            {
                case ScheduleInterval.EveryDay:

                    ts = t - System.DateTime.Now;
                    if (ts.TotalMilliseconds < 0)
                    {
                        ts = t.AddDays(1) - System.DateTime.Now;
                    }
                    break;

                case ScheduleInterval.EveryMonth:
                    int daysInMonth = System.DateTime.DaysInMonth(System.DateTime.Now.Year, System.DateTime.Now.Month);
                    if (System.DateTime.Now.Day > _dayOfMonth)
                    {
                        t = t.AddDays((daysInMonth - System.DateTime.Now.Day) + _dayOfMonth);
                    }
                    else if (_dayOfMonth == System.DateTime.Now.Day)
                    {
                        if (t < System.DateTime.Now)
                        {
                            t = t.AddDays(daysInMonth);
                        }
                    }
                    else
                    {
                        x = _dayOfMonth - System.DateTime.Now.Day;
                        t = t.AddDays(x);
                    }

                    ts = (TimeSpan)(t - System.DateTime.Now);
                    break;
                case ScheduleInterval.Every4Week:
                    t = t.AddDays(28);
                    ts = (TimeSpan)(t - System.DateTime.Now);

                    break;

                case ScheduleInterval.EveryWeek:
                    if (System.DateTime.Now.DayOfWeek > this._dayOfWeek)
                    {
                        x = System.DateTime.Now.DayOfWeek - this._dayOfWeek;
                        t = t.AddDays(7 - x);

                    }
                    else if (System.DateTime.Now.DayOfWeek == this._dayOfWeek)
                    {
                        if (t < System.DateTime.Now)
                        {
                            t = t.AddDays(7);
                        }
                    }
                    else
                    {
                        x = this._dayOfWeek - System.DateTime.Now.DayOfWeek;
                        t = t.AddDays(x);
                    }

                    ts = (TimeSpan)(t - System.DateTime.Now);
                    break;
            }

            return ts.TotalMilliseconds;
        }
        private void SetTimer(System.Timers.Timer _timer)
        {
            double inter = (double)GetNextInterval();

            _timer.Interval = inter;
            _timer.Start();
        }
        /// <summary>
        /// Schedules the service to run at a specified time, daily.
        /// </summary>
        /// <param name="time">Takes the format HH:MM:SS AM/PM. Ex: 9:30 AM</param>
        public void ScheduleDaily(string time, System.Timers.Timer _timer)
        {
            this._interval = ScheduleInterval.EveryDay;
            this._timeString = time;
            Validate();

            SetTimer(_timer);
        }
        /// <summary>
        /// Schedules the service to run on a specified day of the week, at a specified time
        /// </summary>
        /// <param name="dayOfWeek">System.DayOfWeek enumeration</param>
        /// <param name="time">Takes the format HH:MM:SS AM/PM. Ex: 9:30 AM</param>
        public void ScheduleWeekly(DayOfWeek dayOfWeek, string time, System.Timers.Timer _timer)
        {
            this._interval = ScheduleInterval.EveryWeek;
            this._dayOfWeek = dayOfWeek;
            this._timeString = time;
            Validate();

            SetTimer(_timer);
        }
        /// <summary>
        /// Schedules the service to run once a month on a specified day and specified time.
        /// </summary>
        /// <param name="dayOfMonth">Integer value between 1 and 31. Automatically adjusts for 30/28/29 days months</param>
        /// <param name="time">Takes the format HH:MM:SS AM/PM. Ex: 9:30 AM</param>
        public void ScheduleMonthly(int dayOfMonth, string time, System.Timers.Timer _timer)
        {
            int daysInMonth = DateTime.DaysInMonth(System.DateTime.Now.Year, System.DateTime.Now.Month);
            if (_dayOfMonth > daysInMonth)
            { _dayOfMonth = daysInMonth; }

            this._interval = ScheduleInterval.EveryMonth;
            this._dayOfMonth = dayOfMonth;
            this._timeString = time;
            Validate();

            SetTimer(_timer);
        }
        public void Schedule4Weekly(string time, System.Timers.Timer _timer)
        {
            this._interval = ScheduleInterval.Every4Week;
            this._timeString = time;
            Validate();

            SetTimer(_timer);
        }
        private void Validate()
        {
            if (this._timeString == null || this._timeString.Trim() == "")
            {
                throw new ApplicationException("Time to fire cannot be null");
            }

        }
    }

    public enum ScheduleInterval
    {
        EveryDay,
        EveryWeek,
        EveryMonth,
        Every4Week
    }
}
