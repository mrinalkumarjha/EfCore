// See https://aka.ms/new-console-template for more information
using SamuraiApp.Data;
using SamuraiApp.Domain;

 SamuraiContext _Context = new SamuraiContext();


_Context.Database.EnsureCreated();
AddSamurai();
GetSamurais();
Console.WriteLine("done!");
Console.ReadLine();



 void AddSamurai()
{
    var samurai = new Samurai { Name = "Mrinal" };
    _Context.Samurais.Add(samurai);
    _Context.SaveChanges();
}

void GetSamurais()
{
    var samurais = _Context.Samurais.ToList();
    Console.WriteLine($"Samurai count is {samurais.Count}");
    foreach (var samurai in samurais)
    {
        Console.WriteLine(samurai.Name);
    }
}
