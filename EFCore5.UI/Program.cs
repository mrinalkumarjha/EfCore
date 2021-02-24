using System;


namespace EFCore5.UI
{
    class Program
    {
        private static EFCore5.Data.AppContext _context = new EFCore5.Data.AppContext();
        static void Main(string[] args)
        {
           bool b = _context.Database.EnsureCreated(); // ensure db is created in server.
            Console.WriteLine("Hello World!");
        }
    }
}
