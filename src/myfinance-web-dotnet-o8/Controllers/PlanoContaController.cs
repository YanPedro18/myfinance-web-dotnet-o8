using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet_o8.Domain;
using myfinance_web_dotnet_o8.Models;
using myfinance_web_dotnet_o8.Services;

namespace myfinance_web_dotnet_o8.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaController(ILogger<PlanoContaController> logger, IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
            _logger = logger;
        }

        // Lista de planos
        public IActionResult Index()
        {
            ViewBag.Lista = _planoContaService.ListarRegistros();
            return View();
        }

        // GET: Cadastro (novo)
        [HttpGet]
        [Route("Cadastro")]
        public IActionResult Cadastro()
        {
            return View(new PlanoContaModel());
        }

        // GET: Cadastro com Id (editar)
        
        [HttpGet]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int id)
        {
            var registro = _planoContaService.RetornarRegistro(id);

            if (registro == null)
            {
                return NotFound();
            }

            var model = new PlanoContaModel
            {
                Id = registro.Id,
                Nome = registro.Nome,
                Tipo = registro.Tipo
            };

            return View(model);
        }

        // POST: Salvar (novo ou edição)
        [HttpPost]
        [Route("Cadastro")]
        public IActionResult Cadastro(PlanoContaModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var planoConta = new PlanoConta
            {
                Id = model.Id,
                Nome = model.Nome,
                Tipo = model.Tipo
            };

            _planoContaService.Salvar(planoConta);

     return RedirectToAction("Index", "PlanoConta");
        }

        // GET: Excluir
        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _planoContaService.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
