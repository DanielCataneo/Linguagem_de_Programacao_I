using CadAlunoWindowsForms.DAO.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CadAlunoWindowsForms.DAO
{
    public static class HelperDAO
    {
        /// <summary>
        /// Executa um comando SQL no banco de dados
        /// Sem retorno
        /// </summary>
        /// <param name="sql"> instrucao SQL </param>
        /// <param name="p"> parametros com os dados </param>
        public static void ExecutaSQL(string sql, SqlParameter[] p)
        {
            using (var conexao = ConexaoBD.GetConexao())
            {
                using(var comando = new SqlCommand(sql, conexao))
                {
                    if (p != null)
                    {
                        comando.Parameters.AddRange(p);
                        comando.ExecuteNonQuery();
                    }

                }
                
            }
                
        }
    }
}
