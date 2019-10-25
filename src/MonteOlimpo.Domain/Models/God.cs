using MonteOlimpo.Base.Core.DataAnnotations;
using MonteOlimpo.Base.Core.Domain.Model;

namespace MonteOlimpo.Domain.Models
{
    public class God : ModelBase
    {
        //[Required(ErrorKey ="NomeInvalido", ErrorMessage ="Nome não pode ser nulo!")]
        public string Nome { get; set; }
       
        public int Idade { get; set; }
    }
}