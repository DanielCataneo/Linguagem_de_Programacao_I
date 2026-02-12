using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAlunoWindowsForms.DAO
{
    // using CadAlunoWF.Models;
    using CadAlunoWindowsForms.Models;
    using System;
    using System.Data.SqlClient;

    namespace DAO
    {
        public class AlunoDAO
        {

            public void Inserir(AlunoViewModel aluno)
            {
                SqlConnection conexao = ConexaoBD.GetConexao();
                try
                {
                    SqlParameter[] p = new SqlParameter[5];
                    p[0] = new SqlParameter("id",aluno.Id);
                    p[1] = new SqlParameter("nome",aluno.Nome);
                    p[2] = new SqlParameter("mensalidade", aluno.Mensalidade);
                    p[3] = new SqlParameter("cidadeId", aluno.CidadeId);
                    p[4] = new SqlParameter("dataNascimento", aluno.DataNascimento);



                    string sql = String.Format(
                    "insert into alunos(id, nome, mensalidade, cidadeId, dataNascimento)" +
                    "values ( @id, @nome, @mensalidade, @cidadeId, @dataNascimento)");
                    SqlCommand comando = new SqlCommand(sql, conexao);

                    comando.Parameters.AddRange(p);
                    comando.ExecuteNonQuery();
                }

     
                finally 
                {
                    conexao.Close();
                }

            
            }
           
            public void Delete(AlunoViewModel aluno)
            {
                SqlConnection conexao = ConexaoBD.GetConexao();
                try
                {
                    string sql = string.Format("Delete from alunos where Id = {0}", aluno.Id);
                    SqlCommand comando = new SqlCommand(sql, conexao);
                    comando.ExecuteNonQuery();
                }
                finally
                {
                    conexao.Close();
                }
            }

            public void Update(AlunoViewModel aluno)
            {
                SqlConnection conexao = ConexaoBD.GetConexao();

                try
                {
                    string sql = string.Format("set dateformat dmy; " +
                                               "UPDATE alunos SET nome = '{0}', mensalidade = {2}," +
                                               "cidadeId={3},  dataNascimento='{4}' Where Id = {1}"
                                                ,aluno.Nome,aluno.Id,aluno.Mensalidade,aluno.CidadeId,
                                                aluno.DataNascimento);
                    SqlCommand comando = new SqlCommand(sql, conexao);
                    comando.ExecuteNonQuery();
                }
                finally
                {
                    conexao.Close();
                }
            }
        }
    }
}
