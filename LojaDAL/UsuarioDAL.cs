using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaDTO;
using System.Data.SqlClient;

namespace LojaDAL
{
    public class UsuarioDAL
    {
        public IList<UsuarioDTO> CargaUsuario()
        {
            try
            {
                /* Conexão */
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings1.Default.CST;
                /* Comando SQL */
                SqlCommand CMD = new SqlCommand();
                CMD.CommandType = System.Data.CommandType.Text;
                CMD.CommandText = "SELECT*FROM tb_usuarios";
                CMD.Connection = CON;
                /* Ojeto de leitura DR, objeto/lista armazenamento */
                SqlDataReader DR;
                IList<UsuarioDTO> listUsuarioDTO = new List<UsuarioDTO>();
                /* abrir conexão e executar leitura de dados */
                CON.Open();
                DR = CMD.ExecuteReader();

                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        UsuarioDTO usu = new UsuarioDTO();
                        /* preenche ojeto */
                        usu.Cod_usuario = Convert.ToInt32(DR["cod_usuario"]);
                        usu.Nome = Convert.ToString(DR["nome"]);
                        usu.Login = Convert.ToString(DR["login"]);
                        usu.Email = Convert.ToString(DR["email"]);
                        usu.Senha = Convert.ToString(DR["senha"]);
                        usu.Cadastro = Convert.ToDateTime(DR["cadastro"]);
                        usu.Situacao = Convert.ToInt32(DR["situacao"]);
                        usu.Perfil = Convert.ToInt32(DR["perfil"]);
                        
                        /* atualiza lista */
                        listUsuarioDTO.Add(usu);
                    }
                }
                /* retornar a carga */
                return listUsuarioDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Metodo Data Access Layer para inserir usuarios */
        public int inserirUsuario(UsuarioDTO USU)
        {
            try
            {
                /* Conexao DB */
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings1.Default.CST;
                SqlCommand CMD = new SqlCommand();
                CMD.CommandType = System.Data.CommandType.Text;
                CMD.CommandText = "INSERT INTO tb_usuarios (nome, login, email, senha, cadastro, situacao, perfil)" +
                    " VALUES (@nome, @login, @email, @senha, @cadastro, @situacao, @perfil)";
                /* Parametros @ */
                CMD.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = USU.Nome;
                CMD.Parameters.Add("login", System.Data.SqlDbType.VarChar).Value = USU.Login;
                CMD.Parameters.Add("email", System.Data.SqlDbType.VarChar).Value = USU.Email;
                CMD.Parameters.Add("senha", System.Data.SqlDbType.VarChar).Value = USU.Senha;
                CMD.Parameters.Add("cadastro", System.Data.SqlDbType.DateTime).Value = USU.Cadastro;
                CMD.Parameters.Add("situacao", System.Data.SqlDbType.Int).Value = USU.Situacao;
                CMD.Parameters.Add("perfil", System.Data.SqlDbType.Int).Value = USU.Perfil;
                /* Abrir conexao */
                CMD.Connection = CON;
                CON.Open();

                int qtd = CMD.ExecuteNonQuery();
                return qtd;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        /* Methodo Alterar usuario */
        public int alterarUsuario(UsuarioDTO USU)
        {
            try
            {
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings1.Default.CST;
                SqlCommand CMD = new SqlCommand();
                CMD.CommandType = System.Data.CommandType.Text;
                CMD.CommandText = "UPDATE tb_usuarios SET nome=@nome," + "login=@login,"
                    + "email=@email," + "senha=@senha," + "cadastro=@cadastro," + "situacao=@situacao,"
                    + "perfil=@perfil " + "WHERE cod_usuario=@cod_usuario";
                /* Add parametros @ */
                CMD.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = USU.Nome;
                CMD.Parameters.Add("login", System.Data.SqlDbType.VarChar).Value = USU.Login;
                CMD.Parameters.Add("email", System.Data.SqlDbType.VarChar).Value = USU.Email;
                CMD.Parameters.Add("senha", System.Data.SqlDbType.VarChar).Value = USU.Senha;
                CMD.Parameters.Add("cadastro", System.Data.SqlDbType.VarChar).Value = USU.Cadastro;
                CMD.Parameters.Add("situacao", System.Data.SqlDbType.Int).Value = USU.Situacao;
                CMD.Parameters.Add("perfil", System.Data.SqlDbType.Int).Value = USU.Perfil;
                CMD.Parameters.Add("cod_usuario", System.Data.SqlDbType.Int).Value = USU.Cod_usuario;
                /* Abrir conexao DB */
                CMD.Connection = CON;
                CON.Open();
                /* Registros alterados */
                int qtd = CMD.ExecuteNonQuery();
                return qtd;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /* Methodo deletar usuario */
        public int deletarUsuario(UsuarioDTO USU)
        {
            try
            {
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings1.Default.CST;
                SqlCommand CMD = new SqlCommand();
                CMD.CommandType = System.Data.CommandType.Text;
                CMD.CommandText = "DELETE FROM tb_usuarios WHERE cod_usuario=@cod_usuario";
                /* Add parametro */
                CMD.Parameters.Add("cod_usuario",System.Data.SqlDbType.Int).Value = USU.Cod_usuario;
                /* Abrir conexao DB*/
                CMD.Connection = CON;
                CON.Open();
                /* Registros deletados */
                int qtd = CMD.ExecuteNonQuery();
                return qtd;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
