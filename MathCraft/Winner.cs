using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace Sudokun
{
    public partial class Winner : Form
    {
        public int win_time;
        public Winner()
        {
            win_time = 0;
            InitializeComponent();
        }

        private void Winner_Load(object sender, EventArgs e)
        {
            label3.Text = win_time.ToString() + " segundos";
            
            if ( Registry.CurrentUser.OpenSubKey("Software\\SudokunReinier",false) == null )
            {
            	Registry.CurrentUser.CreateSubKey("Software\\SudokunReinier");	
            }                        
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
         	
        }

        private void button1_Click(object sender, EventArgs e)
        {       
        	if ( textBox1.Text == "" )
        	{
        		MessageBox.Show("Entre su nombre");
        	}
        	else
        	{
	        	Registry.SetValue("HKEY_CURRENT_USER\\Software\\SudokunReinier",textBox1.Text, win_time.ToString());        	
	        	this.Close();
        	}
        }
        
        void TextBox1TextChanged(object sender, EventArgs e)
        {
        	
        }
        
        void TextBox1KeyPress(object sender, KeyPressEventArgs e)
        {       	        	
        	if (e.KeyChar == '\r')
        	{
        		button1_Click(button1, new EventArgs());
        	}
        }
    }
}