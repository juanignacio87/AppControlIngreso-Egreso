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

namespace ControlMoney.Formularios
{
    public partial class FTipoGasto : Form
    {
        public FTipoGasto()
        {
            InitializeComponent();
        }

        bool Editar;
        int IdTipoEgreso;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validacion()) return;

            if (!guardar()) return;

            finalizar();
        }

        private bool validacion()
        {
            if (string.IsNullOrWhiteSpace(txtEgreso.Text))
            {
                MessageBox.Show("Ingresar denominación");
                return false;
            }

            return true;
        }

        private bool guardar()
        {
            TipoGasto tipoEgreso = new TipoGasto
            {
                Denominacion = txtEgreso.Text,

                IdTipoEgreso = IdTipoEgreso
            };

            return TipoGasto.Guardar(tipoEgreso, Editar);
        }

        private void finalizar()
        {
            ListarGrid();
            limpiar();
        }

        private void limpiar()
        {
            txtEgreso.Text = "";
            Editar = false;
        }

        private void ListarGrid()
        {
            dgvDatos.DataSource = TipoGasto.Listar();
            DBDatos.OcultarIds(dgvDatos);
        }

        private void FTipoGasto_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IdTipoEgreso = Convert.ToInt32(dgvDatos.CurrentRow.Cells["IDTipoEgreso"].Value);
            txtEgreso.Text = dgvDatos.CurrentRow.Cells["Denominacion"].Value.ToString();
            Editar = true;
        }
    }
}
