namespace WinFormsApp1
{
    partial class FrmAgregar
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
            lb_tittle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TextB_Nombre = new TextBox();
            TextB_Linea = new TextBox();
            TextB_Cadena = new TextBox();
            TextB__Numerico = new TextBox();
            btn_AgregarEstacion = new Button();
            SuspendLayout();
            // 
            // lb_tittle
            // 
            lb_tittle.AutoSize = true;
            lb_tittle.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_tittle.ForeColor = SystemColors.ControlLightLight;
            lb_tittle.Location = new Point(112, 9);
            lb_tittle.Name = "lb_tittle";
            lb_tittle.Size = new Size(233, 37);
            lb_tittle.TabIndex = 0;
            lb_tittle.Text = "Agregar Estacion";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(23, 108);
            label1.Name = "label1";
            label1.Size = new Size(78, 21);
            label1.TabIndex = 1;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(23, 179);
            label2.Name = "label2";
            label2.Size = new Size(56, 21);
            label2.TabIndex = 2;
            label2.Text = "Linea:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(23, 260);
            label3.Name = "label3";
            label3.Size = new Size(135, 21);
            label3.TabIndex = 3;
            label3.Text = "Campo_Cadena:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(23, 334);
            label4.Name = "label4";
            label4.Size = new Size(154, 21);
            label4.TabIndex = 4;
            label4.Text = "Campo_Numerico:";
            // 
            // TextB_Nombre
            // 
            TextB_Nombre.Location = new Point(193, 110);
            TextB_Nombre.Name = "TextB_Nombre";
            TextB_Nombre.Size = new Size(242, 23);
            TextB_Nombre.TabIndex = 5;
            // 
            // TextB_Linea
            // 
            TextB_Linea.Location = new Point(193, 181);
            TextB_Linea.Name = "TextB_Linea";
            TextB_Linea.Size = new Size(242, 23);
            TextB_Linea.TabIndex = 6;
            // 
            // TextB_Cadena
            // 
            TextB_Cadena.Location = new Point(193, 258);
            TextB_Cadena.Name = "TextB_Cadena";
            TextB_Cadena.Size = new Size(242, 23);
            TextB_Cadena.TabIndex = 7;
            // 
            // TextB__Numerico
            // 
            TextB__Numerico.Location = new Point(193, 332);
            TextB__Numerico.Name = "TextB__Numerico";
            TextB__Numerico.Size = new Size(242, 23);
            TextB__Numerico.TabIndex = 8;
            // 
            // btn_AgregarEstacion
            // 
            btn_AgregarEstacion.Cursor = Cursors.Hand;
            btn_AgregarEstacion.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_AgregarEstacion.Location = new Point(85, 427);
            btn_AgregarEstacion.Name = "btn_AgregarEstacion";
            btn_AgregarEstacion.Size = new Size(280, 67);
            btn_AgregarEstacion.TabIndex = 9;
            btn_AgregarEstacion.Text = "Guardar Estacion";
            btn_AgregarEstacion.UseVisualStyleBackColor = true;
            btn_AgregarEstacion.Click += Btn_AgregarEstacion_Click;
            // 
            // FrmAgregar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(460, 574);
            Controls.Add(btn_AgregarEstacion);
            Controls.Add(TextB__Numerico);
            Controls.Add(TextB_Cadena);
            Controls.Add(TextB_Linea);
            Controls.Add(TextB_Nombre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lb_tittle);
            MaximumSize = new Size(476, 613);
            MinimumSize = new Size(476, 613);
            Name = "FrmAgregar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Estacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_tittle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TextB_Nombre;
        private TextBox TextB_Linea;
        private TextBox TextB_Cadena;
        private TextBox TextB__Numerico;
        private Button btn_AgregarEstacion;
    }
}