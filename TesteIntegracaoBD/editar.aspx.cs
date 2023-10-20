using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesteIntegracaoBD
{
    public partial class editar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            txtcodiogo.Enabled= false;

            if (!IsPostBack && Request.QueryString["c"] != null)
            {
                string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracaoBD";
                MySqlConnection conexao = new MySqlConnection(linhaConexao);
                MySqlDataReader dados = null;

                try
                {
                    conexao.Open();
                    string comando = $"SELECT * FROM produto WHERE cd_produto = {Request.QueryString["c"]}";
                    MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                    dados = cSQL.ExecuteReader();

                    if (dados.Read())
                    {
                        txtcodiogo.Text = dados.GetString(0);
                        txtNome.Text = dados.GetString(1);
                        txtValor.Text = dados.GetDecimal(2).ToString();
                    }
                }
                catch 
                {
                    txtcodiogo.Text = "Ocorreu um erro inesperado! Por favor tente novamente.";
                }
                finally
                {
                    if (dados != null)
                    {
                        if (!dados.IsClosed)
                        {
                            dados.Close();
                        }
                    }

                    if (conexao != null)
                    {
                        if (conexao.State == System.Data.ConnectionState.Open)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string novoNome = txtNome.Text;
            string novoPreco = txtValor.Text.Replace(",", ".");

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                lblSpam.Text = "Erro: Digite o nome do produto!!";
                return;
            }

            if (string.IsNullOrEmpty(txtValor.Text))
            {
                lblSpam.Text = "Erro: Digite o valor do produto!!";
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

            string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracaoBD";
            MySqlConnection conexao = new MySqlConnection(linhaConexao);

            try
            {
                conexao.Open();
                string comando = $"UPDATE produto SET nm_produto = '{novoNome}', vl_produto = {novoPreco} WHERE cd_produto = {Request.QueryString["c"]}";
                MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                cSQL.ExecuteNonQuery();
            }
            catch 
            {
                lblSpam.Text = "Ocorreu um erro inesperado! Por favor tente novamente.";
            }
            finally
            {
                if (conexao != null)
                {
                    if (conexao.State == System.Data.ConnectionState.Open)
                    {
                        conexao.Close();
                    }
                }
            }

            Response.Redirect("index.aspx");
        }
    }
}