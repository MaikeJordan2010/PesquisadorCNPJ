using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TesteGrupoGPS.Modelo;

namespace TesteGrupoGPS.Util
{
    public class BuscarURL
    {

        public String BuscarApi(String url)
        {
            var requisicaoWeb = WebRequest.CreateHttp(url);                 // Declara variavel do tipo WebRequest passando a URL como parametro!
            requisicaoWeb.Method = "GET";                                   //chama o metodo da requisição, nesse caso é GET.
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";                  // Realiza a Requisição utilizando os parametros anteriores.

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd(); //
                return objResponse.ToString();                              // retorna a resposta como String

            }

        }

        public dynamic ConverterURL(String url)
        {
            String json = BuscarApi(url);                                   // Chama função de busca do Json passando como parametro a url recebida

            //String dados = JsonConvert.ToString(json.ToString());
            //dynamic jsonTratado = JValue.Parse(dados);

            dynamic JsonDinamic = JsonConvert.DeserializeObject(json);      // converte a resposta recebida em dynamic

            return JsonDinamic;                                             // retorna a resposta

        }


        public List<Empresa> BuscarEmpresa(String txtCNPJ)
        {
            BuscarURL dados = new BuscarURL();                              // instacia  uma função que realiza a busca do Json

            String[] TodosCnpjs = txtCNPJ.Split(";");                       // REALIZA SPLIT PARA PEGAR TODOS CNPJs, CASOS EJA MAIS DE 1


            Empresa emp = null;                                             // INSTANCIA DE OBJ EMPRESA
            EmpresaQSA QSA = null;                                          // INSTANCIA DE OBJ EMPRESA QSA
            EmpresaAtividadeSecundaria EAS = null;                          // INSTANCIA DE OBJ EMPRESA ATIVIDADE SECUNDARIA
            EmpresaAtividadePrincipal ATP = null;                           // INSTANCIA DE OBJ EMPRESA ATIVIDADE PRINCIPAL

            List<Empresa> todasEmpresas = new List<Empresa>();              // LISTA DE TODAS EMPRESAS
            List<EmpresaAtividadeSecundaria> ListEAS = new List<EmpresaAtividadeSecundaria>(); // LISTA DE OBJs EMPRESA ATIVIDADE SECUNDARIA 
            List<EmpresaQSA> ListQSA = new List<EmpresaQSA>();                                  // LISTA DE OBJs EMPRESA QSA

            dynamic json;                                                   // CRIANDO OBJ DINAMICO JSON

            String url = "https://www.receitaws.com.br/v1/cnpj/";           // URL DA PAGINA DE CONSULTA

            for (int i = 0; i < TodosCnpjs.Length; i++)                     // ENQUANTO TIVER CNPJ PARA SER CONSULTADO
            {
                json = dados.ConverterURL(url + TodosCnpjs[i]);             // CHAMA A CONSULTA PASSANDO A URL
                emp = new Empresa();                                        // CONCLUINDO INSTANCIA DO OBJ EMPRESA
                QSA = new EmpresaQSA();                                     // CONCLUINDO INSTANCIA DO OBJ EMPRESA QSA
                EAS = new EmpresaAtividadeSecundaria();                     // CONCLUINDO INSTANCIA DO OBJ EMPRESA ATIVIDADE SECUNDARIA
                ATP = new EmpresaAtividadePrincipal();                      // CONCLUINDO INSTANCIA DO OBJ EMPRESA ATIVIDADE PRINCIPAL

                   /// PREENCHENDO OS OBEJETOS PARA ADD A LISTA
                try
                {
                    ATP.Text = Convert.ToString(json.atividade_principal[0].text);
                    ATP.Code = Convert.ToString(json.atividade_principal[0].code);
                    emp.Atividade_Principal = ATP;
                    emp.Nome = Convert.ToString(json.nome);
                    emp.Email = Convert.ToString(json.email);
                    emp.Fantasia = Convert.ToString(json.fantasia);
                    emp.Cep = Convert.ToString(json.cep);
                    emp.Municipio = Convert.ToString(json.municipio);
                    emp.Tipo = Convert.ToString(json.tipo);
                    emp.Bairro = Convert.ToString(json.bairro);
                    emp.Capital_Social = Convert.ToSingle(json.capital_social);
                    emp.Cnpj = Convert.ToString(json.cnpj);
                    emp.Situacao = Convert.ToString(json.situacao);
                    emp.Abertura = Convert.ToDateTime(json.abertura);
                    emp.Telefone = Convert.ToString(json.telefone);


                    
                    foreach (var AtivSecu in json.atividades_secundarias)           // PREENCHENDO ATIVIVIDADE SECUNDARIA
                    {
                        EAS = new EmpresaAtividadeSecundaria();
                        EAS.Text = Convert.ToString(AtivSecu.text);
                        EAS.Code = Convert.ToString(AtivSecu.code);

                        ListEAS.Add(EAS);
                    }

                    
                    emp.EmpresaAtividadeSecundaria = ListEAS;                       // ADD ATIVIDADE SECUNDARIA A OBJ EMPRESA


                    
                    foreach (var socio in json.qsa)                                 // PREENCHENDO QSA
                    {
                        QSA = new EmpresaQSA();
                        QSA.Qual = Convert.ToString(socio.qual);
                        QSA.Nome = Convert.ToString(socio.nome);

                        ListQSA.Add(QSA);
                    }

                    
                    emp.EmpresaQSA = ListQSA;                                       // ADD QSA A OBJ EMPRESA


                    
                    todasEmpresas.Add(emp);                                         // ADD EMP A LISTA DE OBJs EMPRESA
                }
                catch (Exception ex)
                {

                }

            }
            return (todasEmpresas);                                                 // RETORNANDO LISTA

        }

    }
}
