using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace TesteIntegracaoBD
{
    public class Banco_dados
    {
        public MySqlConnection conexao;

        #region Conectar
        public void conectar(string server, string uid, string password, string database)
        {
            string linhaConexao = $"SERVER={server};UID={uid};PASSWORD={password};DATABASE={database}";
            conexao = new MySqlConnection(linhaConexao);
        }
        #endregion

        #region desconectar
        public void desconectar()
        {
            conexao.Close();
        }
        #endregion

        #region Consultar
        public MySqlDataReader consultar(string selectCmd)
        {
            try
            {
                conexao.Open();
                string comando = selectCmd;
                MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                MySqlDataReader dados = cSQL.ExecuteReader();
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado: " + ex.Message);
            }

        }
        #endregion

        #region Executar
        public void Executar(string ExecCmd)
        {
            try
            {
                conexao.Open();
                string comando = ExecCmd;
                MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                cSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado: " + ex.Message);
            }

        }
        #endregion


    }
}