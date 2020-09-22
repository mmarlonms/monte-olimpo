using MonteOlimpo.Base.Core.Domain.Model;

namespace MonteOlimpo.Domain.Models
{
    public class God : ModelBase
    {
        public string Nome { get; set; }
       
        public int Idade { get; set; }
    }
}