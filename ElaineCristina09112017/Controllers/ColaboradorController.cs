using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElaineCristina09112017;

namespace ElaineCristina09112017.Controllers
{
    public class ColaboradorController : Controller
    {
        private ModelColab db = new ModelColab();

        // GET: Colaborador
        public ActionResult Index()
        {
            var colaboradores = db.Colaboradores.Include(c => c.EMPRESA).Include(c => c.PESSOA);
            return View(colaboradores.ToList());
        }

        // GET: Colaborador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.Colaboradores.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // GET: Colaborador/Create
        public ActionResult Create()
        {
            ViewBag.IDEMPRESA = new SelectList(db.Empresas, "IDEMPRESA", "STRNOME");
            ViewBag.IDPESSOA = new SelectList(db.Pessoas, "IDPESSOA", "STRNOME");
            return View();
        }

        // POST: Colaborador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCOLAB,IDPESSOA,IDEMPRESA,VLRSALARIO,BSTATUS,DTCADASTRO,DTDEMISSAO,STRCARGO")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                db.Colaboradores.Add(colaborador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEMPRESA = new SelectList(db.Empresas, "IDEMPRESA", "STRNOME", colaborador.IDEMPRESA);
            ViewBag.IDPESSOA = new SelectList(db.Pessoas, "IDPESSOA", "STRNOME", colaborador.IDPESSOA);
            return View(colaborador);
        }

        // GET: Colaborador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.Colaboradores.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEMPRESA = new SelectList(db.Empresas, "IDEMPRESA", "STRNOME", colaborador.IDEMPRESA);
            ViewBag.IDPESSOA = new SelectList(db.Pessoas, "IDPESSOA", "STRNOME", colaborador.IDPESSOA);
            return View(colaborador);
        }

        // POST: Colaborador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCOLAB,IDPESSOA,IDEMPRESA,VLRSALARIO,BSTATUS,DTCADASTRO,DTDEMISSAO,STRCARGO")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaborador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEMPRESA = new SelectList(db.Empresas, "IDEMPRESA", "STRNOME", colaborador.IDEMPRESA);
            ViewBag.IDPESSOA = new SelectList(db.Pessoas, "IDPESSOA", "STRNOME", colaborador.IDPESSOA);
            return View(colaborador);
        }

        // GET: Colaborador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.Colaboradores.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaborador colaborador = db.Colaboradores.Find(id);
            db.Colaboradores.Remove(colaborador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
