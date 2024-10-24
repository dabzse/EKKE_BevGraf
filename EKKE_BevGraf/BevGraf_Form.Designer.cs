namespace EKKE_BevGraf
{
    partial class BevGraf_Form
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.lbl_coordinates = new System.Windows.Forms.Label();
            this.lbl_mm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.BackColor = System.Drawing.SystemColors.Window;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(885, 666);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // lbl_coordinates
            // 
            this.lbl_coordinates.AutoSize = true;
            this.lbl_coordinates.Location = new System.Drawing.Point(12, 684);
            this.lbl_coordinates.Name = "lbl_coordinates";
            this.lbl_coordinates.Size = new System.Drawing.Size(62, 13);
            this.lbl_coordinates.TabIndex = 1;
            this.lbl_coordinates.Text = "coordinates";
            // 
            // lbl_mm
            // 
            this.lbl_mm.AutoSize = true;
            this.lbl_mm.Location = new System.Drawing.Point(12, 707);
            this.lbl_mm.Name = "lbl_mm";
            this.lbl_mm.Size = new System.Drawing.Size(45, 13);
            this.lbl_mm.TabIndex = 2;
            this.lbl_mm.Text = "dim: mm";
            // 
            // BevGraf_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.lbl_mm);
            this.Controls.Add(this.lbl_coordinates);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BevGraf_Form";
            this.Text = "EKKE - bevezetés a számítógépi grafikába (ZKLSTP, UQHGWH)";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label lbl_coordinates;
        private System.Windows.Forms.Label lbl_mm;
    }
}

