using System.Collections.Generic;

namespace Quadrinhos.Domain.Models
{
    public class Usuario : IModel<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

        public virtual IList<Venda> Vendas { get; set; }
    }
}
