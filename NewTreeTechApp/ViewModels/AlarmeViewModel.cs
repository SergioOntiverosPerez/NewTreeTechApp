using NewTreeTechApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewTreeTechApp.ViewModels
{
    public class AlarmeViewModel
    {
        public IEnumerable<Equipamento> Equipamentos { get; set; }
        public int? Id { get; set; }
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
        [Required]
        [Display(Name = "Equipamento")]
        public int EquipamentoId { get; set; }

        public string Title
        {
            get
            {
                return (Id != 0) ? "Editar Alarme" : "Novo Alarme";
            }
        }

        public AlarmeViewModel()
        {
            Id = 0;
        }

        public AlarmeViewModel(Alarme alarme)
        {
            Id = alarme.Id;
            Descricao = alarme.Descricao;
            Classificacao = alarme.Classificacao;
            DataDeCadastro = alarme.DataDeCadastro;
            EquipamentoId = alarme.EquipamentoId;
        }
    }
}
