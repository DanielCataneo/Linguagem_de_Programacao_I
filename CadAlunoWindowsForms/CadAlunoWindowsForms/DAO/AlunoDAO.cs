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
            /// <summary> 
            /// Método para inserir um aluno no BD 
            /// </summary> 
            /// <param name="aluno">objeto aluno com todas os atributos preenchidos</param> 
            public void Inserir(AlunoViewModel aluno)
            {
                SqlConnection conexao = ConexaoBD.GetConexao();
                try
                {
                    //devemos substituir a ',' por '.' 
                    string mensalidade = aluno.Mensalidade.ToString().Replace(',', '.');
                    // set dateformat dmy; este comando serve para alterar a 
                    //forma como o SQL Server entende o formato de data 
                    string sql = String.Format("set dateformat dmy; " +
                    "insert into alunos(id, nome, mensalidade, cidadeId, dataNascimento)" +
                    "values ( {0}, '{1}', {2}, {3}, '{4}')", aluno.Id,
                    aluno.Nome, mensalidade, aluno.CidadeId, aluno.DataNascimento);
                    SqlCommand comando = new SqlCommand(sql, conexao);
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
                    string sql = string.Format("set dateformat dmy; UPDATE alunos SET nome = '{0}', mensalidade = {2}," +
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
