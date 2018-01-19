/*	
 *  Implements mouse scroll to increase numbers
 *  Ask about nivel
 * 
 * */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sudokun
{
    public partial class Form1 : Form
    {
        string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        int[,] squares = { { 0, 0 }, { 1, 1 }, { 1, 4 }, { 1, 7 },
                                     { 4, 1 }, { 4, 4 }, { 4, 7 },
                                     { 7, 1 }, { 7, 4 }, { 7, 7 } };
        const int MAXN = 12;

        bool[,] mark_X;
        bool[,] mark_Y;
        bool[,] mark_S;
        int[,] sudoku;
        int[,] solution;                
        int[,] last = new int[12,12];
        
        
        int[,] cant_X;
        int[,] cant_Y;
        int[,] cant_S;
        
        Random random = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);
        public int time = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public int get_time()
        {
            return time;
        }

        int find_box(TextBox TB, ref int x, ref int y)
        {
            int i, j, id;
            for (i = 1; i <= 9; i++)
                for (j = 1; j <= 9; j++)
                {
                    id = (i - 1) * 9 + j;

                    Control[] tb = Controls.Find("textBox_" + id.ToString(), true);
                    if (object.ReferenceEquals(tb[0],TB))
                    {
                        x = i; y = j;
                        return id;
                    }
                }
            return -1;
        }
		
        int get_square(int x, int y)
        {
            int fil, col;

            if (x >= 7) fil = 3;
            else if (x >= 4) fil = 2;
            else fil = 1;

            if (y >= 7) col = 3;
            else if (y >= 4) col = 2;
            else col = 1;

            return ((fil - 1) * 3 + col);
        }
       
        private void Validate(object sender, EventArgs e)	// OK!!!!
        {
            string text = ((TextBox)sender).Text;                          
           
            /* verify that is a valid digit */
            bool isok = false;
            for (int k = 0; k < 10; k++)
            {
                if (text == num[k])
            	{
                	isok = true;
					break;                	
                }
            }
            
            if ( isok == false )
            {          
            	if ( ((TextBox)sender).CanUndo ) ((TextBox)sender).Undo();
            	((TextBox)sender).DeselectAll();
				return;            	
            }
            
            ((TextBox)sender).DeselectAll();
						           
            refresh_board(); 			
            
            if ( is_finished() == true )		// user win
            {
                 WinDialog();                    	
            }                            
        }
       
      	void refresh_board()	//OK!!!!!!!!!!!!!!!!!
        {
            int i, j, id, val;
            
            cant_X = new int[MAXN, MAXN];
            cant_Y = new int[MAXN, MAXN];
            cant_S = new int[MAXN, MAXN];
            sudoku = new int[MAXN, MAXN];           
			
            // count
            for (i = 1; i <= 9; i++)
            {
                for (j = 1; j <= 9; j++)
                {                 
                    id = (i - 1) * 9 + j;

                    Control[] tb = Controls.Find("textBox_" + id.ToString(), true);
                    TextBox tb1 = ((TextBox)tb[0]);
                                        
                    sudoku[i, j] = int.Parse(tb1.Text);
                    val = sudoku[i, j];
                    
                    int x = 0, y = 0;			
					find_box(tb1,ref x,ref y);
					
                    if ( val == 0 )
                    {                    	
                    	continue;
                    }
                    
                    cant_X[x,val]++;
                    cant_Y[y,val]++;
                    cant_S[get_square(x,y),val]++;
                }
            }
            
            // update cells colors
            for (i = 1; i <= 9; i++)
            {
                for (j = 1; j <= 9; j++)
                {                 
                    id = (i - 1) * 9 + j;

                    Control[] tb0 = Controls.Find("textBox_" + id.ToString(), true);
                    TextBox tb2 = ((TextBox)tb0[0]);
                                                            
                    val = sudoku[i, j];
                    
                    int x = 0, y = 0;			
					find_box(tb2,ref x,ref y);
					
                    if ( val == 0 )
                    {                    	
                    	tb2.BackColor = Color.White;
                    	continue;
                    }
                    
                    if (tb2.ReadOnly == true)
                    {
                        continue;
                    }
                    
                    if ( cant_X[x,val] > 1 || cant_Y[y,val] > 1 || cant_S[get_square(x,y),val] > 1 )
                    {
                    	tb2.BackColor = Color.Red;
                    	continue;
                    }
                    else
                    {
                    	tb2.BackColor = Color.SpringGreen;
                    	continue;
                    }
                }
            }
        }      
         
           
        /* BELOW THIS LINE EVERYTHING IS OK */
        
        void actualizar()		//OK
        {
            int i, j, id;
            for ( i = 1; i <= 9; i++ )
                for (j = 1; j <= 9; j++)
                {
                    id = (i - 1) * 9 + j;

                    Control[] tb = Controls.Find("textBox_" + id.ToString(), true);
                    ((TextBox)tb[0]).TextChanged -= Validate;

                    ((TextBox)tb[0]).Text = sudoku[i,j].ToString();
                    ((TextBox)tb[0]).Enabled = true;
                    if (sudoku[i, j] != 0)
                    {
                        ((TextBox)tb[0]).BackColor = Color.Green;
                        ((TextBox)tb[0]).ReadOnly = true;
                    }
                    else
                    {
                        ((TextBox)tb[0]).BackColor = Color.White;
                        ((TextBox)tb[0]).ReadOnly = false;
                    }
                    ((TextBox)tb[0]).TextChanged += Validate;
                }
        }

        void generar()		//OK
        {
            mark_X = new bool[MAXN, MAXN];
            mark_Y = new bool[MAXN, MAXN];
            mark_S = new bool[MAXN, MAXN];            
            solution = new int[MAXN, MAXN];
            last = new int[MAXN,MAXN];
            
            int x, y, val;

            // set random start position and initial value
            x = random.Next(1, 10);
            y = random.Next(1, 10);            
            val = random.Next(1, 10);

            mark_X[x, val] = true;
            mark_Y[y, val] = true;
            mark_S[get_square(x, y), val] = true;
                        
            solution[x, y] = val;                       
        }
        
        bool sirve = false;
        void solve(int x, int y)		//OK
        {
            if (sirve) return;
            if (x > 9) // i have a solution
            {
                sirve = true;
                return;
            }

            if ( solution[x,y] != 0)
            {
                if (y == 9) solve(x + 1, 1);
                else solve(x, y + 1);
            }
            else
            {
                for (int i = 1; i <= 9; i++)
                {
                    bool ok = !mark_X[x,i] && !mark_Y[y,i] && !mark_S[get_square(x, y),i];
                    if (ok)
                    {                        
                        mark_X[x,i] = true;
                        mark_Y[y,i] = true;
                        mark_S[get_square(x, y),i] = true;
                        solution[x,y] = i;
                        
                        if (sirve) return;
                        if (y == 9) solve(x + 1, 1);
                        else solve(x, y + 1);
                        if (sirve) return;
                        
                        mark_X[x,i] = false;
                        mark_Y[y,i] = false;
                        mark_S[get_square(x, y),i] = false;
                        solution[x,y] = 0;
                    }
                }
            }
        }
        
 		void show_n_cells(int N)		//OK
        {           
            int i, x, y, val;
			
            mark_X = new bool[MAXN, MAXN];
            mark_Y = new bool[MAXN, MAXN];
            mark_S = new bool[MAXN, MAXN];            
            sudoku = new int[MAXN, MAXN];
            
            for (i = 0; i < N; i++)
            {
            	//choose a random position to show
                x = random.Next(1, 10);
                y = random.Next(1, 10);  
                
                if ( sudoku[x,y] != 0 ) continue;
                
                sudoku[x,y] = val = solution[x,y];
				                                            
                mark_X[x, val] = true;
                mark_Y[y, val] = true;
                mark_S[get_square(x, y), val] = true;                            
            }
        }
 
        private void button1_Click_1(object sender, EventArgs e)	//OK
        {
            int N = 0;
            if (radioButton1.Checked)
                N = 17;    //dificil
            if (radioButton2.Checked)
                N = random.Next(25, 35);    //medio
            if (radioButton3.Checked)
                N = random.Next(45, 55);    //facil   
                      
            generar();
            sirve = false;
            solve(1,1);
            show_n_cells(N);          
                                
            actualizar();            
            time = 0;
            timer1.Start();           
        }

        bool check_Column(int index)
        {
            bool[] mark = new bool[MAXN];

            for (int i = 1; i <= 9; i++)                              
            {
                int id = (i - 1) * 9 + index;

                Control[] tb = Controls.Find("textBox_" + id.ToString(), true);

                int val = int.Parse(((TextBox)tb[0]).Text);

                if ( val == 0 ) return false;

                if (mark[val]) return false;
                else mark[val] = true;                    
            }
            return true;
        }

        bool check_Row(int index)
        {
            bool[] mark = new bool[MAXN];

            for (int j = 1; j <= 9; j++)
            {
                int id = (index - 1) * 9 + j;

                Control[] tb = Controls.Find("textBox_" + id.ToString(), true);

                int val = int.Parse(((TextBox)tb[0]).Text);
                
                if ( val == 0 ) return false;
                 
                if (mark[val]) return false;
                else mark[val] = true;
            }
            return true;
        }

        bool check_Square(int index)
        {
            bool[] mark = new bool[MAXN];
            int x = squares[index,0];
            int y = squares[index,1];

            for ( int i = x; i <= x + 2; i++ )
                for (int j = y; j <= y + 2; j++)
                {
                    int id = (i - 1) * 9 + j;

                    Control[] tb = Controls.Find("textBox_" + id.ToString(), true);

                    int val = int.Parse(((TextBox)tb[0]).Text);
                     
                    if ( val == 0 ) return false;
                     
                    if (mark[val]) return false;
                    else mark[val] = true;
                }            
            return true;
        }
        
        bool is_finished()
        {         	          
            bool ok = true;

            for (int i = 1; i <= 9; i++)
            {
                if (!check_Column(i))
                {
                    ok = false;                
                }
                
                if (!check_Row(i))
                {
                    ok = false;                    
                }
                
                if (!check_Square(i))
                {
                    ok = false;                 
                }
            }                     
			return ok;            
    	}
        
        
        void WinDialog()
        {
        	timer1.Stop();
        	MessageBox.Show("Felicidades, lo resolviste en "+ time.ToString() + " segundos.");
            Winner form2 = new Winner();
            form2.win_time = time;                
            form2.ShowDialog();

			BestScoresForm bsf = new BestScoresForm();
        	bsf.ShowDialog();        	
        	            
            button1_Click_1(button1, new EventArgs());
        }
        
        private void button2_Click(object sender, EventArgs e)
        {                   	                  
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            label1.Text = "Tiempo: " + time.ToString() + " segundos.";
        }
         
        void Form1Load(object sender, EventArgs e)
        {
 			label1.Text = "Tiempo: " + time.ToString() + " segundos.";
        	button1_Click_1(button1, new EventArgs());           	
        }
        
        void Button3Click(object sender, EventArgs e)
        {
        	sudoku = solution;
        	actualizar();
        	timer1.Stop();
        }               
        
        void Button4Click(object sender, EventArgs e)
        {
        	BestScoresForm bf = new BestScoresForm();
        	bf.ShowDialog();
        }                 
        
       
        
        void UpDownByMouse(object sender, MouseEventArgs e)
        {
        	int val = int.Parse(((TextBox)sender).Text.ToString());
			
        	if ( ((TextBox)sender).ReadOnly == true )
        	{
        		return;
        	}
        	
        	if ( e.Button == MouseButtons.Left )
        	{
        		val++;
        	}
        	
        	if ( e.Button == MouseButtons.Right )
        	{
        		val--;
        	}
        	
        	if ( e.Button == MouseButtons.Middle )
        	{
        		val = 0;
        	}
        	
        	if ( val == 10 ) val = 0;
        	if ( val == -1 ) val = 9;
        	
        	((TextBox)sender).Text = val.ToString();
        	((TextBox)sender).DeselectAll();
        }
        
        void Button5Click(object sender, System.EventArgs e)
        {
        	HelpForm hf = new HelpForm();
        	hf.ShowDialog();
        }
                      
        void AllTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {        	
        	char k = 'a';
        	string key = e.KeyChar.ToString();
			TextBox tb = ((TextBox)sender);        	        	
			if ( tb.ReadOnly == true )
			{
				return;
			}
			
        	for ( k = '0'; k <= '9'; k++ )
        	{
        		if ( k == e.KeyChar )
        		{
        			tb.TextChanged-=Validate;
        			tb.Text = "";        
					tb.TextChanged+=Validate;  					
        			return;
        		}
        	}        	
        }
        
    }
}
