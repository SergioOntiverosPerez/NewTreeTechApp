using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewTreeTechApp.Models
{
    public class Alarme
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        [Display(Name = "Descrição do Alarme")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "Classificação do Alarme")]
        public ClassificacoAlarme Classificacao { get; set; }
        [Required]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        public Equipamento Equipamento { get; set; }
        [Required]
        [Display(Name = "Equipamento")]
        public int EquipamentoId { get; set; }
    }
}
