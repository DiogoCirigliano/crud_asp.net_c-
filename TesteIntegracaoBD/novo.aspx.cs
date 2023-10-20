using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesteIntegracaoBD
{
    public partial class novo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string novoCodigo = txtcodiogo.Text;
            string novoNome = txtnome.Text;
            string novoPreco = txtValor.Text.Replace(",",".");


            #region Tratamento de erro
            if (string.IsNullOrEmpty(txtnome.Text))
            {
                lblSpam.Text = "Erro: Digite o nome do produto!!";
                return;
            }
            
            if (string.IsNullOrEmpty(txtcodiogo.Text)) 
            {
                lblSpam.Text = "Erro: Digite o código do produto!!";
                return;
            }
            if(string.IsNullOrEmpty(txtValor.Text))
            {
                lblSpam.Text = "Erro: Digite o valor do produto!!";
                return;
            }

            #region Impedir de digitar letra
            try
            {
                double.Parse(novoCodigo);
                lblSpam.Text = "";
            }
            catch
            {
                lblSpam.Text = "São válidos apenas caracteres numéricos!";
                txtcodiogo.Text = "";
                return;
            }
            try
            {
                double.Parse(novoPreco);
                lblSpam.Text = "";
            }
            catch
            {
                lblSpam.Text = "São válidos apenas caracteres numéricos!";
                txtValor.Text = "";
                return;
            }
            #endregion

            #endregion

            string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracaoBD";

            MySqlConnection conexao = new MySqlConnection(linhaConexao); 


            try
            {   
                    conexao.Open();
                    string inserirComando = $"INSERT INTO produto (cd_produto, nm_produto, vl_produto) VALUES ({novoCodigo}, '{novoNome}', {novoPreco})";
                    MySqlCommand cSQLInserir = new MySqlCommand(inserirComando, conexao);
                    cSQLInserir.ExecuteNonQuery();
                    lblSpam.Text = "";
                
            }
            catch
            {
                lblSpam.Text = "O código já existe";
                return;
            }
            Response.Redirect("index.aspx");

        }
    }
}
    