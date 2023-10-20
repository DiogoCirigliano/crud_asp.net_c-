using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace TesteIntegracaoBD
{
    public partial class excluir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtcodiogo.Enabled= false;
            txtNome.Enabled= false;
            txtValor.Enabled= false;

            if (Request.QueryString["c"] != null)
            {
                string codigoProduto = Request.QueryString["c"];
                string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracaoBD";
                MySqlConnection conexao = new MySqlConnection(linhaConexao);
                MySqlDataReader dados = null;

                try
                {
                    conexao.Open();
                    string comando = $"SELECT * FROM produto WHERE cd_produto = {codigoProduto}";
                    MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                    dados = cSQL.ExecuteReader();

                    if (dados.Read())
                    {
                        txtcodiogo.Text = dados[0].ToString();
                        txtNome.Text = dados[1].ToString();
                        txtValor.Text= dados[2].ToString();
                    }
                }
                catch
                {
                    lblSpam.Text = "Ocorreu um erro inesperado!";
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

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["c"] != null)
            {
                string codigoProduto = Request.QueryString["c"];
                string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracaoBD";
                MySqlConnection conexao = new MySqlConnection(linhaConexao);

                try
                {
                    conexao.Open();
                    string comando = $"DELETE FROM produto WHERE cd_produto = {codigoProduto}";
                    MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                    cSQL.ExecuteNonQuery();

                    Response.Redirect("index.aspx");
                }
                catch
                {
                    lblSpam.Text = "Ocorreu um erro inesperado ao excluir o produto.";
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
            }
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}
    
