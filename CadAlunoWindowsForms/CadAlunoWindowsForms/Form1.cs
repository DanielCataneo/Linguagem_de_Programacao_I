using CadAlunoWindowsForms.DAO.DAO;
using CadAlunoWindowsForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadAlunoWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoViewModel aluno = new AlunoViewModel();
                aluno.Id = Convert.ToInt32(txtID.Text);
                aluno.Nome = txtNome.Text;
                aluno.Mensalidade = Convert.ToDouble(txtMensalidade.Text);
                aluno.DataNascimento = Convert.ToDateTime(TxtNascimento.Text);
                aluno.CidadeId = Convert.ToInt32(txtCidade.Text);

                AlunoDAO dao = new AlunoDAO();
                dao.Inserir(aluno);

            }
            catch (Exception erro)
            {
               MessageBox.Show(erro.Message);     
            }

        }
    }
}
