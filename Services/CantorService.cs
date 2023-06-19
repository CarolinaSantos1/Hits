using System.Text.Json;
using Hits.Models;

namespace Hits.Services;

public class CantorService : ICantorService
{
    private readonly IHttpContextAccessor _session;
    private readonly string cantorFile = @"Data\cantores.json";
    private readonly string generosFile = @"Data\generos.json";

    public CantorService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public List<Cantor> GetCantores()
    {
        PopularSessao();
        var cantores = JsonSerializer.Deserialize<List<Cantor>>
            (_session.HttpContext.Session.GetString("Cantores"));
        return cantores;
    }

    public List<Genero> GetGeneros()
    {
        PopularSessao();
        var generos = JsonSerializer.Deserialize<List<Genero>>
            (_session.HttpContext.Session.GetString("Generos"));
        return generos;
    }

    public Cantor GetCantor(int Numero)
    {
        var cantores = GetCantores();
        return cantores.Where(p => p.Numero == Numero).FirstOrDefault();
    }

    public HitsDTO GetHitsDTO()
    {
        var cantor = new HitsDTO()
        {
            Cantores = GetCantores(),
            Generos = GetGeneros()
        };
        return cantor;
    }

    public DetailsDTO GetDetailedCantor(int Numero)
    {
        var cantores = GetCantores();
        var cantor = new DetailsDTO()
        {
            Current = cantores.Where(p => p.Numero == Numero)
                .FirstOrDefault(),
            Prior = cantores.OrderByDescending(p => p.Numero)
                .FirstOrDefault(p => p.Numero < Numero),
            Next = cantores.OrderBy(p => p.Numero)
                .FirstOrDefault(p => p.Numero > Numero)
        };
        cantor.Generos = GetGeneros();
        return cantor;
    }

    public Genero GetGenero(string Nome)
    {
        var generos = GetGeneros();
        return generos.Where(t => t.Nome == Nome).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Generos")))
        {
            _session.HttpContext.Session
                .SetString("Cantores", LerArquivo(cantorFile));
            _session.HttpContext.Session
                .SetString("Generos", LerArquivo(generosFile));
            
        }
    }

    private string LerArquivo(string filename)
    {
        using (StreamReader leitor = new StreamReader(filename))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}
