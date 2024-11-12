namespace WinFormsApp1
{
    partial class FrmRuta
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
            cmb_Estacion_A = new ComboBox();
            cmb_Estacion_B = new ComboBox();
            cmb_LineasA = new ComboBox();
            listView_Direccion = new ListView();
            label1 = new Label();
            label_tittle = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // cmb_Estacion_A
            // 
            cmb_Estacion_A.FormattingEnabled = true;
            cmb_Estacion_A.Location = new Point(32, 174);
            cmb_Estacion_A.Name = "cmb_Estacion_A";
            cmb_Estacion_A.Size = new Size(229, 23);
            cmb_Estacion_A.TabIndex = 0;
            // 
            // cmb_Estacion_B
            // 
            cmb_Estacion_B.FormattingEnabled = true;
            cmb_Estacion_B.Location = new Point(316, 174);
            cmb_Estacion_B.Name = "cmb_Estacion_B";
            cmb_Estacion_B.Size = new Size(229, 23);
            cmb_Estacion_B.TabIndex = 1;
            // 
            // cmb_LineasA
            // 
            cmb_LineasA.FormattingEnabled = true;
            cmb_LineasA.Location = new Point(164, 101);
            cmb_LineasA.Name = "cmb_LineasA";
            cmb_LineasA.Size = new Size(275, 23);
            cmb_LineasA.TabIndex = 2;
            // 
            // listView_Direccion
            // 
            listView_Direccion.Location = new Point(32, 300);
            listView_Direccion.Name = "listView_Direccion";
            listView_Direccion.Size = new Size(513, 296);
            listView_Direccion.TabIndex = 3;
            listView_Direccion.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(164, 73);
            label1.Name = "label1";
            label1.Size = new Size(163, 25);
            label1.TabIndex = 4;
            label1.Text = "Escoge un a Linea";
            // 
            // label_tittle
            // 
            label_tittle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_tittle.AutoSize = true;
            label_tittle.Font = new Font("Sitka Display", 20.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_tittle.ForeColor = SystemColors.ButtonFace;
            label_tittle.Location = new Point(164, 9);
            label_tittle.Name = "label_tittle";
            label_tittle.Size = new Size(275, 39);
            label_tittle.TabIndex = 5;
            label_tittle.Text = "Busqueda por Anchura\r\n";
            label_tittle.TextAlign = ContentAlignment.TopCenter;
            label_tittle.UseMnemonic = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(32, 146);
            label2.Name = "label2";
            label2.Size = new Size(237, 25);
            label2.TabIndex = 6;
            label2.Text = "Escoge la primera estacion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(316, 146);
            label3.Name = "label3";
            label3.Size = new Size(243, 25);
            label3.TabIndex = 7;
            label3.Text = "Escoge la segunda estacion";
            // 
            // FrmRuta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(580, 638);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label_tittle);
            Controls.Add(label1);
            Controls.Add(listView_Direccion);
            Controls.Add(cmb_LineasA);
            Controls.Add(cmb_Estacion_B);
            Controls.Add(cmb_Estacion_A);
            Name = "FrmRuta";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmb_Estacion_A;
        private ComboBox cmb_Estacion_B;
        private ComboBox cmb_LineasA;
        private ListView listView_Direccion;
        private Label label1;
        private Label label_tittle;
        private Label label2;
        private Label label3;
    }
}