using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace TesteIntegracaoBD
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Banco_dados conexao = new Banco_dados();
            string select = "SELECT * FROM produto;";
            conexao.conectar("localhost", "root", "root", "integracaoBD");
            MySqlDataReader dados = null;

            try
            {
                dados = conexao.consultar(select);

                while (dados.Read())
                {
                    litTabela.Text += $@"<tr>
                                    <td>{dados.GetString(0)}</td>
                                    <td>{dados.GetString(1)}</td>
                                    <td>{dados.GetString(2)}</td>
                                    <td>    
                                        <a href='editar.aspx?c={dados.GetString(0)}'>Editar</a>
                                        <br/>
                                        <a style='color:red;' href='excluir.aspx?c={dados.GetString(0)}'>Excluir</a>
                                    </td>
                                </tr>";
                }
            }
            catch (Exception ex)
            {
                litTabela.Text = $"Ocorreu um erro inesperado! Erro: {ex.Message}";
            }
            finally
            {
                if (dados != null && !dados.IsClosed)
                {
                    dados.Close();
                }
                conexao.desconectar();
            }

        }

    }
}