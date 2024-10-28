namespace WinFormsApp1
{
    partial class FrmEliminar
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
            cmb_Lineas = new ComboBox();
            cmb_Estaciones = new ComboBox();
            btn_Eliminar = new Button();
            SuspendLayout();
            // 
            // lb_tittle
            // 
            lb_tittle.AutoSize = true;
            lb_tittle.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_tittle.ForeColor = SystemColors.ControlLightLight;
            lb_tittle.Location = new Point(139, 9);
            lb_tittle.Name = "lb_tittle";
            lb_tittle.Size = new Size(235, 37);
            lb_tittle.TabIndex = 1;
            lb_tittle.Text = "Eliminar Estacion";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 149);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(275, 101);
            label2.Name = "label2";
            label2.Size = new Size(225, 30);
            label2.TabIndex = 3;
            label2.Text = "Ingresa una Estacion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(12, 101);
            label3.Name = "label3";
            label3.Size = new Size(194, 30);
            label3.TabIndex = 4;
            label3.Text = "Ingresa una Linea";
            // 
            // cmb_Lineas
            // 
            cmb_Lineas.FormattingEnabled = true;
            cmb_Lineas.Location = new Point(12, 141);
            cmb_Lineas.Name = "cmb_Lineas";
            cmb_Lineas.Size = new Size(194, 23);
            cmb_Lineas.TabIndex = 6;
            // 
            // cmb_Estaciones
            // 
            cmb_Estaciones.FormattingEnabled = true;
            cmb_Estaciones.Location = new Point(275, 141);
            cmb_Estaciones.Name = "cmb_Estaciones";
            cmb_Estaciones.Size = new Size(225, 23);
            cmb_Estaciones.TabIndex = 7;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Eliminar.Location = new Point(96, 266);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new Size(278, 46);
            btn_Eliminar.TabIndex = 8;
            btn_Eliminar.Text = "Eliminar";
            btn_Eliminar.UseVisualStyleBackColor = true;
            btn_Eliminar.Click += btn_Eliminar_Click;
            // 
            // FrmEliminar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(521, 366);
            Controls.Add(btn_Eliminar);
            Controls.Add(cmb_Estaciones);
            Controls.Add(cmb_Lineas);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lb_tittle);
            MaximizeBox = false;
            MaximumSize = new Size(537, 405);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(537, 405);
            Name = "FrmEliminar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb_tittle;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmb_Lineas;
        private ComboBox cmb_Estaciones;
        private Button btn_Eliminar;
    }
}