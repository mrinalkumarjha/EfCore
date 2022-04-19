
namespace SamuraiApp.Domain;

internal class Quote
{
    public int Id { get; set; }
    public string Text { get; set; }
    public Samurai Samurai { get; set; }
    public int SamuraiId { get; set; } //foreign key value of samurai
}
