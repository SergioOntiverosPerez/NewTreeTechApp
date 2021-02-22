using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewTreeTechApp.Data;
using NewTreeTechApp.Models;
using NewTreeTechApp.ViewModels;

namespace NewTreeTechApp.Controllers
{
    public class AlarmeController : Controller
    {
        public readonly NewTreeTechContext _context;

        public AlarmeController(NewTreeTechContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            var equipamentos = _context.Equipamentos.ToList();
            var alarmeModel = new AlarmeViewModel
            {
                Equipamentos = equipamentos
            };

            return View("AlarmeForm", alarmeModel);
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var alarme = _context.Alarmes.SingleOrDefault(a => a.Id == id);

            if (alarme == null)
                return NotFound();

            var alarmeViewModel = new AlarmeViewModel(alarme)
            {
                Equipamentos = _context.Equipamentos.ToList()
            };

            return View("AlarmeForm", alarmeViewModel);
        }


        [HttpPost]
        public IActionResult Save(Alarme alarme)
        {
            if (!ModelState.IsValid)
            {
                var alarmeModel = new AlarmeViewModel(alarme)
                {
                    Equipamentos = _context.Equipamentos.ToList()
                };

                return View("AlarmeForm", alarmeModel);
            }

            if (alarme.Id == 0)
                _context.Alarmes.Add(alarme);
            else
            {
                var alarmeInDb = _context.Alarmes.Single(a => a.Id == alarme.Id);
                alarmeInDb.Descricao = alarme.Descricao;
                alarmeInDb.Classificacao = alarme.Classificacao;
                alarmeInDb.DataDeCadastro = alarme.DataDeCadastro;
                alarmeInDb.EquipamentoId = alarme.EquipamentoId;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
            return RedirectToAction("List", "Alarme");
        }
    }
}
