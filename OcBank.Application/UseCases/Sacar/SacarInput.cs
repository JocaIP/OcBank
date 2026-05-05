using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcBank.Application.UseCases.Sacar
{
    public class SacarInput
    {
        public Guid ContaId { get; set; }
        public decimal Valor { get; set; }
    }
}
