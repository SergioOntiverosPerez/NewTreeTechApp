using NewTreeTechApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewTreeTechApp.ViewModels
{
    public class EquipamentoViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Entre o nome do equipamento")]
        [StringLength(255)]
        [Display(Name = "Nome do Equipamento")]
        public string NomeDoEquipamento { get; set; }
        [Required(ErrorMessage = "Entre o numero de serie")]
        [StringLength(255)]
        [Display(Name = "Numero de Serie")]
        public string NumeroDeSerie { get; set; }
        [Required(ErrorMessage = "Selecione o tipo de equipamento")]
        [Display(Name = "Tipo de Equipamento")]
        public TipoEquipamento Tipo { get; set; }
        [Required(ErrorMessage = "Entre a data de cadastro")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        public string Title
        {
            get
            {
                return (Id != 0) ? "Editar Equipamento" : "Novo Equipamento";
            }
        }

        public EquipamentoViewModel()
        {
            Id = 0;
        }

        public EquipamentoViewModel(Equipamento equipamento)
        {
            Id = equipamento.Id;
            NomeDoEquipamento = equipamento.NomeDoEquipamento;
            NumeroDeSerie = equipamento.NumeroDeSerie;
            Tipo = equipamento.Tipo;
            DataDeCadastro = equipamento.DataDeCadastro;

        }
    }
}
