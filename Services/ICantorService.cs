using Hits.Models;

namespace Hits.Services;

public interface ICantorService
{
    List<Cantor> GetCantores();
    List<Genero> GetGeneros();
    Cantor GetCantor(int Numero);
    HitsDTO GetHitsDTO();
    DetailsDTO GetDetailedCantor(int Numero);
    Genero GetGenero(string Nome);
}
