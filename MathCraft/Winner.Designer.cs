namespace Sudokun
{
    partial class Winner
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
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// textBox1
        	// 
        	this.textBox1.AcceptsReturn = true;
        	this.textBox1.Location = new System.Drawing.Point(12, 35);
        	this.textBox1.MaxLength = 10;
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(193, 20);
        	this.textBox1.TabIndex = 0;
        	this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
        	this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
        	this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1KeyPress);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(66, 19);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(85, 13);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Entra tu nombre:";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(66, 57);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(45, 13);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Record:";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(108, 58);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(0, 13);
        	this.label3.TabIndex = 3;
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(69, 74);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(75, 23);
        	this.button1.TabIndex = 4;
        	this.button1.Text = "Guardar";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// Winner
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.SystemColors.HotTrack;
        	this.ClientSize = new System.Drawing.Size(217, 107);
        	this.ControlBox = false;
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.textBox1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "Winner";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Winner";
        	this.TopMost = true;
        	this.Load += new System.EventHandler(this.Winner_Load);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}