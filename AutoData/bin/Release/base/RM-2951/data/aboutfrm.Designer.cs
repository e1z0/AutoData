namespace mp3talpykla
{
    partial class aboutfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutfrm));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.modalok = new System.Windows.Forms.Button();
            this.m_scroller = new mPower.Scroller();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(5, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(103, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Visit project web site";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // modalok
            // 
            this.modalok.Location = new System.Drawing.Point(508, 375);
            this.modalok.Name = "modalok";
            this.modalok.Size = new System.Drawing.Size(75, 23);
            this.modalok.TabIndex = 12;
            this.modalok.Text = "Okay";
            this.modalok.UseVisualStyleBackColor = true;
            this.modalok.Click += new System.EventHandler(this.modalok_Click_1);
            // 
            // m_scroller
            // 
            this.m_scroller.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_scroller.Interval = 50;
            this.m_scroller.Location = new System.Drawing.Point(-1, 1);
            this.m_scroller.Name = "m_scroller";
            this.m_scroller.Size = new System.Drawing.Size(587, 399);
            this.m_scroller.TabIndex = 9;
            this.m_scroller.TextFont = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.m_scroller.TextToScroll = "";
            this.m_scroller.TopPartSizePercent = 55;
            // 
            // aboutfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 400);
            this.Controls.Add(this.modalok);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.m_scroller);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "aboutfrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.aboutfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private mPower.Scroller m_scroller;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button modalok;
    }
}