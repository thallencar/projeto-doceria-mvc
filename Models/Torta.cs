using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doceria.Models
{
    [Table("TB_TORTA")]
    public class Torta
    {
        [HiddenInput]
        [Key]
        public int TordaId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [Column("NM_TORTA"), MaxLength(50)]
        public string Nome { get; set; }

        [Column("DS_TORTA"), MaxLength(250)]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Column("VL_PRECO", TypeName = "decimal(18, 2)")]
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo preço é obrigatório.")]
        public decimal Preco { get; set; }

        [Column("DT_CADASTRO")]
        [Display(Name = "Data do Cadastro"), DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo data do cadastro é obrigatório.")]
        public DateTime Data { get; set; }

        [Column("NM_TIPO")]
        [Display(Name = "Tipo de Torta")]
        [Required(ErrorMessage = "O campo tipo de torta é obrigatório.")]

        public TipoTorta Tipo { get; set; }

        [Column("BL_VEGANA"), Required]
        [Display(Name = "Vegana")]
        public bool IsVegana { get; set; }
    }

    public enum TipoTorta
    {
        Especial, Tradicional, Sorvete, Vintage
    }
}