using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_dotnet_o8.Domain;

namespace myfinance_web_dotnet_o8.Services
{
    public interface IPlanoContaService
    {
        List<PlanoConta> ListarRegistros();

        void Salvar(PlanoConta registro);


        void Excluir(int id);

        PlanoConta RetornarRegistro(int id);
    }
}