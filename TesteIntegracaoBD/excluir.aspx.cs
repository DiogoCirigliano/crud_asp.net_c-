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
                Banco_dados conexao = new Banco_dados();
                conexao.conectar("localhost", "root", "root", "integracaoBD");
                MySqlDataReader dados = null;

                try
                {
                    string comando = $"SELECT * FROM produto WHERE cd_produto = {codigoProduto}";
                    dados = conexao.consultar(comando);

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
                }
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["c"] != null)
            {
                string codigoProduto = Request.QueryString["c"];
                Banco_dados conexao = new Banco_dados();
                conexao.conectar("localhost", "root", "root", "integracaoBD");

                try
                {
                    string comando = $"DELETE FROM produto WHERE cd_produto = {codigoProduto}";
                    conexao.Executar(comando);
                    Response.Redirect("index.aspx");
                }
                catch
                {
                    lblSpam.Text = "Ocorreu um erro inesperado ao excluir o produto.";
                }
                finally
                {
                conexao.desconectar();
                }
            }
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}
    
