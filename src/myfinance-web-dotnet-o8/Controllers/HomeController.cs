using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet_o8.Infrastructure;
using myfinance_web_dotnet_o8.Models;

namespace myfinance_web_dotnet_o8.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyFinanceDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, MyFinanceDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var nomePrimeroPlanoConta = _dbContext.PlanoConta.FirstOrDefault()?.Nome;
        ViewBag.Teste = nomePrimeroPlanoConta ?? "Nenhum plano de conta encontrado";
        return View();
    }

    public IActionResult PUC()
    {
        return View();
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
