using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sudokun
{
    public partial class Board : UserControl
    {
        const int MAXN = 10;

        string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        int[,] squares = { { 0, 0 }, { 1, 1 }, { 1, 4 }, { 1, 7 },
                                     { 4, 1 }, { 4, 4 }, { 4, 7 },
                                     { 7, 1 }, { 7, 4 }, { 7, 7 } };

        bool[,] mark_X;
        bool[,] mark_Y;
        bool[,] mark_S;
        int[,] sudoku;
        Random random = new Random();
        
        public Board()
        {
            InitializeComponent();
        }

        private void Validate(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;       
            for (int k = 0; k < 10; k++)
                if (text == num[k])
                {
                    ((TextBox)sender).SelectAll();
                    update_user();                    
                    return;
                }

            if ( ((TextBox)sender).CanUndo ) ((TextBox)sender).Undo();
            ((TextBox)sender).SelectAll();        
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

        bool valid(int x, int y, int val)
        {
            return (!mark_X[x, val] && !mark_Y[y, val] && !mark_S[get_square(x, y), val]);
        }

        void update_user()
        {
            int i, j, id, val;

            mark_X = new bool[MAXN, MAXN];
            mark_Y = new bool[MAXN, MAXN];
            mark_S = new bool[MAXN, MAXN];
            sudoku = new int[MAXN, MAXN];

            for (i = 1; i <= 9; i++)
                for (j = 1; j <= 9; j++)
                {
                    id = (i - 1) * 9 + j;

                    Control[] tb = Controls.Find("textBox_" + id.ToString(), true);
                    val = int.Parse(((TextBox)tb[0]).Text);
                  
                    sudoku[i, j] = val;
                    mark_X[i, val] = true;
                    mark_Y[j, val] = true;
                    mark_S[get_square(i, j), val] = true;
                }
        }

    }
}
