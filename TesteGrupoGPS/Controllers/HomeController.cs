using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using TesteGrupoGPS.Modelo;
using TesteGrupoGPS.Models;
using TesteGrupoGPS.Util;

namespace TesteGrupoGPS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        

        public  ActionResult BuscarJson(String txtCNPJ)
        {

            BuscarURL buscar = new BuscarURL();                     // INSTANCIADO OBJ DE BUSCAURL
            List<Empresa> emp = new List<Empresa>();                // INSTANCIANDO LISTA DE EMPRESA PARA RECEBER O RESULTADO

            emp = buscar.BuscarEmpresa(txtCNPJ);                    // OBJ EPM RECEBENDO A CONCULTA - PASSANDO A URL COMO PARAMETRO

            return View("Importados", emp);                         // CHAMANDO A VIEW IMPORTADOS PASSANDO A LISTA DE OBJs
        }


        /// <summary>
        /// ////////// METODO PARA GRAVAR A EMPRESA NO BD
        /// </summary>
        /// <param name="txtCnpjGravar"></param>
        /// <returns></returns>
        [HttpPost]
        public Boolean GravarEmpresa(String txtCnpjGravar)          
        {
            EmpresaNegocio empNeg = new EmpresaNegocio();               // INSTANCIANDO OBJ DE EMPRESA NEGOCIO
            BuscarURL buscar = new BuscarURL();                         // INSTANCIADO OBJ DE BUSCAURL
            List<Empresa> Todos = new List<Empresa>();                  // INSTANCIANDO LISTA DE EMPRESA PARA RECEBER O RESULTADO
            Empresa emp = new Empresa();                                // INSTANCIANDO OBJ DE EMPRESA 

            Todos = buscar.BuscarEmpresa(txtCnpjGravar);                // OBJ EPM RECEBENDO A CONCULTA - PASSANDO A URL COMO PARAMETRO

            emp = Todos[0];                                             // PEGANDO APENAS O 1 RESULTADO JÁ QUE ESTAMOS PASSANDO APENAS 1 CNPJ
            return empNeg.InserirEmpresa(emp);                          // RETORNANDO RESULTADO TRUE OU FALSE

        }


        public ActionResult listarTodos()
        {
            EmpresaNegocio empNeg = new EmpresaNegocio();               // INSTANCIANDO OBJ DE EMPRESA NEGOCIO

            List<Empresa> todos = new List<Empresa>();                  // INSTANCIANDO LISTA DE EMPRESA PARA RECEBER O RESULTADO

            todos = empNeg.ConsultarTodos();                            // RECENDO A LISTA DE EMPRESAS CONSULTADAS

            return View("Listar", todos);                               // CHAMANDO VIEW QUE IRÁ EXIBIR, PASSANDO A LISTA DE OBJs
        }

    }
}
