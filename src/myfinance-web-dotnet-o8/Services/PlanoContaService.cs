using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_dotnet_o8.Domain;
using myfinance_web_dotnet_o8.Infrastructure;

namespace myfinance_web_dotnet_o8.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        
        private readonly MyFinanceDbContext _dbContext;

        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PlanoConta> ListarRegistros()
        {
            return _dbContext.PlanoConta.ToList();
        }

        public void Salvar(PlanoConta registro)
        {
    using (var contexto = new MyFinanceDbContext())
    {
        if (registro.Id == null || registro.Id == 0)
        {
            // Novo registro
            contexto.PlanoConta.Add(registro);
        }
        else
        {
            // Registro existente
            contexto.PlanoConta.Update(registro);
        }

        contexto.SaveChanges();
    }
        }

        public void Excluir(int id)
        {
            var registro = RetornarRegistro(id);
            if (registro != null)
            {
                _dbContext.PlanoConta.Remove(registro);
                _dbContext.SaveChanges();
            }
        }

        public PlanoConta RetornarRegistro(int id)
        {
            var registro = _dbContext.PlanoConta.Find(id);
            if (registro == null)
            {
                throw new InvalidOperationException($"PlanoConta with id {id} not found.");
            }
            return registro;
        }

    }

  
}