using System.Windows.Forms;

namespace My_FrmInicio
{
    partial class FrmInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_tittle = new Label();
            listBox_Estaciones = new ListBox();
            lb_Buscar = new Label();
            cmb_Lineas = new ComboBox();
            btn_Estaciones = new Button();
            menuStrip1 = new MenuStrip();
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            agregarEstacionToolStripMenuItem = new ToolStripMenuItem();
            eliminarEstacionToolStripMenuItem = new ToolStripMenuItem();
            pB_Refresh = new PictureBox();
            pB_Image = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pB_Refresh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pB_Image).BeginInit();
            SuspendLayout();
            // 
            // label_tittle
            // 
            label_tittle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_tittle.AutoSize = true;
            label_tittle.Font = new Font("Sitka Display", 20.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_tittle.ForeColor = SystemColors.ButtonFace;
            label_tittle.Location = new Point(28, 38);
            label_tittle.Name = "label_tittle";
            label_tittle.Size = new Size(769, 78);
            label_tittle.TabIndex = 1;
            label_tittle.Text = "SISTEMA DE TRASNPORTE PUBLICO MASIVO  DE GUADALAJARA\r\n\r\n";
            label_tittle.TextAlign = ContentAlignment.TopCenter;
            label_tittle.UseMnemonic = false;
            // 
            // listBox_Estaciones
            // 
            listBox_Estaciones.FormattingEnabled = true;
            listBox_Estaciones.ItemHeight = 15;
            listBox_Estaciones.Location = new Point(28, 217);
            listBox_Estaciones.Name = "listBox_Estaciones";
            listBox_Estaciones.Size = new Size(431, 439);
            listBox_Estaciones.TabIndex = 0;
            // 
            // lb_Buscar
            // 
            lb_Buscar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lb_Buscar.AutoSize = true;
            lb_Buscar.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_Buscar.ForeColor = SystemColors.Control;
            lb_Buscar.Location = new Point(28, 116);
            lb_Buscar.Name = "lb_Buscar";
            lb_Buscar.Size = new Size(242, 24);
            lb_Buscar.TabIndex = 0;
            lb_Buscar.Text = "Selecciona una Estacion";
            lb_Buscar.TextAlign = ContentAlignment.TopCenter;
            // 
            // cmb_Lineas
            // 
            cmb_Lineas.FormattingEnabled = true;
            cmb_Lineas.Location = new Point(28, 153);
            cmb_Lineas.Name = "cmb_Lineas";
            cmb_Lineas.Size = new Size(242, 23);
            cmb_Lineas.TabIndex = 4;
            // 
            // btn_Estaciones
            // 
            btn_Estaciones.BackColor = Color.White;
            btn_Estaciones.Cursor = Cursors.Hand;
            btn_Estaciones.Location = new Point(310, 152);
            btn_Estaciones.Name = "btn_Estaciones";
            btn_Estaciones.Size = new Size(149, 23);
            btn_Estaciones.TabIndex = 6;
            btn_Estaciones.Text = "Buscar Estaciones";
            btn_Estaciones.UseVisualStyleBackColor = false;
            btn_Estaciones.Click += btn_Estaciones_Click_1;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { opcionesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(919, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarEstacionToolStripMenuItem, eliminarEstacionToolStripMenuItem });
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(69, 20);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // agregarEstacionToolStripMenuItem
            // 
            agregarEstacionToolStripMenuItem.Name = "agregarEstacionToolStripMenuItem";
            agregarEstacionToolStripMenuItem.Size = new Size(180, 22);
            agregarEstacionToolStripMenuItem.Text = "Agregar Estacion";
            agregarEstacionToolStripMenuItem.Click += agregarEstacionToolStripMenuItem_Click;
            // 
            // eliminarEstacionToolStripMenuItem
            // 
            eliminarEstacionToolStripMenuItem.Name = "eliminarEstacionToolStripMenuItem";
            eliminarEstacionToolStripMenuItem.Size = new Size(180, 22);
            eliminarEstacionToolStripMenuItem.Text = "Eliminar Estacion";
            eliminarEstacionToolStripMenuItem.Click += eliminarEstacionToolStripMenuItem_Click;
            // 
            // pB_Refresh
            // 
            pB_Refresh.Cursor = Cursors.Hand;
            pB_Refresh.Image = WinFormsApp1.Properties.Resources.refresh;
            pB_Refresh.Location = new Point(276, 147);
            pB_Refresh.Name = "pB_Refresh";
            pB_Refresh.Size = new Size(31, 29);
            pB_Refresh.SizeMode = PictureBoxSizeMode.Zoom;
            pB_Refresh.TabIndex = 10;
            pB_Refresh.TabStop = false;
            pB_Refresh.Click += pB_Refresh_Click;
            // 
            // pB_Image
            // 
            pB_Image.Image = WinFormsApp1.Properties.Resources.MapaTren;
            pB_Image.Location = new Point(478, 217);
            pB_Image.Name = "pB_Image";
            pB_Image.Size = new Size(429, 438);
            pB_Image.SizeMode = PictureBoxSizeMode.Zoom;
            pB_Image.TabIndex = 11;
            pB_Image.TabStop = false;
            // 
            // FrmInicio
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(919, 667);
            Controls.Add(pB_Image);
            Controls.Add(pB_Refresh);
            Controls.Add(btn_Estaciones);
            Controls.Add(listBox_Estaciones);
            Controls.Add(cmb_Lineas);
            Controls.Add(lb_Buscar);
            Controls.Add(label_tittle);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(935, 706);
            MinimizeBox = false;
            MinimumSize = new Size(935, 706);
            Name = "FrmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "STPMG";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pB_Refresh).EndInit();
            ((System.ComponentModel.ISupportInitialize)pB_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_tittle;
        private ListBox listBox_Estaciones;
        private Label lb_Buscar;
        private ComboBox cmb_Lineas;
        private Button btn_Estaciones;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private ToolStripMenuItem agregarEstacionToolStripMenuItem;
        private ToolStripMenuItem eliminarEstacionToolStripMenuItem;
        private PictureBox pB_Refresh;
        private PictureBox pB_Image;
    }
}
