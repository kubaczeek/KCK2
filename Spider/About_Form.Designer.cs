namespace Spider
{
    partial class About_Form
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
            Size = new Size(1200, 800);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReturnButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.imageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ReturnButton
            // 
            this.ReturnButton.BackColor = System.Drawing.Color.Black;
            this.ReturnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReturnButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ReturnButton.Location = new System.Drawing.Point(540, 240);
            this.ReturnButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(102, 41);
            this.ReturnButton.TabIndex = 0;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = false;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label.Location = new System.Drawing.Point(115, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(229, 62);
            this.label.TabIndex = 1;
            this.label.Text = "Project 2 KCK \nJakub Cichocki ";
            this.label.Click += new System.EventHandler(this.label1_Click);
            // 
            // imageBox
            // 
            this.imageBox.BackgroundImage = global::Spider.Properties.Resources.spider;
            this.imageBox.Location = new System.Drawing.Point(520, 86);
            this.imageBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(142, 111);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            this.imageBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // About_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(178)))), ((int)(((byte)(183)))));
            this.ClientSize = new System.Drawing.Size(334, 302);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.ReturnButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "About_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About_Form";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            Size = new Size(1200, 800);
        }

        #endregion

        private Button ReturnButton;
        private Label label;
        private PictureBox imageBox;
    }
}