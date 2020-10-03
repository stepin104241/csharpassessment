using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Customer
    {
        public Customer(int customerid, string name, string address, int phone)
        {
            Customerid = customerid;
            Name = name;
            Address = address;
            Phone = phone;
        }

        public int Customerid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Phone { get; set; }
    }
    interface ICustomerManager
    {
        bool AddCustomer(Customer cs);
        bool DeleteCustomer(int customerid);
        bool UpdateCustomer(int id);
        bool ViewAllCustomers();
    }
    class 
        CustomerManager : ICustomerManager
    {
        HashSet<Customer> customers = new HashSet<Customer>();
        public bool AddCustomer(Customer cs)
        {
            return customers.Add(cs);
        }

        public bool DeleteCustomer(int id)
        {
            foreach (Customer cs in customers)
            {
                if (cs.Customerid == id)
                {
                    customers.Remove(cs);
                    return true;
                }
            }
            return false;
        }

        

        public bool UpdateCustomer(int id)
        {
            foreach (Customer cs in customers)
            {
                if (cs.Customerid == id)
                {
                    Console.Write("Enter the New Title: ");
                    string newname = Console.ReadLine();
                    Console.Write("Enter the New Author: ");
                    string newaddress = Console.ReadLine();
                    Console.Write("Enter the New Price: ");
                    double newphone = double.Parse(Console.ReadLine());
                    cs.Name = newname;
                    cs.Address = newaddress;
                    cs.Phone = newphone;
                    return true;
                }
            }
            return false;
        }
        public bool ViewAllCustomers()
        {
            foreach (var cs in customers)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Customer ID: {cs.Customerid}");
                Console.WriteLine($"Name: {cs.Name}");
                Console.WriteLine($"Address: {cs.Address}");
                Console.WriteLine($"Phone: {cs.Phone}");
                Console.WriteLine("-------------------------------");
            }
            return true;
        }
    }

    class CollectionCustomerManager
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the details of 1st customer");
            Customer c1 = Console.ReadLine();
            Console.WriteLine("enter the details of 2nd customer");
            Customer c2 = Console.ReadLine();
            Console.WriteLine("enter the  details of 3rd customer");
            Customer c3 = Console.ReadLine();
           
            CustomerManager cus = new CustomerManager();
            cus.AddCustomer(c1);
            cus.AddCustomer(c2);
            cus.AddCustomer(c3);
            cus.ViewAllCustomers();
            cus.UpdateCustomer(100);
            cus.ViewAllCustomers();
         
        }       
    }
}
