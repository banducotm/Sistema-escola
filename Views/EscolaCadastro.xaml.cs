﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System_Escola.Models;

namespace System_Escola.Views
{
    /// <summary>
    /// Lógica interna para CadastroEscola.xaml
    /// </summary>
    public partial class EscolaCadastro : Window
    {
        private Escola _cadastro = new Escola();

        public EscolaCadastro()
        {
            InitializeComponent();
            Loaded += CadastroEscola_Loaded;
        }

        public EscolaCadastro(Escola escola)
        {
            InitializeComponent();
            _cadastro = escola;
            Loaded += CadastroEscola_Loaded;
        }

        private void CadastroEscola_Loaded(object sender, RoutedEventArgs e)
        {
            txtbox_nome.Text = _cadastro.Nome;
            txtbox_razao.Text = _cadastro.Razao;
            txtbox_cnpj.Text = _cadastro.Cnpj;
            txtbox_inscriacaoestadual.Text = _cadastro.Inscricao_est;
            if (_cadastro.Tipo == "Público")
            {
                rd_publico.IsChecked = true;
            }
            else
            {
                rd_prive.IsChecked = true;
            }
            txt_responsavel.Text = _cadastro.Responsavel;
            txt_telefoneres.Text = _cadastro.Telefone_res;
            txt_telefone.Text = _cadastro.Telefone_esc;
            txt_email.Text = _cadastro.Email;
            txt_rua.Text = _cadastro.Rua;
            txt_numero.Text = _cadastro.Numero;
            txt_bairro.Text = _cadastro.Bairro;
            txt_complemento.Text = _cadastro.Complemento;
            txt_cep.Text = _cadastro.Cep;
            txt_cidade.Text = _cadastro.Cidade;
            cb_estado.Text = _cadastro.Estado;
            dp_data.SelectedDate = _cadastro.Data_criacao;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            _cadastro.Nome = txtbox_nome.Text;
            _cadastro.Razao = txtbox_razao.Text;
            _cadastro.Cnpj = txtbox_cnpj.Text;
            _cadastro.Inscricao_est = txtbox_inscriacaoestadual.Text;

            _cadastro.Tipo = "Pública";
            if ((bool)rd_prive.IsChecked)
                _cadastro.Tipo = "Privada";

            _cadastro.Data_criacao = dp_data.SelectedDate;
            _cadastro.Responsavel = txt_responsavel.Text;
            _cadastro.Telefone_res = txt_telefoneres.Text;
            _cadastro.Email = txt_email.Text;
            _cadastro.Telefone_esc = txt_telefone.Text;
            _cadastro.Rua = txt_rua.Text;
            _cadastro.Numero = txt_numero.Text;
            _cadastro.Bairro = txt_bairro.Text;
            _cadastro.Complemento = txt_complemento.Text;
            _cadastro.Cep = txt_cep.Text;
            _cadastro.Cidade = txt_cidade.Text;
            _cadastro.Estado = cb_estado.Text;

            try
            {
                var dao = new EscolaDAO();

                if (_cadastro.Id > 0)
                {
                    dao.Update(_cadastro);
                    MessageBox.Show("Registro Atualizado com Sucesso!");
                }
                else
                {
                    dao.Insert(_cadastro);
                    MessageBox.Show("Registro Salvo com Sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_bairro_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_numero_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
