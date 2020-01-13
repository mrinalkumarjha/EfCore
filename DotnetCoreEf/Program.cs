using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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

            CustomerEfContext context = new CustomerEfContext();
            context.Database.EnsureCreated(); // this line ensures the  database and table created automatically. 
            context.Add(customer); // Adds in inmemory
            context.SaveChanges(); // physical commit

        }
    }

    class Customer // Model // Object
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
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
