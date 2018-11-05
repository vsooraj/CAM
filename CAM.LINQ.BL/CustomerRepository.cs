using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAM.LINQ.BL
{
    public class CustomerRepository
    {
        private List<Customer> customerList;

        public Customer Find(List<Customer> customerList, int customerId) {

            Customer customer=null;
            //foreach (var item in customerList)
            //{
            //    if (item.CustomerId == customerId) {
            //        customer = item;
            //        break;
            //    }
            //}
            //var query = from c in customerList
            //            where c.CustomerId == customerId
            //            select c;
            //customer = query.First();
            //customer = customerList.FirstOrDefault(c =>
            //                    c.CustomerId == customerId);
            //foundCustomer = customerList.FirstOrDefault(c =>
            //                {
            //                    Debug.WriteLine(c.LastName);
            //                    return c.CustomerId == customerId;
            //                });

            customer = customerList.Where(c =>
                                c.CustomerId == customerId)
                                .Skip(1)
                                .FirstOrDefault();

            //foundCustomer = customerList.Where(c =>
            //                    c.CustomerId == customerId)
            //                    .Skip(1)
            //                    .FirstOrDefault();

            return customer;
        }
        public List<Customer> Retrieve()
        {
            customerList = new List<Customer>()
            {
                new Customer{
                     CustomerId=1,
                    FirstName ="Sooraj",
                    LastName ="Vidyasagar",
                    CustomerTypeId =1,
                    EmailAddress ="Sooraj.v@cabotsolutions.com"
                },
                new Customer{
                     CustomerId=2,
                    FirstName ="Rebin",
                    LastName ="Kuruvila",
                    CustomerTypeId =1,
                    EmailAddress ="Rebin.Kuruvila@cabotsolutions.com"
                },
                new Customer{
                     CustomerId=3,
                    FirstName ="Krishna",
                    LastName ="priya",
                    CustomerTypeId =1,
                    EmailAddress ="Krishna.priya@cabotsolutions.com"
                },
                new Customer{
                     CustomerId=4,
                    FirstName ="Hari",
                    LastName ="Prasad",
                    CustomerTypeId =1,
                    EmailAddress ="Hari.Prasad@cabotsolutions.com"
                },
                new Customer{
                     CustomerId=5,
                    FirstName ="Amitha",
                    LastName ="Joy",
                    CustomerTypeId =1,
                    EmailAddress ="Amitha.Joy@cabotsolutions.com"
                },
                new Customer{
                     CustomerId=6,
                    FirstName ="Minnu",
                    LastName ="Shaji",
                    CustomerTypeId =1,
                    EmailAddress ="Minnu.Shaji@cabotsolutions.com"
                },
                new Customer{
                    CustomerId=7,
                    FirstName ="Daniya",
                    LastName ="Jose",
                    CustomerTypeId =1,
                    EmailAddress ="Daniya.Jose@cabotsolutions.com"
                },
                new Customer{
                     CustomerId=8,
                    FirstName ="Arnold",
                    LastName ="Jonson",
                    CustomerTypeId =1,
                    EmailAddress ="Arnold.Jonson@cabotsolutions.com"
                },
                new Customer{
                     CustomerId=9,
                    FirstName ="Nived",
                    LastName ="Chandran",
                    CustomerTypeId =1,
                    EmailAddress ="Nived.Chandran@cabotsolutions.com"
                },

            };

            return customerList;
        }
        public IEnumerable<Customer> SortByName(List<Customer> customerList)
        {
            return customerList.OrderBy(c => c.LastName)
                            .ThenBy(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameInReverse(List<Customer> customerList)
        {
            //return customerList.OrderByDescending(c => c.LastName)
            //                    .ThenByDescending(c => c.FirstName);

            return SortByName(customerList).Reverse();
        }

    }
}
