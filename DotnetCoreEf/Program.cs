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
            // Update using repository start
            IUow uow = new EfUow();
            IRepository<Customer> repository = null;
            IRepository<Address> repAddress = null;
            

            repository.SetUow(uow);
            repAddress.SetUow(uow);

            repository.Add(new Customer() { }); // add inmemory
            repository.Save();  // final commit

          
            repAddress.Add(new Address());
            repAddress.Save();


            uow.Commit();
            //uow.Rollback();

            // Update using repository end




            //Customer customer = new Customer();
            //customer.CustomerId = 1;
            //customer.CustomerCode = "C001";
            //customer.CustomerName = "Mrinal";
            //customer.Addresses.Add(new Address() {Id=1, Address1 = "delhi" });
            

            //CustomerEfContext context = new CustomerEfContext();
            //FLOWER : from > let > ORDER By > WHERE >  // way linq query is written

            // updating

            // here i get customer by linq
            //var cust = (from x in context.Customers
            //        where x.CustomerId == 1
            //        select x).ToList<Customer>()[0];
            //cust.CustomerName = "aaa";
            //context.SaveChanges();
            //context.Database.EnsureCreated(); // this line ensures the  database and table created automatically. 
            ////context.Database.ExecuteSqlCommand("select * from tblcustomer")  // execute raw sql
            //context.Add(customer); // Adds in inmemory
            //context.SaveChanges(); // physical commit

        }
    }

    public class Customer // Model // Object
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }

        [ConcurrencyCheck] // optimistic concurrency check . it will check while updating record if data has changed or not
        public string CustomerName { get; set; }

        // one to many relationship
        public List<Address> Addresses { get; set; }

        public Customer()
        {
            this.Addresses = new List<Address>();
        }
    }

    public class Address
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

    // Unit of work
    public interface IUow
    {
        void Commit();
        void Rollback();
    }


    // Generic Repository pattern
    public interface IRepository<T> where T: class
    {
        void Add(T anyModel);
        bool Update();
        List<T> Search();

        void Save(); // will do final commit

        void SetUow(IUow uow);
          
    }

    public class RepositoryOfCustomer : IRepository<Customer>
    {
        public void Add(Customer anyModel)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public List<Customer> Search()
        {
            throw new NotImplementedException();
        }

        public void SetUow(IUow uow)
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class CommonRepository<T> : IRepository<T> where T:class
    {
        List<T> inmemory = new List<T>();
        public virtual void Add(T anyModel)
        {
            inmemory.Add(anyModel); // common code for inmemory insertiion
        }

        public abstract void Save();

        public abstract List<T> Search();

        public abstract void SetUow(IUow uow);


        public abstract bool Update();

    }


    public class EfCommon<T> : CommonRepository<T> where T : class
    {

        DbSet<T> db = null;
        EfUow uow = null;
        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override List<T> Search()
        {
            throw new NotImplementedException();
        }

        public override void SetUow(IUow uow)
        {
            this.uow = (EfUow)uow;
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }
    }


    public class EfUow : DbContext, IUow
    {
        public EfUow()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MRINAL\SQLEXPRESS;Initial Catalog=EfCore;Integrated Security=True");
        }
        public void Commit()
        {
            this.SaveChanges();
        }

        public void Rollback()
        {
            this.Dispose();
        }
    }

}
