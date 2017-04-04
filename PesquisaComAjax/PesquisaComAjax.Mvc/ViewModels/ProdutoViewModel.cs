using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PesquisaComAjax.Mvc.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo quantidade")]
        [Range(typeof(int),"0","9999")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Preencha o campo valor")]
        [Range(typeof(decimal), "0", "999999999")]
        public decimal Valor { get; set; }

        [DisplayName("Disponivel ?")]
        public bool Disponivel { get; set; }
    }
}