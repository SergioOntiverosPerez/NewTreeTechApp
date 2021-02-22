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
    public class EquipamentosController : Controller
    {
        public readonly NewTreeTechContext _context;

        public EquipamentosController(NewTreeTechContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            var equipamentoModel = new EquipamentoViewModel();
            return View("EquipamentoForm", equipamentoModel);
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var equipamento = _context.Equipamentos.SingleOrDefault(e => e.Id == id);

            if (equipamento == null)
                return NotFound();

            var equipamentoViewModel = new EquipamentoViewModel(equipamento);

            return View("EquipamentoForm", equipamentoViewModel);
        }

        // POST: 
        [HttpPost]
        public IActionResult Save(Equipamento equipamento)
        {
            if (!ModelState.IsValid)
            {
                var equipamentoModel = new EquipamentoViewModel(equipamento);

                return View("EquipamentoForm", equipamentoModel);
            }

            if (equipamento.Id == 0)
                _context.Equipamentos.Add(equipamento);
            else
            {
                var equipamentoInDb = _context.Equipamentos.Single(p => p.Id == equipamento.Id);
                equipamentoInDb.NumeroDeSerie = equipamento.NumeroDeSerie;
                equipamentoInDb.NumeroDeSerie = equipamento.NumeroDeSerie;
                equipamentoInDb.Tipo = equipamento.Tipo;
                equipamentoInDb.DataDeCadastro = equipamento.DataDeCadastro;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }


            return RedirectToAction("List", "Equipamentos");
        }


    }
}
