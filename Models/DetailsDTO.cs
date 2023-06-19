namespace Hits.Models;

public class DetailsDTO
{
    public Cantor Prior { get; set; }
    public Cantor Current { get; set; }
    public Cantor Next { get; set; }
    public List<Genero> Generos { get; set; }
}
