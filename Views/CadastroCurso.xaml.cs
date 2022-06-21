using System;
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
using MySql.Data.MySqlClient;

namespace System_Escola.Views
{
    /// <summary>
    /// Lógica interna para CadastroCurso.xaml
    /// </summary>
    public partial class CadastroCurso : Window
    {
        private Curso _curso = new Curso();

        public CadastroCurso()
        {
            InitializeComponent();
            Loaded += CadastroCurso_Loaded;
        }

        public CadastroCurso(Curso curso)
        {
            InitializeComponent();
            _curso = curso;
            Loaded += CadastroCurso_Loaded;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _curso.Nome = txtNome.Text;
            _curso.Turno = cbTurno.Text;
            _curso.CargaHoraria = txtCargaHoraria.Text;
            _curso.Descricao = txtDescricao.Text;

            try
            {
                var dao = new CursoDAO();

                if (_curso.Id > 0)
                {
                    dao.Update(_curso);
                    MessageBox.Show("Registro Atualizado com Sucesso!");
                }
                else
                {
                    dao.Insert(_curso);
                    MessageBox.Show("Registro Salvo com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ListaCurso cha = new ListaCurso();
            cha.ShowDialog();
        }

        private void CadastroCurso_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _curso.Nome;
            txtDescricao.Text = _curso.Descricao;
            txtCargaHoraria.Text = _curso.CargaHoraria;
            cbTurno.Text = _curso.Turno;
        }

        
    }
}
