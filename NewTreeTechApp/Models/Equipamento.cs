using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewTreeTechApp.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome do Equipamento")]
        public string NomeDoEquipamento { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Numero de Serie")]
        public string NumeroDeSerie { get; set; }
        [Required]
        [Display(Name = "Tipo de Equipamento")]
        public TipoEquipamento Tipo { get; set; }
        [Required]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }
    }
}
