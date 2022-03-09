using Asp_MVC_visuel.Models;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_AdopterUnDev.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_MVC_visuel.Controllers
{
    //PAS OUBLIER D'AJOUTER LES SERVICES DANS Startup
    public class PrototypeController : Controller
    {
        //PAS OUBLIER d'ajouter ici tous les models avec service

        private readonly IRepository<BLL.Models.Prototype> _service;
        //private readonly IRepository<BLL.Models.PrototypeAltro> _serviceAltro;
        public PrototypeController(IRepository<BLL.Models.Prototype> service) //, IRepository<BLL.Models.PrototypeAltro> serviceAltro
        {
            this._service = service;
            //this._serviceAltro = serviceAltro;

        }

        // GET: PrototipeController
        public ActionResult Index()
        {
            IEnumerable<PrototypeList> model = this._service.Get().Select(d => d.ToList());
            return View(model);
        }

        // GET: PrototipeController/Details/5
        public ActionResult Details(int id)
        {
            PrototypeDetails model = _service.Get(id).ToDetails();
            return View(model);
        }

        // GET: PrototipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrototipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrototipeController/Edit/5
        public ActionResult Edit(int id)
        {

            PrototypeEdit prototype = _service.Get(id).ToEdit();

            //non devo dimenticare che la mia app puo' essere interrogata anche da app esterne, quindi che non passano dalla pag d'Index con la lista dei prof.
            try
            {
                if (_service.Get(id) is null) throw new Exception("Pas de prototype avec cet identifiant");
                return View(prototype); //cosi' posso visualizzare i dati vecchi prima di modificarli
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: PrototipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrototipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrototipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
