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
        }
    }
}
