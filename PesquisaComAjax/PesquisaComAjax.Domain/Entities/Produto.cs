using System;

namespace PesquisaComAjax.Domain.Entities
{
    public class Produto
    {
        public int      ProdutoId    { get; set; }
        public string   Nome         { get; set; }
        public int      Quantidade   { get; set; }
        public string   Descricao    { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal  Valor        { get; set; }
        public bool     Disponivel   { get; set; }

        public bool IsValid(Produto produto)
        {
            return produto.Quantidade > 0;
        }
    }
}
