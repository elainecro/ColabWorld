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
    public class PessoaController : Controller
    {
        private ModelColab db = new ModelColab();

        // GET: Pessoas
        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STRNOME,IDPESSOA,STRCPF,DTNASCIMENTO,DTCADASTRO")] Pessoa pessoa)
        {            
            if (CPFExistente(pessoa.STRCPF))
            {
                ModelState.AddModelError("pessoa.Existe", "CPF existente");
            }

            if (ModelState.IsValid)
            {
                pessoa.STRCPF = pessoa.STRCPF.Replace("-", "").Replace(".", "");
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STRNOME,IDPESSOA,STRCPF,DTNASCIMENTO,DTCADASTRO")] Pessoa pessoa)
        {
            if (CPFExistente(pessoa.STRCPF, pessoa.IDPESSOA))
            {
                ModelState.AddModelError("pessoa.Existe", "CPF existente");
            }

            if (ModelState.IsValid)
            {
                pessoa.STRCPF = pessoa.STRCPF.Replace("-", "").Replace(".", "");
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
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

        public Boolean CPFExistente (String strCPF, int idPessoa = 0)
        {
            Pessoa pessoa = db.Pessoas.Where(p => p.STRCPF.Equals(strCPF.Replace(".","").Replace("-","")) && p.IDPESSOA != idPessoa).FirstOrDefault();
            if (pessoa != null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
