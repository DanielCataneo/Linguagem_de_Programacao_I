using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunoWindowsForms.DAO
{
    using System.Data.SqlClient;
    namespace DAO
    {   
        // Assinatura do Metodo ( Linha Abaixo )
        public static class ConexaoBD
        {
            /// <summary>
            /// Método Estático que retorna um conexao aberta com o BD
            /// </summary>
            /// <returns>Conexão aberta</returns>
            public static SqlConnection GetConexao()
            {   
                // String de conexao para realizar o acesso dentro do SQL
                string strCon = "Data Source=LOCALHOST; Database=AULADB; user id=sa; password=123456";

                // Classe                        Construtor
                SqlConnection conexao = new SqlConnection(strCon);
                                
                conexao.Open();
                return conexao;
            
            }
        }
    }
}
