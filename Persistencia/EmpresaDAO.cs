using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Persistencia.ConexaoDB;
using TesteGrupoGPS.Modelo;

namespace Persistencia
{
    public class EmpresaDAO
    {
        /// <summary>
        /// ////////   INSERE UMA NOVA EMPRESA NO BANCO DE DADOS
        /// /////// **** ATENÇÃO **** ESTA GRAVANDO APENAS 4 CAMPOS PARA FACILITAR NA PROGRAMAÇÃO
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public Boolean InserirEmpresa(Empresa emp)
        {

            MySqlConnection conn = null;                                    // INSTANCIA DA CONEXAO COM O BANCO
            MySqlCommand comand = null;                                     // INSTANCIA DA OBJ COMMAND, QUE EXECUTA O COMANDO NO BD
            String sql = "insert into empresa(cnpj,nome,telefone,email)"+   // STRING A SER EXECUTADA NO BD
                "values(@cnpj,@nome,@telefone,@email)";
                                                                            // TRATAMENTO DE ERRO COM TRY - CATCH
            try
            {
                conn = new Conexao().Abrir();                               // ABRINDO CONEXAO COM O BD

                if(conn != null)
                {
                    comand = new MySqlCommand(sql, conn);                   // CONCLUINDO A INSTANCIA DO COMAND
                    comand.Parameters.AddWithValue("@cnpj",emp.Cnpj);       // PASSANDO PARAMENTRO
                    comand.Parameters.AddWithValue("@nome",emp.Nome);       // PASSANDO PARAMENTRO
                    comand.Parameters.AddWithValue("@telefone",emp.Telefone);// PASSANDO PARAMENTRO
                    comand.Parameters.AddWithValue("@email",emp.Email);     // PASSANDO PARAMENTRO
                    comand.ExecuteNonQuery();                               // EXECUTA NO BD
                    return true;                                            // RETORNA VERDADEIRO
                }
            }
            catch (Exception ex)                                            // TRATAMENTO DE ERRO
            {

            }
            conn.Close();                                                   // FECHA CONEXAO
            return false;                                                   // RETORNA FALSE CASO ACONTEÇA ERRO
        }       



        /// <summary>
        /// /////////// CONSULTA TODAS AS EMPRESAS CADASTRADAS NO BANCO
        /// </summary>
        /// <returns></returns>
        public List<Empresa> ConsultarTodos()
        {

            MySqlConnection conn = null;                                    // INSTANCIA DO CONEXAO COM O BANCO
            MySqlCommand comand = null;                                     // INSTANCIA DO OBJ COMMAND, QUE EXECUTA O COMANDO NO BD
            MySqlDataReader result = null;                                  // INSTANCIA DO OBJ RESULT QUE IRÁ RECEBER O RESULTADO DA CONSULTA 

            Empresa emp = null;                                             // INSTANCIANDO OBJ DE EMPRESA

            List<Empresa> todos = new List<Empresa>();                      // INSTANCIANDO LISTA DE OBJ DE EMPRESA
            String sql = "select * from empresa";                           // QUERY A SER EXECUTADA NO BD

            try
            {
                conn = new Conexao().Abrir();                               // ABRINDO CONEXAO COM O BD

                if (conn != null)                                           // SE CONEXAO DIFERENTE DE NULO
                {
                    comand = new MySqlCommand(sql, conn);                   // CONCLUINDO INSTANCIA DO OBJ COMAND

                    result =  comand.ExecuteReader();                       // EXECURANDO COMAND NO BANCO E RECEBENDO RESULTADO

                    while (result.Read())                                   // ENQUANTO TIVER RESULTADO 
                    {
                        emp = new Empresa();                                // CONCLUINDO INSTANCIA DO OBJ COMAND

                        emp.Cnpj = result["cnpj"].ToString();               // RECEBENDO RESULTADO E PASSANDO PARA OBJ
                        emp.Nome = result["nome"].ToString();               // RECEBENDO RESULTADO E PASSANDO PARA OBJ
                        emp.Telefone = result["telefone"].ToString();       // RECEBENDO RESULTADO E PASSANDO PARA OBJ
                        emp.Email = result["email"].ToString();             // RECEBENDO RESULTADO E PASSANDO PARA OBJ

                        todos.Add(emp);                                     // ADD OBJ A LISTA DE OBJs
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close();                                                   // FECHA CONEXAO
            return todos;                                                   // RETORNA LISTA DE OBJ EMPRESA
        }

    }
}
