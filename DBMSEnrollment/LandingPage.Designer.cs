namespace DBMSEnrollment
{
    partial class LandingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingPage));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdminSignIn = new System.Windows.Forms.Button();
            this.btnUserSignIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 126);
            this.label1.TabIndex = 7;
            this.label1.Text = "ACADEMIC UNIVERSITY \r\nENROLLMENT \r\nSYSTEM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(106, 151);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(382, 317);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnAdminSignIn
            // 
            this.btnAdminSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdminSignIn.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminSignIn.Location = new System.Drawing.Point(49, 500);
            this.btnAdminSignIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdminSignIn.Name = "btnAdminSignIn";
            this.btnAdminSignIn.Size = new System.Drawing.Size(232, 55);
            this.btnAdminSignIn.TabIndex = 15;
            this.btnAdminSignIn.Text = "Admin";
            this.btnAdminSignIn.UseVisualStyleBackColor = true;
            this.btnAdminSignIn.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnUserSignIn
            // 
            this.btnUserSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserSignIn.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserSignIn.Location = new System.Drawing.Point(317, 500);
            this.btnUserSignIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserSignIn.Name = "btnUserSignIn";
            this.btnUserSignIn.Size = new System.Drawing.Size(232, 55);
            this.btnUserSignIn.TabIndex = 15;
            this.btnUserSignIn.Text = "User";
            this.btnUserSignIn.UseVisualStyleBackColor = true;
            this.btnUserSignIn.Click += new System.EventHandler(this.button1_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(601, 600);
            this.Controls.Add(this.btnUserSignIn);
            this.Controls.Add(this.btnAdminSignIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LandingPage";
            this.Text = "Enrollment System";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAdminSignIn;
        private System.Windows.Forms.Button btnUserSignIn;
    }
}