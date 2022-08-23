using FunilMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunilMVC.Controllers
{
    public class CandidatoController : Controller
    {
        BDFunilEntities bd = new BDFunilEntities();
        // GET: Cursos
        public ActionResult Index()
        {
            ViewBag.qtdCandidato = bd.CANDIDATO.ToList().Count();
            ViewBag.NomeCandidato = bd.CANDIDATO.ToList();


            return View(bd.CANDIDATO.ToList());
        }



        public ActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Criar(string nome, string formacao)
        {
            CANDIDATO novocandidato = new CANDIDATO();

            novocandidato.CANNOME = nome;
            novocandidato.CANFORMACAO = formacao;
            
            CANDIDATO ultimoCandidato = bd.CANDIDATO.ToList().Last();
            int ultimoID = ultimoCandidato.CANID;
            novocandidato.CANID = ultimoID + 1;


            bd.CANDIDATO.Add(novocandidato);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }






        [HttpGet]
        public ActionResult Editar(int? id)
        {
            CANDIDATO Candatualizar = bd.CANDIDATO.ToList().Where(x => x.CANID == id).First();
            return View(Candatualizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string nome, string formacao)
        {
            CANDIDATO Candidatoatualizar = bd.CANDIDATO.ToList().Where(x => x.CANID == id).First();
            Candidatoatualizar.CANNOME = nome;
            Candidatoatualizar.CANFORMACAO = formacao;
          


            bd.Entry(Candidatoatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            CANDIDATO CandDeletar = bd.CANDIDATO.ToList().Where(x => x.CANID == id).First();
            return View(CandDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            CANDIDATO CandDeletar = bd.CANDIDATO.ToList().Where(x => x.CANID == id).First();
            bd.CANDIDATO.Remove(CandDeletar);
            try
            {
                bd.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Erro", "Home");
            }





            return RedirectToAction("Index");
        }
        public ActionResult Exibir(int? id)
        {

            CANDIDATO CandExibir = bd.CANDIDATO.ToList().Where(x => x.CANID == id).First();
            return View(CandExibir);
        }
    }
}