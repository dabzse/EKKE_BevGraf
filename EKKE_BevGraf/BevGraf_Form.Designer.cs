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
            this.btn_point = new System.Windows.Forms.Button();
            this.btn_balls = new System.Windows.Forms.Button();
            this.lbl_collision = new System.Windows.Forms.Label();
            this.btn_line = new System.Windows.Forms.Button();
            this.btn_rectangle = new System.Windows.Forms.Button();
            this.btn_chess = new System.Windows.Forms.Button();
            this.btn_circle = new System.Windows.Forms.Button();
            this.btn_ellipse = new System.Windows.Forms.Button();
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
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
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
            // btn_point
            // 
            this.btn_point.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_point.Location = new System.Drawing.Point(891, 12);
            this.btn_point.Name = "btn_point";
            this.btn_point.Size = new System.Drawing.Size(105, 23);
            this.btn_point.TabIndex = 3;
            this.btn_point.Text = "Pontok";
            this.btn_point.UseVisualStyleBackColor = true;
            this.btn_point.Click += new System.EventHandler(this.btn_point_Click);
            // 
            // btn_balls
            // 
            this.btn_balls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_balls.Location = new System.Drawing.Point(891, 41);
            this.btn_balls.Name = "btn_balls";
            this.btn_balls.Size = new System.Drawing.Size(105, 23);
            this.btn_balls.TabIndex = 4;
            this.btn_balls.Text = "Labdák";
            this.btn_balls.UseVisualStyleBackColor = true;
            this.btn_balls.Click += new System.EventHandler(this.btn_balls_Click);
            // 
            // lbl_collision
            // 
            this.lbl_collision.AutoSize = true;
            this.lbl_collision.Location = new System.Drawing.Point(131, 684);
            this.lbl_collision.Name = "lbl_collision";
            this.lbl_collision.Size = new System.Drawing.Size(56, 13);
            this.lbl_collision.TabIndex = 5;
            this.lbl_collision.Text = "Collisions: ";
            // 
            // btn_line
            // 
            this.btn_line.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_line.Location = new System.Drawing.Point(891, 70);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(105, 23);
            this.btn_line.TabIndex = 6;
            this.btn_line.Text = "Vonalak";
            this.btn_line.UseVisualStyleBackColor = true;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // btn_rectangle
            // 
            this.btn_rectangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rectangle.Location = new System.Drawing.Point(891, 99);
            this.btn_rectangle.Name = "btn_rectangle";
            this.btn_rectangle.Size = new System.Drawing.Size(105, 23);
            this.btn_rectangle.TabIndex = 7;
            this.btn_rectangle.Text = "Négyszög";
            this.btn_rectangle.UseVisualStyleBackColor = true;
            this.btn_rectangle.Click += new System.EventHandler(this.btn_rectangle_Click);
            // 
            // btn_chess
            // 
            this.btn_chess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_chess.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_chess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chess.Location = new System.Drawing.Point(891, 128);
            this.btn_chess.Name = "btn_chess";
            this.btn_chess.Size = new System.Drawing.Size(105, 23);
            this.btn_chess.TabIndex = 8;
            this.btn_chess.Text = "SAKK";
            this.btn_chess.UseVisualStyleBackColor = false;
            this.btn_chess.Click += new System.EventHandler(this.btn_chess_Click);
            // 
            // btn_circle
            // 
            this.btn_circle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_circle.AutoEllipsis = true;
            this.btn_circle.Location = new System.Drawing.Point(891, 157);
            this.btn_circle.Name = "btn_circle";
            this.btn_circle.Size = new System.Drawing.Size(105, 23);
            this.btn_circle.TabIndex = 9;
            this.btn_circle.Text = "Kör";
            this.btn_circle.UseVisualStyleBackColor = true;
            this.btn_circle.Click += new System.EventHandler(this.btn_circle_Click);
            // 
            // btn_ellipse
            // 
            this.btn_ellipse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ellipse.AutoEllipsis = true;
            this.btn_ellipse.Location = new System.Drawing.Point(891, 186);
            this.btn_ellipse.Name = "btn_ellipse";
            this.btn_ellipse.Size = new System.Drawing.Size(105, 23);
            this.btn_ellipse.TabIndex = 10;
            this.btn_ellipse.Text = "Ellipszis";
            this.btn_ellipse.UseVisualStyleBackColor = true;
            this.btn_ellipse.Click += new System.EventHandler(this.btn_ellipse_Click);
            // 
            // BevGraf_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btn_ellipse);
            this.Controls.Add(this.btn_circle);
            this.Controls.Add(this.btn_chess);
            this.Controls.Add(this.btn_rectangle);
            this.Controls.Add(this.btn_line);
            this.Controls.Add(this.lbl_collision);
            this.Controls.Add(this.btn_balls);
            this.Controls.Add(this.btn_point);
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
        private System.Windows.Forms.Button btn_point;
        private System.Windows.Forms.Button btn_balls;
        private System.Windows.Forms.Label lbl_collision;
        private System.Windows.Forms.Button btn_line;
        private System.Windows.Forms.Button btn_rectangle;
        private System.Windows.Forms.Button btn_chess;
        private System.Windows.Forms.Button btn_circle;
        private System.Windows.Forms.Button btn_ellipse;
    }
}

