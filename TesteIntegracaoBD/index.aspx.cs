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
            string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=integracaoBD";
            MySqlConnection conexao = new MySqlConnection(linhaConexao); //Intanciamento
            MySqlDataReader dados = null;
            try
            {
                conexao.Open();
                string comando = "Select * from produto";
                MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                dados = cSQL.ExecuteReader();
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
            catch
            {
                litTabela.Text = "Ocorreu um erro inesperado! Por favor novamente.";
            }
            finally
            { 
                if (dados !=null)
                {
                    if (!dados.IsClosed)
                    { 
                        dados.Close();
                    }
                }
                
                if (conexao !=null)
                    if (conexao.State == System.Data.ConnectionState.Open)
                        conexao.Close();
            }
            
        }
    }
}