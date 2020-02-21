using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.ConexaoDB
{
    public class Conexao
    {
        /// <summary>
        /// //////////// FUNÇÃO PARA ABRIR UMA CONECAO COM O BANCO DE DADOS
        /// </summary>
        /// <returns></returns>
        public MySqlConnection Abrir()
        {

            String Server = "127.0.0.1";                            // SERVIDO
            String Port = "3307";                                   // PORTA
            String Database = "teste";                              // BANCO DE DADOS
            String User = "root";                                   // USUARIO
            String Passwd = "";                                     // SENHA


            // STRING PARA CONEXAO
            String sql = " Server=" + Server + ";port=" + Port + ";Database=" + Database + ";Uid=" + User + ";pwd=" + Passwd;
            MySqlConnection conn = new MySqlConnection(sql);         //INSTANCIANDO OBJD DE CONEXAO

            try
            {
                conn.Open();                                        // ABRINDO CONECAO
            }
            catch (Exception ex)
            {

            }

            return conn;                                            // RETORNANDO CONEXAO ABERTA
        }
    }
}
