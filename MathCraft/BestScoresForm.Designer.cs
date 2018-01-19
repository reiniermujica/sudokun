/*
 * Created by SharpDevelop.
 * User: Reinier
 * Date: 07/12/2015
 * Time: 07:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Sudokun
{
	partial class BestScoresForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(9, 12);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.ShowGroups = false;
			this.listView1.Size = new System.Drawing.Size(275, 225);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Posición";
			this.columnHeader1.Width = 54;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Nombre";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 147;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Tiempo";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 52;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.ForeColor = System.Drawing.Color.DeepPink;
			this.textBox1.Location = new System.Drawing.Point(8, 243);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(275, 165);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "Sudokun v2.0\r\nCopyright © 2015 Reinier César Mujica Hernández\r\n\r\nContáctame en:\r\n" +
			"remujica@uclv.cu\r\nreiniercesar@nauta.cu\r\nreinier.mujica@gmail.com";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// BestScoresForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(295, 418);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.listView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BestScoresForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Acerca de...";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.BestScoresFormLoad);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BestScoresFormKeyPress);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView listView1;
		
		void ListView1SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}
	}
}
