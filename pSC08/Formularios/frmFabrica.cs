using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pSC08
{
    public partial class frmFabrica : Form
    {
        public frmFabrica()
        {
            InitializeComponent();
        }

        private void frmFabrica_Load(object sender, EventArgs e)
        {
            this.Text = "maestro de fabrica";
            this.KeyPreview = true;
        }

        private void frmFabrica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnborrar_Click(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtfabrica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtfabrica.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtnombre.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtfabrica_Leave(object sender, EventArgs e)
        {
            if (txtfabrica.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
            {
                buscarfabrica();
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtnombre.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    btnguardar.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void buscarfabrica()
        {

        }
    }
}
