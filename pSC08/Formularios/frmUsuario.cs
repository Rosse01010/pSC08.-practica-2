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

using System.Runtime.InteropServices;

namespace pSC08
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;  // activa las teclas de funciones
            this.Text = "Maestro de Usuario";   // aqui le cambiamos el texto cabecera al formulario 
        }

        private void frmUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // pregunta si presionaste la tecla escape
            {
                this.Close(); // cierra este formulario
            }
        }

        // --------------------------------------------------
        // BOTONES
        // --------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarData();

            ActualizaFoto(txtUsuario.Text);
            btnLimpiar.PerformClick();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();  // este metodo limpiara los textbox y los label
            txtUsuario.Focus();   // envia el cursor hacia el textbox txtUsuario
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // cierra este formularo
        }


        // --------------------------------------------------
        // TEXTBOX
        // --------------------------------------------------
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtUsuario.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtNombre.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
            {
                BuscarUsuario(txtUsuario.Text);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4) // pregunta si presionaste la tecla F4
            {
                
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtCorreo.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtCorreo.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtPassword.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtPassword.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtPuesto.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtPuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4) // pregunta si presionaste la tecla F4
            {

            }
        }

        private void txtPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtPuesto.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtFechaNac.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtPuesto_Leave(object sender, EventArgs e)
        {
            if (txtPuesto.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
            {
                
            }
        }

        private void txtFechaNac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtFechaNac.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    btnGuardar.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtFechaNac_Leave(object sender, EventArgs e)
        {
            if (txtFechaNac.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
            {
                int mEdad = CalcularEdad(txtFechaNac.Text);
                lblEdad.Text = mEdad.ToString();
            }
        }

        // ---------------------------------------------------
        // METODOS
        // ---------------------------------------------------
        private int CalcularEdad(string data)
        {
            // DDMMYYYY
            // 10062024   --> fecha
            // 01234567   --> posiciones

            int _day = Convert.ToInt32(data.Substring(0, 2));
            int _month = Convert.ToInt32(data.Substring(2, 2));
            int _year = Convert.ToInt32(data.Substring(4, 4));

            int edad = DateTime.Today.Year - _year;

            if (DateTime.Today.Month < _month)  // verifica que el mes actual es menor al de nacimiento
            {
                --edad;  // le resta 1 a la edad
            }
            else if (DateTime.Today.Month == _month && DateTime.Today.Day < _day) // verifica que el dia actual es menor al de nacimiento
            {
                --edad;  // le resta 1 a la edad
            }

            return edad; // devuelve la edad a lblEdad.Text
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Clear(); // Clear --> limpia el contenido del textbox
            txtNombre.Clear();
            txtCorreo.Clear();
            txtPassword.Clear();
            txtPuesto.Clear();

            lblPuesto.Text = "";  // comilla doble limpia el contenido del label
        }

        private void BuscarUsuario(string nomUsuario)
        {
            SqlConnection cnx = new SqlConnection(cnn.db);
            cnx.Open();

            string stQuery = "SELECT NOMBRECORTO, NOMBRECOMPLETO, CORREO, CLAVE, POSICION " +
                             "  FROM USUARIO " +
                             " WHERE ACTIVO = 'True' " +
                             "   AND NOMBRECORTO = @A1";

            SqlCommand cmd = new SqlCommand(stQuery, cnx);   // enviamos el script al motor de SQL
            cmd.Parameters.AddWithValue("@A1", nomUsuario);  // Declaro la variable y le asigno su valor correspondiente
            SqlDataReader rcd = cmd.ExecuteReader();         // ejecuta el script que le enviamos

            if (rcd.Read())  // aqui pregunta si HasRow = true
            {
                txtUsuario.Text = rcd["NOMBRECORTO"].ToString();
                txtNombre.Text = rcd["NOMBRECOMPLETO"].ToString();
                txtCorreo.Text = rcd["CORREO"].ToString();
                txtPassword.Text = rcd["CLAVE"].ToString();
                txtPuesto.Text = rcd["POSICION"].ToString();

                UsuarioFoto(txtUsuario.Text);
            }
        }

        private void UsuarioFoto(string nomUser)
        {
            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand("SELECT FOTO FROM USUARIO WHERE NOMBRECORTO ='" + nomUser + "'", cxn);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                pictureBox1.Image = ConvertImage.ByteArrayToImage((byte[])rdr["FOTO"]);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                string _imagen = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(_imagen);
            }
        }

        private void ActualizaFoto(string nomUser)
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(pictureBox1.Image);

            //Cursor.Current = Cursor.WaitCursor;

            SqlConnection cxn = new SqlConnection(cnn.db);   cxn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET FOTO = @A1 WHERE NOMBRECORTO ='" + nomUser + "'", cxn);
            cmd.Parameters.AddWithValue("@A1", byteArrayImagen);

            cmd.ExecuteNonQuery();
            cxn.Close();
        }

        private void InsertarData()
        {

        }
    }
}
