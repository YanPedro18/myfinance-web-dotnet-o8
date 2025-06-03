
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_dotnet_o8.Domain
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Historico { get; set; }

        public decimal Amount { get; set; }

        public DateTime Data { get; set; }

        public double Valor { get; set; }

        public int PlanoContaId { get; set; } // Foreign key to PlanoConta

        public PlanoConta? PlanoConta { get; set; } // Navigation property to PlanoConta
    }
}