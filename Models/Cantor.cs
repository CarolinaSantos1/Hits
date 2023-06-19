namespace Hits.Models;

public class Cantor
{
    public int Numero { get; set; }

    public string Nome { get; set; }

    public string NomeArtistico { get; set; }

    public string Nascimento { get; set; }

    public List<string> Genero { get; set; }

    public string Biografia { get; set; }

    public string Imagem { get; set; }

    public Cantor()
    {
        Genero = new List<string>();
    }
}
