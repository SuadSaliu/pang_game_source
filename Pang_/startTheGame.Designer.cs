namespace Pang_
{
    partial class startTheGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startTheGame));
            this.SuspendLayout();
            // 
            // startTheGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(611, 439);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "startTheGame";
            this.Text = "Super Pang";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.startTheGame_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTheGame_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.startTheGame_MouseClick);
            this.MouseEnter += new System.EventHandler(this.startTheGame_MouseEnter);
            this.MouseHover += new System.EventHandler(this.startTheGame_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.startTheGame_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.startTheGame_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

    }
}