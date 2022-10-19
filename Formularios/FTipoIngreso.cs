using ControlMoney.Clases;
using ControlMoney.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlMoney
{
    public partial class FTipoIngreso : Form
    {
        public FTipoIngreso()
        {
            InitializeComponent();
        }

        bool Editar;
        int IDTipoIngreso;

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void ListarGrid()
        {
            dgvDatos.DataSource = TipoIngreso.Listar();
            DBDatos.OcultarIds(dgvDatos);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validacion()) return;

            if (!guardar()) return;

            finalizar();
        }

        private void finalizar()
        {
            ListarGrid();
            limpiar();
        }

        private void limpiar()
        {
            txtIngreso.Text = "";
            Editar = false;
        }

        private bool guardar()
        {
            TipoIngreso tipoIngreso = new TipoIngreso
            {
                Denominacion = txtIngreso.Text,

                IDTipoIngreso = IDTipoIngreso
            };

            return TipoIngreso.Guardar(tipoIngreso, Editar);
        }

        private bool validacion()
        {
            if (string.IsNullOrWhiteSpace(txtIngreso.Text))
            {
                MessageBox.Show("Ingresar denominación");
                return false;
            }

            return true;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDTipoIngreso = Convert.ToInt32(dgvDatos.CurrentRow.Cells["IDTipoIngreso"].Value);
            txtIngreso.Text = dgvDatos.CurrentRow.Cells["Denominacion"].Value.ToString();
            Editar = true;
        }
    }
}
