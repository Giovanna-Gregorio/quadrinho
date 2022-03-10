using System;

namespace Quadrinhos.Domain.Models
{
    public class Venda : IModel<int>
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int QuadrinhoId { get; set; }
        public int Qtde { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;

        public virtual Usuario Usuario { get; set; }
        public virtual Quadrinho Quadrinho { get; set; }
    }
}
