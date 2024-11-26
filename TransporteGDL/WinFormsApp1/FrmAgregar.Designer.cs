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
            TextB_Nombre = new TextBox();
            TextB_Linea = new TextBox();
            btn_AgregarEstacion = new Button();
            TextB_VecinoIzq = new TextBox();
            label5 = new Label();
            TextB_VecinoDer = new TextBox();
            label6 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // lb_tittle
            // 
            lb_tittle.AutoSize = true;
            lb_tittle.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_tittle.ForeColor = SystemColors.ControlLightLight;
            lb_tittle.Location = new Point(108, 32);
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
            label1.Location = new Point(23, 141);
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
            label2.Location = new Point(23, 181);
            label2.Name = "label2";
            label2.Size = new Size(56, 21);
            label2.TabIndex = 2;
            label2.Text = "Linea:";
            // 
            // TextB_Nombre
            // 
            TextB_Nombre.Location = new Point(193, 143);
            TextB_Nombre.Name = "TextB_Nombre";
            TextB_Nombre.Size = new Size(242, 23);
            TextB_Nombre.TabIndex = 5;
            // 
            // TextB_Linea
            // 
            TextB_Linea.Location = new Point(193, 183);
            TextB_Linea.Name = "TextB_Linea";
            TextB_Linea.Size = new Size(242, 23);
            TextB_Linea.TabIndex = 6;
            // 
            // btn_AgregarEstacion
            // 
            btn_AgregarEstacion.Cursor = Cursors.Hand;
            btn_AgregarEstacion.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_AgregarEstacion.Location = new Point(90, 439);
            btn_AgregarEstacion.Name = "btn_AgregarEstacion";
            btn_AgregarEstacion.Size = new Size(280, 67);
            btn_AgregarEstacion.TabIndex = 9;
            btn_AgregarEstacion.Text = "Guardar Estacion";
            btn_AgregarEstacion.UseVisualStyleBackColor = true;
            btn_AgregarEstacion.Click += Btn_AgregarEstacion_Click;
            // btn_AgregarEstacion.Click += Btn_AgregarEstacion_Click;
            // 
            // TextB_VecinoIzq
            // 
            TextB_VecinoIzq.Location = new Point(193, 304);
            TextB_VecinoIzq.Name = "TextB_VecinoIzq";
            TextB_VecinoIzq.Size = new Size(242, 23);
            TextB_VecinoIzq.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(23, 306);
            label5.Name = "label5";
            label5.Size = new Size(95, 21);
            label5.TabIndex = 10;
            label5.Text = "Vecino izq:";
            // 
            // TextB_VecinoDer
            // 
            TextB_VecinoDer.Location = new Point(194, 345);
            TextB_VecinoDer.Name = "TextB_VecinoDer";
            TextB_VecinoDer.Size = new Size(242, 23);
            TextB_VecinoDer.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(24, 347);
            label6.Name = "label6";
            label6.Size = new Size(98, 21);
            label6.TabIndex = 12;
            label6.Text = "Vecino der:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(108, 231);
            label3.Name = "label3";
            label3.Size = new Size(226, 37);
            label3.TabIndex = 14;
            label3.Text = "Agregar Vecinos";
            // 
            // FrmAgregar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(460, 574);
            Controls.Add(label3);
            Controls.Add(TextB_VecinoDer);
            Controls.Add(label6);
            Controls.Add(TextB_VecinoIzq);
            Controls.Add(label5);
            Controls.Add(btn_AgregarEstacion);
            Controls.Add(TextB_Linea);
            Controls.Add(TextB_Nombre);
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
        private TextBox TextB_Nombre;
        private TextBox TextB_Linea;
        private Button btn_AgregarEstacion;
        private TextBox TextB_VecinoIzq;
        private Label label5;
        private TextBox TextB_VecinoDer;
        private Label label6;
        private Label label3;
    }
}