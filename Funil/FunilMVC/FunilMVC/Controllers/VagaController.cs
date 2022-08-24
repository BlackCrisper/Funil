using FunilMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunilMVC.Controllers
{
    public class VagaController : Controller
    {
        BDFunilEntities1 bd = new BDFunilEntities1();
        // GET: Cursos
        public ActionResult Index()
        {
            ViewBag.qtdVaga = bd.VAGA.ToList().Count();
            ViewBag.NomeVaga = bd.VAGA.ToList();


            return View(bd.VAGA.ToList());
        }


        public ActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Criar(string nome, string descricao, string atribuicao, decimal salario, string requisito, DateTime date)
        {
            VAGA novaVaga = new VAGA();

            novaVaga.VAINOME = nome;
            novaVaga.VAIDESCRICAO = descricao;
            novaVaga.VAIATRIBUICAO = atribuicao;
            novaVaga.VAISALARIO = Convert.ToInt32(salario);
            novaVaga.VAIREQUISITO = requisito;
            novaVaga.VAIDATACADASTRO = Convert.ToDateTime(date);


            VAGA ultimaVaga = bd.VAGA.ToList().Last();
            int ultimoID = ultimaVaga.VAIID;
            novaVaga.VAIID = ultimoID + 1;


            bd.VAGA.Add(novaVaga);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }






        [HttpGet]
        public ActionResult Editar(int? id)
        {
            VAGA Vagatualizar = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            return View(Vagatualizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string nome, string descricao, string atribuicao, string salario, string requisito, DateTime date)
        {
            VAGA Vagatoatualizar = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            Vagatoatualizar.VAINOME = nome;
            Vagatoatualizar.VAIDESCRICAO = descricao;
            Vagatoatualizar.VAIATRIBUICAO = atribuicao;
            Vagatoatualizar.VAISALARIO = Convert.ToDecimal(salario);
            Vagatoatualizar.VAIREQUISITO = requisito;
            Vagatoatualizar.VAIDATACADASTRO = Convert.ToDateTime(date);



            bd.Entry(Vagatoatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            VAGA VagaDeletar = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            return View(VagaDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            VAGA VagDeletar = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            bd.VAGA.Remove(VagDeletar);
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

            VAGA VagaExibir = bd.VAGA.ToList().Where(x => x.VAIID == id).First();
            return View(VagaExibir);
        }


        [HttpGet]
        public ActionResult CandidatoPorVaga(int? id)
        {
           
            return View(bd.GrupoCandidatoVaga.ToList().Where(x => x.CodigoV == id));

           
        }

       public ActionResult teste()
        {
            return View();
        }

    }
}