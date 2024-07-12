using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTextSharp.text.pdf;   // libreria a utilizar para el codigo de barra

using System.Data.SqlClient;

namespace pSC08
{
    public partial class frmProductos : Form
    {
        Boolean DataExiste;

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            this.Text = "Maestro de Producto";
            this.KeyPreview = true;

            DataExiste = false;
        }

        private void frmProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtProducto.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtNombre.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtProducto_Leave(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
            {
                BuscarData(txtProducto.Text);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtCantidad.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtCantidad.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtCosto.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtCosto.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtPrecio.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtPrecio.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtImpuesto.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtImpuesto.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtBarCode.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtBarCode.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    btnGuardar.Focus();  // mueve el cursor hacia el textbox txtNombre
                }
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            frmVENPROD frm = new frmVENPROD();
            DialogResult res = frm.ShowDialog();

            if (frm.tf == true)
            {
                txtProducto.Text = frm.varf1;

                BuscarData(txtProducto.Text);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
            {
                if (txtNombre.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    if (txtCosto.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                    {
                        if (txtPrecio.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                        {
                            if (txtImpuesto.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                            {
                                if (txtBarCode.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                                {
                                    if (DataExiste == true)
                                    {
                                        ActualizaData();
                                        ActualizaImagenProducto(txtProducto.Text);
                                    }
                                    else
                                    {
                                        InsertarData();
                                        ActualizaImagenProducto(txtProducto.Text);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            LimpiarFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (DataExiste == true)
            {
                DialogResult dialogResult = MessageBox.Show("Estas segura(o) que quieres borrar el registro :(", "ITLA", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    BorrarData(txtProducto.Text);
                    LimpiarFormulario();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string _imagen = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(_imagen);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtCantidad.Clear();
            txtCosto.Clear();
            txtPrecio.Clear();
            txtImpuesto.Clear();
            txtBarCode.Clear();

            DataExiste = false;

            txtProducto.Focus();
        }

        private void BorrarData(string numProducto)
        {
            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();

            string tQuery = "DELETE FROM PRODUCTOS WHERE ITEM ='" + numProducto + "'";

            SqlCommand cdm = new SqlCommand(tQuery, cxn);
            cdm.ExecuteNonQuery();

            cdm.Dispose();
            cxn.Close();
        }

        private void BuscarData(string numProducto)
        {
            DataExiste = false;

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            string stQuery = "SELECT DESCRIPCION, " +
                             "       CANTIDADENEXISTENCIA, " +
                             "       COSTO, " +
                             "       PRECIODEVENTA, " +
                             "       IMPUESTO, " +
                             "       BARCODE " +
                             "  FROM PRODUCTOS " +
                             " WHERE ITEM ='" + numProducto + 
                             "'  AND ESTATUSPRODUCTO = 1";

            SqlCommand cmd = new SqlCommand(stQuery, cnx);   // enviamos el script al motor de SQL
            SqlDataReader rcd = cmd.ExecuteReader();  // ejecuta el script que le enviamos

            if (rcd.Read())  // aqui pregunta HasRow = true
            {
                DataExiste = true;

                txtNombre.Text = rcd["DESCRIPCION"].ToString();
                txtCantidad.Text = rcd["CANTIDADENEXISTENCIA"].ToString();
                txtCosto.Text = rcd["COSTO"].ToString();
                txtPrecio.Text = rcd["PRECIODEVENTA"].ToString();
                txtImpuesto.Text = rcd["IMPUESTO"].ToString();
                txtBarCode.Text = rcd["BARCODE"].ToString();

                MostrarImagenProducto(numProducto);
            }
        }

        private void MostrarImagenProducto(string numProducto)
        {
            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand("SELECT IMAGEN FROM PRODUCTOS WHERE ITEM ='" + numProducto + "'", cxn);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                try
                {
                    pictureBox1.Image = ConvertImage.ByteArrayToImage((byte[])rdr["IMAGEN"]);
                }
                catch
                {

                }
            }
        }

        private void ActualizaImagenProducto(string numProducto)
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(pictureBox1.Image);

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE PRODUCTOS SET IMAGEN = @A1 WHERE ITEM ='" + numProducto + "'", cxn);
            cmd.Parameters.AddWithValue("@A1", byteArrayImagen);

            cmd.ExecuteNonQuery();
            cxn.Close();
        }

        private void InsertarData()
        {
            string tQuery = "INSERT INTO PRODCUTOS (" +
                            "ITEM, DESCRIPCION, CANTIDADENEXISTENCIA, COSTO, PRECIODEVENTA, IMPUESTO, BARCODE, ESTATUSPRODUCTO " +
                            ")    VALUES (@A1, @A2, @A3, @A4, @A5, @A6, @A7, 1)";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cdm = new SqlCommand(tQuery, cxn);

            cdm.Parameters.AddWithValue("@A1", txtProducto.Text);
            cdm.Parameters.AddWithValue("@A2", txtNombre.Text);
            cdm.Parameters.AddWithValue("@A3", txtCantidad.Text);
            cdm.Parameters.AddWithValue("@A4", txtCosto.Text);
            cdm.Parameters.AddWithValue("@A5", txtPrecio.Text);
            cdm.Parameters.AddWithValue("@A6", txtImpuesto.Text);
            cdm.Parameters.AddWithValue("@A7", txtBarCode.Text);

            cdm.ExecuteNonQuery();

            cdm.Dispose();
            cxn.Close();
        }

        private void ActualizaData()
        {
            string tQuery = "UPDATE PRODUCTOS " +
                            "   SET DESCRIPCION          = @A2, " +
                            "       CANTIDADENEXISTENCIA = @A3, " +
                            "       COSTO                = @A4, " +
                            "       PRECIODEVENTA        = @A5, " +
                            "       IMPUESTO             = @A6, " +
                            "       BARCODE              = @A7  " +
                            "  FROM PRODUCTOS " +
                            " WHERE ITEM = @A1";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cdm = new SqlCommand(tQuery, cxn);

            cdm.Parameters.AddWithValue("@A1", txtProducto.Text);
            cdm.Parameters.AddWithValue("@A2", txtNombre.Text);
            cdm.Parameters.AddWithValue("@A3", txtCantidad.Text);
            cdm.Parameters.AddWithValue("@A4", txtCosto.Text);
            cdm.Parameters.AddWithValue("@A5", txtPrecio.Text);
            cdm.Parameters.AddWithValue("@A6", txtImpuesto.Text);
            cdm.Parameters.AddWithValue("@A7", txtBarCode.Text);

            cdm.ExecuteNonQuery();

            cdm.Dispose();
            cxn.Close();
        }



        public enum Code128SubTypes
        {
            CODE128 = iTextSharp.text.pdf.Barcode.CODE128,
            CODE128_RAW = iTextSharp.text.pdf.Barcode.CODE128_RAW,
            CODE128_UCC = iTextSharp.text.pdf.Barcode.CODE128_UCC,
        }

        public static Bitmap Code128(string _code, Code128SubTypes codeType = Code128SubTypes.CODE128, bool PrintTextInCode = false, float Height = 0, 
            bool GenerateChecksum = true, bool ChecksumText = true)
        {
            if (_code.Trim() == "")
            {
                return null;
            }
            else
            {
                Barcode128 barcode = new Barcode128();

                barcode.CodeType = (int)codeType;
                barcode.StartStopText = true;
                barcode.GenerateChecksum = GenerateChecksum;
                barcode.ChecksumText = ChecksumText;
                if (Height != 0) barcode.BarHeight = Height;
                barcode.Code = _code;
                try
                {
                    System.Drawing.Bitmap bm = new System.Drawing.Bitmap(barcode.CreateDrawingImage
                        (System.Drawing.Color.Black, System.Drawing.Color.White));
                    if (PrintTextInCode == false)
                    {
                        return bm;
                    }
                    else
                    {
                        Bitmap bmT;
                        bmT = new Bitmap(bm.Width, bm.Height + 14);
                        Graphics g = Graphics.FromImage(bmT);
                        g.FillRectangle(new SolidBrush(Color.White), 0, 0, bm.Width, bm.Height + 14);

                        Font drawFont = new Font("Arial", 8);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);

                        SizeF stringSize = new SizeF();
                        stringSize = g.MeasureString(_code, drawFont);
                        float xCenter = (bm.Width - stringSize.Width) / 2;
                        float x = xCenter;
                        float y = bm.Height;

                        StringFormat drawFormat = new StringFormat();
                        drawFormat.FormatFlags = StringFormatFlags.NoWrap;

                        g.DrawImage(bm, 0, 0);
                        g.DrawString(_code, drawFont, drawBrush, x, y, drawFormat);

                        return bmT;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Codigo De Barra Code128. Desc:" + ex.Message);
                }
            }
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
