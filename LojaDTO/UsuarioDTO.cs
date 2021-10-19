using System;
using System.Collections.Generic;
using System.Text;

namespace LojaDTO
{
    public class UsuarioDTO
    /* Classe dos Ojetos/Propriedades Public, Get e Set*/
    {
        private int _cod_usuario;
        private string _nome;
        private string _login;
        private string _email;
        private string _senha;
        private DateTime _cadastro;
        private int _situacao;
        private int _perfil;

        public int Cod_usuario
        {
            set { _cod_usuario = value; }
            get { return _cod_usuario; }
        }
        public string Nome
        {
            set { _nome = value; }
            get { return _nome; }
        }
        public string Login
        {
            set { _login = value; }
            get { return _login; }
        }
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        public string Senha
        {
            set { _senha = value; }
            get { return _senha; }
        }
        public DateTime Cadastro
        {
            set { _cadastro = value; }
            get { return _cadastro; }
        }
        public int Situacao
        {
            set { _situacao = value; }
            get { return _situacao; }
        }
        public int Perfil
        {
            set { _perfil = value; }
            get { return _perfil; }
        }
    }
}
