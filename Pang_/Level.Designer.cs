namespace Pang_
{
    partial class Level
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbImage1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbImage1
            // 
            this.pbImage1.BackColor = System.Drawing.Color.White;
            this.pbImage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImage1.Location = new System.Drawing.Point(1, -2);
            this.pbImage1.Name = "pbImage1";
            this.pbImage1.Size = new System.Drawing.Size(328, 195);
            this.pbImage1.TabIndex = 0;
            this.pbImage1.TabStop = false;
            this.pbImage1.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImage1_Paint);
            // 
            // Level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 186);
            this.ControlBox = false;
            this.Controls.Add(this.pbImage1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Level";
            this.Text = "Super Pang";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage1;
        private System.Windows.Forms.Timer timer1;

    }
}