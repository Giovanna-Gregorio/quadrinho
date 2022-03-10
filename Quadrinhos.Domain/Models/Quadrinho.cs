using System;
using System.Collections.Generic;

namespace Quadrinhos.Domain.Models
{
    public class Quadrinho : IModel<int>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Escritor { get; set; }
        public int QtdeEstoque { get; set; }

        public virtual IList<Venda> Vendas { get; set; }
    }
}
