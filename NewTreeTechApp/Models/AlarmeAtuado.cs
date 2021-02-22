using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewTreeTechApp.Models
{
    public class AlarmeAtuado
    {
        public int Id { get; set; }
        [Display(Name = "Data de Entrada")]
        public DateTime DataDeEntrada { get; set; }
        [Display(Name = "Data de Saida")]
        public DateTime DataDeSaida { get; set; }
        [Display(Name = "Status do Alarme")]
        public StatusAlarme StatusAlarme { get; set; }
        public Alarme Alarme { get; set; }
        [Display(Name = "Alarme")]
        public int AlarmeId { get; set; }
    }
}
