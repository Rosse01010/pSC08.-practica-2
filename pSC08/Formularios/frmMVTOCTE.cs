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
    public partial class frmMVTOCTE : Form
    {
        double PrecioUnit = 0;
        double Descuento = 0;
        double Precio = 0;

        // Asegúrate de reemplazar esto con tu cadena de conexión real
        private string connectionString = "Data Source=tu_servidor;Initial Catalog=tu_base_de_datos;Integrated Security=True";

        public frmMVTOCTE()
        {
            InitializeComponent();
        }

        private void frmMVTOCTE_Load(object sender, EventArgs e)
        {
            this.Text = "Ordenes de Clientes";
            this.KeyPreview = true;

            Estilodgv();
        }

        private void frmMVTOCTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BuscarCliente(txtCliente.Text);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCliente(txtCliente.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ----------------------------------------------------
        // METODOS
        // ----------------------------------------------------
        private void LimpiarFormulario()
        {
            // Limpiar el DataGridView
            dgv.DataSource = null;
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            // Limpiar txtCliente
            txtCliente.Clear();

            // Limpiar el label de nombre del cliente
            lblNombre.Text = "Nombre del Cliente";

            // Limpiar los Labels de totales
            lblPrecioUnitario.Text = "Total Precio Unitario: 0";
            lblDescuento.Text = "Total Descuento: 0";
            lblPrecio.Text = "Total Precio: 0";

            // Reiniciar las variables de suma
            PrecioUnit = 0;
            Descuento = 0;
            Precio = 0;

            // Opcional: Poner el foco en txtCliente
            txtCliente.Focus();

            // Volver a aplicar el estilo al DataGridView
            Estilodgv();
        }

        private void BuscarCliente(string numCliente)
        {
            if (string.IsNullOrWhiteSpace(numCliente))
            {
                MessageBox.Show("Por favor, ingrese un código de cliente.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CompanyName FROM Customers WHERE CustomerID = @CustomerID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", numCliente);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            lblNombre.Text = result.ToString();
                            MostrarOrdenesClientes(numCliente);
                        }
                        else
                        {
                            MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblNombre.Text = "Cliente no encontrado";
                            LimpiarFormulario();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al buscar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MostrarOrdenesClientes(string numCliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                /*
                    string query = @"
                        SELECT 
                            O.OrderID, 
                            O.OrderDate, 
                            OD.ProductID, 
                            P.ProductName, 
                            OD.Quantity, 
                            OD.UnitPrice AS PrecioUnit, 
                            OD.Discount AS Descuento, 
                            (OD.Quantity * OD.UnitPrice * (1 - OD.Discount)) AS Precio
                        FROM 
                            Orders O
                            INNER JOIN [Order Details] OD ON O.OrderID = OD.OrderID
                            INNER JOIN Products P ON OD.ProductID = P.ProductID
                        WHERE 
                            O.CustomerID = @CustomerID
                        ORDER BY 
                            O.OrderDate DESC";
                */

                string query = @"
                    SELECT 
		                    OrderID, OrderDate, ProductID, ProductName, Quantity, UnitPrice AS PrecioUnit, Discount AS Descuento, 
		                    (Quantity * UnitPrice * (1 - Discount)) AS Precio
                    FROM	
		                    dbo.Invoices
                    WHERE 
		                    CustomerID = @CustomerID
                    ORDER BY 
		                    OrderDate DESC
                                ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", numCliente);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgv.Rows.Clear();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            dgv.Rows.Add(
                                row["OrderID"],
                                Convert.ToDateTime(row["OrderDate"]).ToString("dd/MM/yyyy"),
                                row["ProductID"],
                                row["ProductName"],
                                row["Quantity"],
                                Convert.ToDouble(row["PrecioUnit"]).ToString("C2"),
                                Convert.ToDouble(row["Descuento"]).ToString("P2"),
                                Convert.ToDouble(row["Precio"]).ToString("C2")
                            );
                        }

                        CalcularTotales();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al mostrar las órdenes del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CalcularTotales()
        {
            PrecioUnit = 0;
            Descuento = 0;
            Precio = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                PrecioUnit += Convert.ToDouble(row.Cells["Col05"].Value.ToString().Replace("$", ""));
                Descuento += Convert.ToDouble(row.Cells["Col06"].Value.ToString().Replace("%", "")) *
                             Convert.ToDouble(row.Cells["Col05"].Value.ToString().Replace("$", "")) *
                             Convert.ToDouble(row.Cells["Col04"].Value);
                Precio += Convert.ToDouble(row.Cells["Col07"].Value.ToString().Replace("$", ""));
            }

            lblPrecioUnitario.Text = $"Total Precio Unitario: {PrecioUnit:C2}";
            lblDescuento.Text = $"Total Descuento: {Descuento:C2}";
            lblPrecio.Text = $"Total Precio: {Precio:C2}";
        }

        private void Estilodgv()
        {
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersVisible = true;
            this.dgv.RowHeadersVisible = false;

            this.dgv.Columns.Clear();
            this.dgv.Columns.Add("Col00", "Orden");
            this.dgv.Columns.Add("Col01", "Fecha");
            this.dgv.Columns.Add("Col02", "Producto");
            this.dgv.Columns.Add("Col03", "Descripcion");
            this.dgv.Columns.Add("Col04", "Cantidad");
            this.dgv.Columns.Add("Col05", "Precio Unit");
            this.dgv.Columns.Add("Col06", "Descuento");
            this.dgv.Columns.Add("Col07", "Precio");

            DataGridViewColumn column;
            column = dgv.Columns[0]; column.Width = 100;
            column = dgv.Columns[1]; column.Width = 120;
            column = dgv.Columns[2]; column.Width = 100;
            column = dgv.Columns[3]; column.Width = 300;
            column = dgv.Columns[4]; column.Width = 100;
            column = dgv.Columns[5]; column.Width = 100;
            column = dgv.Columns[6]; column.Width = 100;
            column = dgv.Columns[7]; column.Width = 100;

            this.dgv.BorderStyle = BorderStyle.FixedSingle;
            this.dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            this.dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
            this.dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            this.dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
