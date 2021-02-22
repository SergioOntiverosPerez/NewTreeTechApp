using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewTreeTechApp.Data;
using NewTreeTechApp.Models;

namespace NewTreeTechApp.Controllers
{
    public class AlarmesAtuadosController : Controller
    {
        private readonly NewTreeTechContext _context;

        public static List<AlarmeAtuado> ListOfAlarmeAtuado = new List<AlarmeAtuado>();
        public AlarmesAtuadosController(NewTreeTechContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var alarmes = from a in _context.AlarmesAtuados.Include(al => al.Alarme.Equipamento).Where(al => al.StatusAlarme == (Models.StatusAlarme)1) select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                alarmes = alarmes.Where(a => a.Alarme.Descricao.Contains(searchString));
            }

            return View("AlarmesAtuados", await alarmes.ToListAsync());
        }


        public IActionResult VisualizarAlarmes()
        {
            var alarmesAtuados = _context.AlarmesAtuados.Include(al => al.Alarme.Equipamento).ToList();

            return View(alarmesAtuados);
        }

        public IActionResult AlarmesAtuados()
        {
            var alarmesAtuados = _context.AlarmesAtuados.Include(al => al.Alarme.Equipamento).Where(al => al.StatusAlarme == (Models.StatusAlarme)1).ToList();
            return View(alarmesAtuados);
        }

        public async Task<IActionResult> Ativar(int? id)
        {
            if (id == null)
                return NotFound();

            var alarmesAtuado = await _context.AlarmesAtuados.Include(al => al.Alarme.Equipamento).FirstOrDefaultAsync(al => al.Id == id);

            if (alarmesAtuado == null)
                return NotFound();

            alarmesAtuado.StatusAlarme = (Models.StatusAlarme)1;
            alarmesAtuado.DataDeEntrada = DateTime.Now;
            ListOfAlarmeAtuado.Add(alarmesAtuado);

            try
            {
               await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return RedirectToAction("VisualizarAlarmes");
        }

        public async Task<IActionResult> Desativar(int? id)
        {
            if (id == null)
                return NotFound();

            var alarmesAtuado = await _context.AlarmesAtuados.Include(al => al.Alarme.Equipamento).FirstOrDefaultAsync(al => al.Id == id);

            if (alarmesAtuado == null)
                return NotFound();

            alarmesAtuado.StatusAlarme = (Models.StatusAlarme)0;
            alarmesAtuado.DataDeSaida = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return RedirectToAction("VisualizarAlarmes");
        }
    }
}
