using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteGrupoGPS.Modelo
{
    public class Empresa
    {

        /// <summary>
        /// /////////// CLASSE EMPRESA - *** METODOS PUBLICOS PARA FACILITAR A PROGRAMAÇÃO **** É EU SEI QUE TEM QUE SEM PRIVATE
        /// </summary>
        public EmpresaAtividadePrincipal Atividade_Principal { get; set; }
        public List<EmpresaAtividadeSecundaria> EmpresaAtividadeSecundaria { get; set; }
        public List<EmpresaQSA> EmpresaQSA { get; set; }
        public String Nome { get; set; }
        public String Complemento { get; set; }
        public String Email { get; set; }
        public DateTime Data_Situacao { get; set; }
        public String Telefone { get; set; }
        public String Porte { get; set; }
        public DateTime Abertura { get; set; }
        public String Natureza_Juridica { get; set; }
        public String Cnpj { get; set; }
        public DateTime Ultima_Atualizacao { get; set; }
        public String Status { get; set; }
        public String Tipo { get; set; }
        public String Fantasia { get; set; }
        public String Efr { get; set; }
        public String Motivo_Situacao { get; set; }
        public String Situacao_Especial { get; set; }
        public DateTime Data_Situacao_Especial { get; set; }
        public float Capital_Social { get; set; }
        public String Situacao { get; set; }
        public String Bairro { get; set; }
        public String Logradouro { get; set; }
        public String Numero { get; set; }
        public String Cep { get; set; }
        public String Municipio { get; set; }
    }
}
