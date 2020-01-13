using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DotnetCoreEf
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.CustomerId = 1;
            customer.CustomerCode = "C001";
            customer.CustomerName = "Mrinal";
            customer.Addresses.Add(new Address() {Id=1, Address1 = "delhi" });
            

            CustomerEfContext context = new CustomerEfContext();
            //FLOWER : from > let > ORDER By > WHERE >  // way linq query is written

            // updating

            // here i get customer by linq
            var cust = (from x in context.Customers
                    where x.CustomerId == 1
                    select x).ToList<Customer>()[0];
            cust.CustomerName = "Karan";
            context.SaveChanges();
            //context.Database.EnsureCreated(); // this line ensures the  database and table created automatically. 
            ////context.Database.ExecuteSqlCommand("select * from tblcustomer")  // execute raw sql
            //context.Add(customer); // Adds in inmemory
            //context.SaveChanges(); // physical commit

        }
    }

    class Customer // Model // Object
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }

        // one to many relationship
        public List<Address> Addresses { get; set; }

        public Customer()
        {
            this.Addresses = new List<Address>();
        }
    }

    class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Address1 { get; set; }
    }
    class CustomerEfContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// All mapping code is created in side on model creating
        /// Model builder is fluent api. extension method is best way to write fluent apis.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // mapping code
            modelBuilder.Entity<Customer>()
                .ToTable("tblCustomer");


        }

        /// <summary>
        /// used to configure database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MRINAL\SQLEXPRESS;Initial Catalog=EfCore;Integrated Security=True");
        }
    }
}
