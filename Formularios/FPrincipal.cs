using ControlMoney.Clases;
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
    public partial class FPrincipal : Form
    {
        public FPrincipal()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FIngreso frm = new FIngreso();
            frm.ShowDialog();

            ListarMovimiento();
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            txtAño.Text = DateTime.Now.Year.ToString();
            cboMes.SelectedIndex = (DateTime.Now.Month - 1);
            ListarMovimiento();

        }

        private void ListarMovimiento()
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Mes", (cboMes.SelectedIndex +1)),
                new Parametro("@Año", txtAño.Text)
            };

            dgvMovimiento.DataSource = DBDatos.Listar("Movimiento_Listar", parametros);
            DBDatos.OcultarIds(dgvMovimiento);
            dgvMovimiento.Columns["Movimiento"].Visible = false;
            dgvMovimiento.Columns["Descripcion"].Width = 200;

            Pintar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarMovimiento();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FGastos frm = new FGastos();
            frm.ShowDialog();

            ListarMovimiento();
        }

        public void Pintar()
        {
            foreach (DataGridViewRow fila in dgvMovimiento.Rows)
            {
                string movimiento = fila.Cells["Movimiento"].Value.ToString();

                fila.DefaultCellStyle.BackColor = movimiento.Equals("I") ? Color.Lime : Color.MistyRose;
            }
        }
    }
}
