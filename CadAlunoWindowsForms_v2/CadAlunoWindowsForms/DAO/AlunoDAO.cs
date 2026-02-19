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
            private SqlParameter[] CriaParametros(AlunoViewModel aluno)
            {
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("id", aluno.Id);
                p[1] = new SqlParameter("nome", aluno.Nome);
                p[2] = new SqlParameter("mensalidade", aluno.Mensalidade);
                p[3] = new SqlParameter("cidadeId", aluno.CidadeId);
                p[4] = new SqlParameter("dataNascimento", aluno.DataNascimento);
                return p;
            }


            public void Inserir(AlunoViewModel aluno)
            {
                using (SqlConnection conexao = ConexaoBD.GetConexao())
                { 

                   
                    string sql = String.Format(
                    "insert into alunos(id, nome, mensalidade, cidadeId, dataNascimento)" +
                    "values ( @id, @nome, @mensalidade, @cidadeId, @dataNascimento)");
                  
                    HelperDAO.ExecutaSQL(sql, CriaParametros(aluno));

                 }

            
            }
           
            public void Delete(AlunoViewModel aluno)
            {
                
                        // Metodo alternativo para quando nao se sabe o tamanho do vetor
                        var p = new SqlParameter[]
                        {
                            new SqlParameter("id", aluno.Id)
                        };


                        string sql = string.Format("Delete from alunos " +
                                                   "where Id = @id");
                       HelperDAO.ExecutaSQL(sql,p);
                
            }

            public void Update(AlunoViewModel aluno)
            {
                using (SqlConnection conexao = ConexaoBD.GetConexao())
                {

                        string sql = string.Format(
                                                   "UPDATE alunos SET " +
                                                   "nome = @nome, " +
                                                   "mensalidade = @mensalidade, " +
                                                   "cidadeId=@cidadeId, " +
                                                   "dataNascimento=@dataNascimento " +
                                                   "Where Id = @id"
                                                    );


                    HelperDAO.ExecutaSQL(sql, CriaParametros(aluno));
                }
            }
        }
    }
}
