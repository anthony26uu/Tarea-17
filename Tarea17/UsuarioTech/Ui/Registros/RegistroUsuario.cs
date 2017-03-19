using Entidades;
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
    public partial class RegistroUsuario : Form
    {
      //  Usuarios usuario;

        private static Entidades.Usuarios usuario = null;

        private static List<Entidades.PermisosDetalles> listaRelaciones = new List<PermisosDetalles>();

        private static List<Entidades.Permisos> listPermisos = new List<Entidades.Permisos>();

        public RegistroUsuario()
        {
          
            InitializeComponent();
        }

        private void LlanarTipo()
        {
            TipoComboBox.DataSource = BLL.PermisosBLL.GetListodo();
            TipoComboBox.DisplayMember = "Descripcon";
            TipoComboBox.ValueMember = "PermisosId";

        }


        private void Limpiar()
        {
            usuario = null;
            listaRelaciones = new List<PermisosDetalles>();
            listPermisos = new List<Entidades.Permisos>();
            nombreUsuarioTextBox.Clear();
            IdnumericUpDown.ResetText();
            passUsuarioTextBox.Clear();
         
            nombreUsuarioTextBox.Focus();
            TipoComboBox.Text = null;
            dataGridView1.DataSource = null;
            errorProviderTodo.Clear();
        }


        private void LlenarInstancia()
        {
            string nombre = nombreUsuarioTextBox.Text;
            string pass = passUsuarioTextBox.Text;
            usuario = new Usuarios(0, nombre,pass);
        }

        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listPermisos;
            dataGridView1.Columns["Descripcon"].HeaderText = "Descripcon";
       
        }
        
  
        
        private bool Validar()
        {
            bool retorno = true;
            if (string.IsNullOrWhiteSpace(nombreUsuarioTextBox.Text))
            {
                errorProviderTodo.SetError(nombreUsuarioTextBox, "Campo Vacio");
                retorno = false;
            }
            if (string.IsNullOrWhiteSpace(passUsuarioTextBox.Text))
            {
                errorProviderTodo.SetError(passUsuarioTextBox, "Campo Vacio");
                retorno = false;
            }
        
            if (string.IsNullOrWhiteSpace(TipoComboBox.Text))
            {
                errorProviderTodo.SetError(TipoComboBox, "Selecione ");
                retorno = false;
            }
            return retorno;

        }


        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            
            Limpiar();
            LlanarTipo();

        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
                LlenarInstancia();
           
          
            if (usuario != null)
                    {
              
                bool guardadoRelacion = true;
                usuario = BLL.UserBLL.GuardarBool(usuario);

                foreach (var relacion in listaRelaciones)
                {
                    relacion.PermisosId = usuario.Id;
                    if (BLL.PermisosDetallesBLL.Guardar(relacion) == false)
                    {
                        guardadoRelacion = false;
                        break;
                    }
                }

                if (usuario != null && guardadoRelacion)
                {
                    MessageBox.Show("Correcto");
                }
                else
                {
                    MessageBox.Show("Error");
                }
                Limpiar();
             


            }
             
            }
           
        

        private void buttonbuscar_Click(object sender, EventArgs e)
        {
            

            usuario = BLL.UserBLL.BuscarB(Convert.ToInt32(IdnumericUpDown.Text));

            if (usuario != null)
            {
                listaRelaciones = null;
                listPermisos = null;
                listPermisos = new List<Entidades.Permisos>();
                listaRelaciones = BLL.PermisosDetallesBLL.GetList(R => R.PermisosId == usuario.Id);
                foreach (var relacion in listaRelaciones)
                {
                    listPermisos.Add(BLL.PermisosBLL.BuscarB(relacion.PermisosDetallesId));
                }
                RefreshDataGridView();
                nombreUsuarioTextBox.Text = usuario.NombreUsuario;

                passUsuarioTextBox.Text = usuario.PassUsuario;
                MessageBox.Show("Correcto");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(IdnumericUpDown.Text);
           
            var user = BLL.UserBLL.Buscar(p => p.Id == id);
            if (string.IsNullOrWhiteSpace(passUsuarioTextBox.Text))
            {
                errorProviderTodo.SetError(passUsuarioTextBox, " Ingrese Contraseña de usuario a eliminar \n en Campo Contrasña");
                MessageBox.Show("Llene Campos");
                errorProviderTodo.Clear();
           
            }
            else
            {
                if (passUsuarioTextBox.Text == user.PassUsuario)
                {
                    if (BLL.UserBLL.Eliminar(user))
                    {

                        MessageBox.Show("Eliminado con exito.");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar .");
                    }
                }
                else
                {
                    errorProviderTodo.SetError(passUsuarioTextBox, "Para Eliminar Coloque contraseña usuario a eliminar");
                }
            }

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            listaRelaciones.Add(new PermisosDetalles(0, 0, TipoComboBox.SelectedIndex + 1));
            listPermisos.Add(BLL.PermisosBLL.BuscarB(TipoComboBox.SelectedIndex + 1));
            RefreshDataGridView();
         
        }

        private void RegistroUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            listaRelaciones = null;
            listPermisos = null;
        }
    }
}
