
namespace pSC08
{
    partial class frmPuesto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFabrica = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPosicion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFabrica = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.btnDepto = new System.Windows.Forms.Button();
            this.btnFabrica = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::pSC08.Properties.Resources.exit;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(944, 8);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(144, 88);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::pSC08.Properties.Resources.editdelete;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBorrar.Location = new System.Drawing.Point(800, 8);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(144, 88);
            this.btnBorrar.TabIndex = 6;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::pSC08.Properties.Resources.filenew;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLimpiar.Location = new System.Drawing.Point(656, 8);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(144, 88);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::pSC08.Properties.Resources.filesave;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(512, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(144, 88);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 88);
            this.label1.TabIndex = 9;
            this.label1.Text = " Puesto de trabajo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFabrica
            // 
            this.txtFabrica.Location = new System.Drawing.Point(288, 256);
            this.txtFabrica.Multiline = true;
            this.txtFabrica.Name = "txtFabrica";
            this.txtFabrica.Size = new System.Drawing.Size(120, 32);
            this.txtFabrica.TabIndex = 3;
            this.txtFabrica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFabrica_KeyPress);
            this.txtFabrica.Leave += new System.EventHandler(this.txtFabrica_Leave);
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(288, 216);
            this.txtDepartamento.Multiline = true;
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(120, 32);
            this.txtDepartamento.TabIndex = 2;
            this.txtDepartamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepartamento_KeyPress);
            this.txtDepartamento.Leave += new System.EventHandler(this.txtDepartamento_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(288, 176);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(504, 32);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtPosicion
            // 
            this.txtPosicion.Location = new System.Drawing.Point(288, 136);
            this.txtPosicion.Multiline = true;
            this.txtPosicion.Name = "txtPosicion";
            this.txtPosicion.Size = new System.Drawing.Size(120, 32);
            this.txtPosicion.TabIndex = 0;
            this.txtPosicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPosicion_KeyPress);
            this.txtPosicion.Leave += new System.EventHandler(this.txtPosicion_Leave);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PowderBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 32);
            this.label5.TabIndex = 21;
            this.label5.Text = " Fabrica";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.PowderBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = " Departamento";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PowderBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 32);
            this.label3.TabIndex = 19;
            this.label3.Text = " Nombre de la posicion";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 32);
            this.label2.TabIndex = 18;
            this.label2.Text = " ID Posicion";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFabrica
            // 
            this.lblFabrica.BackColor = System.Drawing.Color.PowderBlue;
            this.lblFabrica.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFabrica.Location = new System.Drawing.Point(472, 256);
            this.lblFabrica.Name = "lblFabrica";
            this.lblFabrica.Size = new System.Drawing.Size(320, 32);
            this.lblFabrica.TabIndex = 22;
            this.lblFabrica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.BackColor = System.Drawing.Color.PowderBlue;
            this.lblDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartamento.Location = new System.Drawing.Point(472, 216);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(320, 32);
            this.lblDepartamento.TabIndex = 23;
            this.lblDepartamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDepto
            // 
            this.btnDepto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDepto.Location = new System.Drawing.Point(416, 216);
            this.btnDepto.Name = "btnDepto";
            this.btnDepto.Size = new System.Drawing.Size(48, 32);
            this.btnDepto.TabIndex = 24;
            this.btnDepto.Text = "...";
            this.btnDepto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepto.UseVisualStyleBackColor = true;
            this.btnDepto.Click += new System.EventHandler(this.btnDepto_Click);
            // 
            // btnFabrica
            // 
            this.btnFabrica.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFabrica.Location = new System.Drawing.Point(416, 256);
            this.btnFabrica.Name = "btnFabrica";
            this.btnFabrica.Size = new System.Drawing.Size(48, 32);
            this.btnFabrica.TabIndex = 25;
            this.btnFabrica.Text = "...";
            this.btnFabrica.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFabrica.UseVisualStyleBackColor = true;
            this.btnFabrica.Click += new System.EventHandler(this.btnFabrica_Click);
            // 
            // frmPuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 331);
            this.Controls.Add(this.btnFabrica);
            this.Controls.Add(this.btnDepto);
            this.Controls.Add(this.lblDepartamento);
            this.Controls.Add(this.lblFabrica);
            this.Controls.Add(this.txtFabrica);
            this.Controls.Add(this.txtDepartamento);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtPosicion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.Name = "frmPuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPuesto";
            this.Load += new System.EventHandler(this.frmPuesto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPuesto_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFabrica;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPosicion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFabrica;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.Button btnDepto;
        private System.Windows.Forms.Button btnFabrica;
    }
}