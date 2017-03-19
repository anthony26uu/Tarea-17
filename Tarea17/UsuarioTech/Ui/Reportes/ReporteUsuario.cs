using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UsuarioTech.Ui.Reportes
{
    public partial class ReporteUsuario : Form
    {
        public ReporteUsuario()
        {
            InitializeComponent();
        }

        private void ReporteUsuario_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"C:\Users\antho\OneDrive - Universidad Católica Nordestana (UCNE)\Tareas de Anthony\Semestre 7\Aplicada I\Repositorios\Tarea-17\Tarea17\UsuarioTech\Ui\Reportes";
            ReportDataSource source = new ReportDataSource("DataSet", BLL.UserBLL.GetList());
            reportViewer1.LocalReport.DataSources.Add(source);
        }
    }
}
