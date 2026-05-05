using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OcBank.Domain.Entities
{
    public class Transacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ContaId { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
    }
}
