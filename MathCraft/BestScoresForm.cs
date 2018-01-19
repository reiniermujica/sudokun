/*
 * Created by SharpDevelop.
 * User: Reinier
 * Date: 07/12/2015
 * Time: 07:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using Microsoft.Win32;

namespace Sudokun
{
	/// <summary>
	/// Description of BestScoresForm.
	/// </summary>
	public partial class BestScoresForm : Form
	{
		public BestScoresForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
				
		public void BubbleSort(ref string[,] list, int N)
		{
			for (int i = 0; i < N; i++)
			{
				for (int j = i + 1; j < N; j++ )
				{
					int a = int.Parse(list[i,1]);
					int b = int.Parse(list[j,1]);
					if ( a > b )
					{
						string temp = "";
						
						temp = list[i,0];
						list[i,0] = list[j,0];
						list[j,0] = temp;
						
						temp = list[i,1];
						list[i,1] = list[j,1];
						list[j,1] = temp;
					}
				}
			}
			
		}
		
		void BestScoresFormLoad(object sender, EventArgs e)
		{						
			//get scores from registry						
			RegistryKey rk = Registry.CurrentUser;

            if (Registry.CurrentUser.OpenSubKey("Software\\SudokunReinier") == null)
            {
                Registry.CurrentUser.CreateSubKey("Software\\SudokunReinier");
            }

			rk = rk.OpenSubKey("Software\\SudokunReinier", false );
			
			int cant = rk.ValueCount;
			string[,] values = new string[cant,2];						
			
			int k = 0;
			foreach(string Valuename in rk.GetValueNames())
            {
				if ( Valuename == "" ) continue;
				
				values[k,0] = Valuename.ToString();				
				values[k,1] = rk.GetValue(Valuename).ToString();
				k++;
            }
			
			// sort values by time
			BubbleSort(ref values, k);
			
			string[] scores = new string[cant];
						
			for ( int i = 0; i < cant; i++ )
			{
				string[] data = new string[3];
	           	
				data[0] = (i+1).ToString();
				data[1] = values[i,0];
				data[2] = values[i,1] + " s";
					           					
				ListViewItem lvi1 = new ListViewItem(data);	           	
				listView1.Items.Add(lvi1);
			}
			
						
		
			
		
			
		}
		
		void BestScoresFormKeyPress(object sender, KeyPressEventArgs e)
		{
			MessageBox.Show(e.KeyChar.ToString());
			if (e.KeyChar.ToString() == Keys.Escape.ToString())
				this.Close();
		}
	}
}
