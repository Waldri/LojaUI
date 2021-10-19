using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LojaDTO;
using LojaBLL;

namespace LojaUI
{
    public partial class Cadastro_usuario : Form
    {
        /* modo de seguraça */
        string modo = "";

        public Cadastro_usuario()
        {
            InitializeComponent();
        }

        private void Cadastro_usuario_Load(object sender, EventArgs e)
        /* Atualizar Grid*/
        {
            carregarGrid();
            desativarCampos();
        }
        private void carregarGrid()
        {
            try
            {
                IList<UsuarioDTO> listUsuarioDTO = new List<UsuarioDTO>();
                listUsuarioDTO = new UsuarioBLL().CargaUsuario();
                /* Preencher DataGridView */
                dataGridView1.DataSource = listUsuarioDTO;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /* carregar dados do gri para o form */
            int sel = dataGridView1.CurrentRow.Index;
            txtNome.Text = Convert.ToString(dataGridView1["nome",sel].Value);
            txtLogin.Text = Convert.ToString(dataGridView1["login", sel].Value);
            txtEmail.Text = Convert.ToString(dataGridView1["email", sel].Value);
            txtSenha.Text = Convert.ToString(dataGridView1["senha", sel].Value);
            txtCadastro.Text = Convert.ToString(dataGridView1["cadastro", sel].Value);
            cboPerfil.SelectedIndex = Convert.ToInt32(dataGridView1["perfil", sel].Value);
            cboSituacao.SelectedIndex = Convert.ToInt32(dataGridView1["situacao", sel].Value);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ativarCampos();
            /* Limpar form */
            limpar_campos();
            /* Inserir data atual */
            txtCadastro.Text = Convert.ToString(System.DateTime.Now);
            /* Mudar modo para edição */
            modo = "novo";

        }

        /* Metodos */
        private void limpar_campos()
        {
            txtNome.Text = "";
            txtCadastro.Text = "";
            txtLogin.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            cboPerfil.Text = "";
            cboSituacao.Text = "";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (modo == "novo")
            {
                try
                {
                    /* objeto USU */
                    UsuarioDTO USU = new UsuarioDTO();
                    USU.Nome = txtNome.Text;
                    USU.Login = txtNome.Text;
                    USU.Email = txtEmail.Text;
                    USU.Senha = txtSenha.Text;
                    USU.Cadastro = System.DateTime.Now;
                    USU.Situacao = cboSituacao.SelectedIndex;
                    USU.Perfil = cboPerfil.SelectedIndex;

                    int x = new UsuarioBLL().inserirUsuario(USU);
                    if(x > 0)
                    {
                        MessageBox.Show("Gravado com Sucesso!");
                    }
                    /* atualizar Grid */
                    carregarGrid();
                    limpar_campos();
                    desativarCampos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro inesperado" + ex);
                }
                modo = "";
            }
            if(modo == "alterar")
            {
                try
                {
                    /* objeto USU */
                    UsuarioDTO USU = new UsuarioDTO();
                    int sel = dataGridView1.CurrentRow.Index;
                    USU.Cod_usuario = Convert.ToInt32(dataGridView1["cod_usuario", sel].Value);
                    USU.Nome = txtNome.Text;
                    USU.Login = txtNome.Text;
                    USU.Email = txtEmail.Text;
                    USU.Senha = txtSenha.Text;
                    USU.Cadastro = System.DateTime.Now;
                    USU.Situacao = cboSituacao.SelectedIndex;
                    USU.Perfil = cboPerfil.SelectedIndex;

                    int x = new UsuarioBLL().alterarUsuario(USU);
                    if (x > 0)
                    {
                        MessageBox.Show("Registro alterado!");
                    }
                    /* atualizar Grid */
                    carregarGrid();
                    desativarCampos();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                modo = "";
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ativarCampos();
            modo = "alterar";
            /* recarregar campos */
            int sel = dataGridView1.CurrentRow.Index;
            txtNome.Text = Convert.ToString(dataGridView1["nome", sel].Value);
            txtLogin.Text = Convert.ToString(dataGridView1["login", sel].Value);
            txtEmail.Text = Convert.ToString(dataGridView1["email", sel].Value);
            txtSenha.Text = Convert.ToString(dataGridView1["senha", sel].Value);
            txtCadastro.Text = Convert.ToString(dataGridView1["cadastro", sel].Value);
            cboPerfil.SelectedIndex = Convert.ToInt32(dataGridView1["perfil", sel].Value);
            cboSituacao.SelectedIndex = Convert.ToInt32(dataGridView1["situacao", sel].Value);
            /* OBJ */
            UsuarioDTO USU = new UsuarioDTO();
            //int sel = dataGridView1.CurrentRow.Index;
            USU.Cod_usuario = Convert.ToInt32(dataGridView1["cod_usuario", sel].Value);
        }
        private void btnApagar_Click(object sender, EventArgs e)
        {
            try
            {
                /* OBJ */
                UsuarioDTO USU = new UsuarioDTO();
                int sel = dataGridView1.CurrentRow.Index;
                USU.Cod_usuario = Convert.ToInt32(dataGridView1["cod_usuario", sel].Value);
                /* itens deletados */
                var opcao = MessageBox.Show("Deletar registro?","Deseja deletar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if(opcao.ToString() == "Yes")
                {
                    int x = new UsuarioBLL().deletarUsuario(USU);
                    if (x > 0)
                    {
                        MessageBox.Show("Foram deletados " + x + " itens");
                    }
                    else
                    {
                        MessageBox.Show("Nenhum itens selecionado");
                    }
                    /* Atualizar Grid*/
                    carregarGrid();
                    desativarCampos();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nenhum itens selecionado");
                throw ex;
            }
        }
        /* desativar campos */
        private void desativarCampos()
        {
            dataGridView1.Enabled = true;
            txtNome.Enabled = false;
            txtLogin.Enabled = false;
            txtEmail.Enabled = false;
            txtSenha.Enabled = false;
            txtCadastro.Enabled = false;
            txtCadastro.Enabled = false;
            cboSituacao.Enabled = false;
            cboPerfil.Enabled = false;
        }
        private void ativarCampos()
        {
            dataGridView1.Enabled = false;
            txtNome.Enabled = true;
            txtLogin.Enabled = true;
            txtEmail.Enabled = true;
            txtSenha.Enabled = true;
            txtCadastro.Enabled = true;
            txtCadastro.Enabled = true;
            cboSituacao.Enabled = true;
            cboPerfil.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var opcao = MessageBox.Show("Deseja cancelar?","Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcao.ToString() == "Yes")
            {
                modo = "";
                desativarCampos();
                carregarGrid();
            }
        }
    }
}
