using CAM.Data.Repository;
using System;

namespace CAM.Win.Services
{
    public class ExceptionService
    {
        private DBLogRepository _iDBLogRepository;

        public ExceptionService(IDBLogRepository iDBLogRepository)
        {
            _iDBLogRepository = new DBLogRepository();
        }
        public void Log(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        public void FileLog(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        public void DBLog(Exception exception)
        {
            _iDBLogRepository.Create(exception.Message);
        }
    }
}
