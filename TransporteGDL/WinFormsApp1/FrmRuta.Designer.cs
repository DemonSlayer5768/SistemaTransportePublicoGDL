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
            listView_Direccion = new ListView();
            label_tittle = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_Buscar = new Button();
            SuspendLayout();
            // 
            // cmb_Estacion_A
            // 
            cmb_Estacion_A.FormattingEnabled = true;
            cmb_Estacion_A.Location = new Point(32, 100);
            cmb_Estacion_A.Name = "cmb_Estacion_A";
            cmb_Estacion_A.Size = new Size(249, 23);
            cmb_Estacion_A.TabIndex = 0;
            // 
            // cmb_Estacion_B
            // 
            cmb_Estacion_B.FormattingEnabled = true;
            cmb_Estacion_B.Location = new Point(316, 100);
            cmb_Estacion_B.Name = "cmb_Estacion_B";
            cmb_Estacion_B.Size = new Size(251, 23);
            cmb_Estacion_B.TabIndex = 1;
            // 
            // listView_Direccion
            // 
            listView_Direccion.Location = new Point(32, 240);
            listView_Direccion.Name = "listView_Direccion";
            listView_Direccion.Size = new Size(535, 358);
            listView_Direccion.TabIndex = 3;
            listView_Direccion.UseCompatibleStateImageBehavior = false;
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
            label2.Location = new Point(32, 72);
            label2.Name = "label2";
            label2.Size = new Size(257, 25);
            label2.TabIndex = 6;
            label2.Text = "Escoge la Estacion de partida";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(316, 72);
            label3.Name = "label3";
            label3.Size = new Size(259, 25);
            label3.TabIndex = 7;
            label3.Text = "Escoge la Estacion de destino";
            // 
            // btn_Buscar
            // 
            btn_Buscar.Location = new Point(164, 152);
            btn_Buscar.Name = "btn_Buscar";
            btn_Buscar.Size = new Size(255, 56);
            btn_Buscar.TabIndex = 10;
            btn_Buscar.Text = "Buscar Ruta";
            btn_Buscar.UseVisualStyleBackColor = true;
            btn_Buscar.Click += btnBuscar_Click;
            // 
            // FrmRuta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(600, 650);
            Controls.Add(btn_Buscar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label_tittle);
            Controls.Add(listView_Direccion);
            Controls.Add(cmb_Estacion_B);
            Controls.Add(cmb_Estacion_A);
            MaximizeBox = false;
            MaximumSize = new Size(616, 689);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(616, 689);
            Name = "FrmRuta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Busqueda Anchura";
            ResumeLayout(false);
            PerformLayout();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ComboBox cmb_Estacion_A;
        private ComboBox cmb_Estacion_B;
        private ListView listView_Direccion;
        private Label label_tittle;
        private Label label2;
        private Label label3;
        private Button btn_Buscar;
    }
}