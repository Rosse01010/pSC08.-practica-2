using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pSC08
{
    public partial class frmPuesto : Form
    {
        Boolean DataExiste;

        public frmPuesto()
        {
            InitializeComponent();
        }

        private void frmPuesto_Load(object sender, EventArgs e)
        {
            this.Text = "Maestro de Puesto de trabajo";
            this.KeyPreview = true;

            DataExiste = false;
        }

        private void frmPuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtPosicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtPosicion.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtNombre.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtPosicion_Leave(object sender, EventArgs e)
        {
            if (txtPosicion.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
            {
                BuscarPosicion(txtPosicion.Text);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtDepartamento.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtDepartamento.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtFabrica.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtDepartamento_Leave(object sender, EventArgs e)
        {
            if (txtDepartamento.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
            {
                lblDepartamento.Text = Busco.BuscarDepartamento(txtDepartamento.Text);
            }
        }

        private void txtFabrica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtFabrica.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    btnGuardar.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtFabrica_Leave(object sender, EventArgs e)
        {
            if (txtFabrica.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
            {
                lblFabrica.Text = Busco.BuscarFabrica(txtFabrica.Text); 
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DataExiste == true)
            {
                ActualizaData();
            }
            else
            {
                InsertarData();
            }

            //BorrarData(txtPosicion.Text);
            //InsertarData();
            LimpiarFormulario();
            txtPosicion.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtPosicion.Focus();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (DataExiste == true)
            {
                DialogResult dialogResult = MessageBox.Show("Estas segura(o) que quieres borrar el registro :(", "ITLA", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    BorrarData(txtPosicion.Text);
                    LimpiarFormulario();

                    txtPosicion.Focus();
                }
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarFormulario()
        {
            txtDepartamento.Clear();
            txtFabrica.Clear();
            txtNombre.Clear();
            txtPosicion.Clear();

            lblDepartamento.Text = "";
            lblFabrica.Text = "";

            DataExiste = false;
        }

        private void BuscarPosicion(string numPuesto)
        {
            DataExiste = false;

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            string stQuery = "     SELECT T1.IDPOSICION, " +
                             "            T1.NOMBREDEPOSICION, " +
                             "            T1.FABRICA, " +
                             "            T1.DEPARTAMENTO, " +
                             "            T2.NOMBREDEPARTAMENTO, " +
                             "            T3.NOMBREDEFABRICA " +
                             "       FROM POSICIONES T1 " +
                             "  LEFT JOIN DEPARTAMENTO T2 ON T1.DEPARTAMENTO = T2.IDDEPARTAMENTO " +
                             "  LEFT JOIN FABRICA      T3 ON T1.FABRICA      = T3.IDFABRICA " +
                             "      WHERE T1.IDPOSICION = '" + numPuesto + "'";

            SqlCommand cmd = new SqlCommand(stQuery, cnx);   // enviamos el script al motor de SQL
            SqlDataReader rcd = cmd.ExecuteReader();  // ejecuta el script que le enviamos

            if (rcd.Read())  // aqui pregunta HasRow = true
            {
                DataExiste = true;

                txtNombre.Text = rcd["NOMBREDEPOSICION"].ToString();
                txtDepartamento.Text = rcd["DEPARTAMENTO"].ToString();
                txtFabrica.Text = rcd["FABRICA"].ToString();
                lblFabrica.Text = rcd["NOMBREDEFABRICA"].ToString();
                lblDepartamento.Text = rcd["NOMBREDEPARTAMENTO"].ToString();
            }
        }

        private void BorrarData(string numPosicion)
        {
            SqlConnection cxn = new SqlConnection(cnn.db);     cxn.Open();
            
            string tQuery = "DELETE FROM POSICIONES WHERE IDPOSICION ='" + numPosicion + "'";

            SqlCommand cdm = new SqlCommand(tQuery, cxn);
            cdm.ExecuteNonQuery();

            cdm.Dispose();
            cxn.Close();
        }

        private void ActualizaData()
        {
            string tQuery = "UPDATE POSICIONES " +
                            "   SET NOMBREDEPOSICION = @A2, " +
                            "       DEPARTAMENTO       = @A3, " +
                            "       FABRICA            = @A4  " +
                            "  FROM POSICIONES " +
                            " WHERE IDPOSICION         = @A1";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cdm = new SqlCommand(tQuery, cxn);

            cdm.Parameters.AddWithValue("@A1", txtPosicion.Text);
            cdm.Parameters.AddWithValue("@A2", txtNombre.Text);
            cdm.Parameters.AddWithValue("@A3", txtDepartamento.Text);
            cdm.Parameters.AddWithValue("@A4", txtFabrica.Text);

            cdm.ExecuteNonQuery();

            cdm.Dispose();
            cxn.Close();
        }

        private void InsertarData()
        {
            string tQuery = "INSERT INTO POSICIONES (IDPOSICION, NOMBREDEPOSICION, DEPARTAMENTO, FABRICA, ESTATUS) " +
                            " VALUES (@A1, @A2, @A3, @A4, 1)";
            
            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cdm = new SqlCommand(tQuery, cxn);

            cdm.Parameters.AddWithValue("@A1", txtPosicion.Text);
            cdm.Parameters.AddWithValue("@A2", txtNombre.Text);
            cdm.Parameters.AddWithValue("@A3", txtDepartamento.Text);
            cdm.Parameters.AddWithValue("@A4", txtFabrica.Text);

            cdm.ExecuteNonQuery();

            cdm.Dispose();
            cxn.Close();
        }

        private void btnDepto_Click(object sender, EventArgs e)
        {

        }

        private void btnFabrica_Click(object sender, EventArgs e)
        {

        }
    }
}
