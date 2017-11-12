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
    public class EmpresaController : Controller
    {
        private ModelColab db = new ModelColab();

        // GET: Empresa
        public ActionResult Index()
        {
            return View(db.Empresas.ToList());
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEMPRESA,STRNOME,STRCNPJ,DTCADASTRO,STRRAZAOSOCIAL")] Empresa empresa)
        {
            if (CNPJExistente(empresa.STRCNPJ))
            {
                ModelState.AddModelError("empresa.Existe", "CNPJ já cadastrado");
            }

            if (ModelState.IsValid)
            {
                empresa.STRCNPJ = empresa.STRCNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
                db.Empresas.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEMPRESA,STRNOME,STRCNPJ,DTCADASTRO,STRRAZAOSOCIAL")] Empresa empresa)
        {
            if (CNPJExistente(empresa.STRCNPJ, empresa.IDEMPRESA))
            {
                ModelState.AddModelError("empresa.Existe", "CNPJ já cadastrado");
            }

            if (ModelState.IsValid)
            {
                empresa.STRCNPJ = empresa.STRCNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresas.Find(id);
            db.Empresas.Remove(empresa);
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

        public Boolean CNPJExistente(String strCNPJ, int idEmpresa = 0)
        {
            Empresa empresa= db.Empresas.Where(e => e.STRCNPJ.Equals(strCNPJ.Replace(".", "").Replace("-", "").Replace("/","")) && e.IDEMPRESA != idEmpresa).FirstOrDefault();
            if (empresa != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
