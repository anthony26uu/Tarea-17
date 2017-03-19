using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UsuarioTech.Ui.Registros
{
    public partial class RegistroPermisos : Form
    {
        public RegistroPermisos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            descripconTextBox.Clear();
            permisosIdMaskedTextBox.Clear();
            descripconTextBox.Focus();
        }

        private bool Validar()
        {
            bool retorno = true;
            if (string.IsNullOrWhiteSpace(descripconTextBox.Text))
            {
                errorProviderTodo.SetError(descripconTextBox, "Campo Vacio");
                retorno = false;
            }
            return retorno;

        }


        private void RegistroPermisos_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Entidades.Permisos db = new Entidades.Permisos();
                db.Descripcon = descripconTextBox.Text;
             
                    if (!Validar())
                    {
                        MessageBox.Show("Por favor llenar los campos");
                    }
                    else if (BLL.PermisosBLL.Guardar(db))
                    {
                        MessageBox.Show("El Usuario se agrego con exito.");
                    }

                    Limpiar();
                
              
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
