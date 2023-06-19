using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hits.Models;
using Hits.Services;

namespace Hits.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICantorService _cantorService;

    public HomeController(ILogger<HomeController> logger, ICantorService cantorService)
    {
        _logger = logger;
        _cantorService = cantorService;
    }

    public IActionResult Index(string genero)
    {
        var cantor = _cantorService.GetHitsDTO();
        ViewData["filter"] = string.IsNullOrEmpty(genero) ? "all" : genero;
        return View(cantor);
    }

    public IActionResult Details(int Numero)
    {
        var cantores = _cantorService.GetDetailedCantor(Numero);
        cantores.Generos = _cantorService.GetGeneros();
        return View(cantores);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
