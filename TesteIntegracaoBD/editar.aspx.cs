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
            if(!IsPostBack)
            {
                txtcodiogo.Enabled = false;
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
                            txtValor.Text = dados[2].ToString();
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

        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string novoNome = txtNome.Text;
            string novoPreco = txtValor.Text.Replace(",", ".");

            #region tratamento de erro
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
            #endregion


            Banco_dados conexao = new Banco_dados();
            conexao.conectar("localhost", "root", "root", "integracaoBD");

            try
            {
                string comando = $"UPDATE produto SET nm_produto = '{novoNome}', vl_produto = {novoPreco} WHERE cd_produto = {Request.QueryString["c"]}";
                conexao.Executar(comando);
            }
            catch 
            {
                lblSpam.Text = "Ocorreu um erro inesperado! Por favor tente novamente.";
            }
            finally
            {
                conexao.desconectar();
                Response.Redirect("index.aspx");
            }
        }
    }
}