using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using TesteGrupoGPS.Modelo;

namespace Negocio
{
    public class EmpresaNegocio
    {
        /// <summary>
        /// ///////////// INSERIR UMA NOVA EMPRESA NO BANCO 
        /// ///////////// RECEBE DA CONTROLLER E PASSA PARA DAO
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public Boolean InserirEmpresa(Empresa emp)
        {
            EmpresaDAO dao = new EmpresaDAO();

            return dao.InserirEmpresa(emp);
        }


        /// <summary>
        /// ///////////// CONSULTANDO TODAS EMPRESAS DO BANCO 
        /// ///////////// RECEBE REQUISIÇÃO DA CONTROLLER CONSULTA NA DAO E DEVOLVE A LISTA COM A CONSULTA
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        /// 
        public List<Empresa> ConsultarTodos()
        {
            List<Empresa> todos = new List<Empresa>();
            EmpresaDAO empDAO = new EmpresaDAO();

            todos = empDAO.ConsultarTodos();

            return todos;
        }

    }
}
