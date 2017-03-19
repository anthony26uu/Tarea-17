using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UsuarioTech.Ui.Consultas
{
    public partial class ConsultaUsuario : Form
    {
        public ConsultaUsuario()
        {
            InitializeComponent();
        }

        public void Llenar()
        {

            comboBox1.Items.Insert(0, "NOMBRE");
            comboBox1.Items.Insert(1, "Permiso");
            //    comboBox1.Items.Insert(2, "TODO");

            //Si Colocas DiplayMember arriba no funcoina
            comboBox1.DataSource = comboBox1.Items;
            comboBox1.DisplayMember = "Nombre";


        }

        public void Selecionar()
        {

            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = BLL.UserBLL.Buscar(p => p.NombreUsuario == buscaText.Text);
            }

            if (comboBox1.SelectedIndex == 1)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = BLL.UserBLL.Buscar(p => p.Tipo == buscaText.Text);
                }
            }


        }

        private void ConsultaUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
