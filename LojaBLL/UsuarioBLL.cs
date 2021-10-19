using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using LojaDTO;
using LojaDAL;


namespace LojaBLL
{
    public class UsuarioBLL
    {
        /* Regra de Leitura Usuarios registrados */
        public IList<UsuarioDTO> CargaUsuario()
        {
            try
            {
                return new UsuarioDAL().CargaUsuario();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /* Regra de Gravação novos usuarios */
        public int inserirUsuario(UsuarioDTO USU)
        {
            try
            {
                return new UsuarioDAL().inserirUsuario(USU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* Regra alterar usuario */
        public int alterarUsuario(UsuarioDTO USU)
        {
            try
            {
                return new UsuarioDAL().alterarUsuario(USU);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /* Deletar usuario */
        public int deletarUsuario(UsuarioDTO USU)
        {
            try 
            {
                return new UsuarioDAL().deletarUsuario(USU);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
