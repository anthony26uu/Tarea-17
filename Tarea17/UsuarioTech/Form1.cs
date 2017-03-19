using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UsuarioTech
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ui.Registros.RegistroUsuario db = new Ui.Registros.RegistroUsuario();
            db.Show();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ui.Registros.RegistroPermisos db = new Ui.Registros.RegistroPermisos();
            db.Show();
        }

        private void reportesUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ui.Reportes.ReporteUsuario db = new Ui.Reportes.ReporteUsuario();
            db.Show();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ui.Consultas.ConsultaUsuario db = new Ui.Consultas.ConsultaUsuario();
            db.Show();
        }
    }
}
