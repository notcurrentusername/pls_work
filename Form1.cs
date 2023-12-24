using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace vis9
{
    public partial class Form1 : Form
    {
        string f = "";
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int[][] matrix = new int[][]
                {
                    new int[] { 100, 2, 3 },
                    new int[] { 4, 50, 6 },
                    new int[] { 7, 8, 9 }
                };
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    textBox1.Text+=matrix[i][j]+"\t";
                }
                textBox1.Text +="\r\n";
            }


            MSearch matrixSearch = new MSearch(matrix);
            matrixSearch.FindMaxSumMatrix();
            int maxSum = matrixSearch.GetMaxSum();
            int maxSumRowIndex = matrixSearch.GetMaxSumRowIndex();
            maxSumRowIndex++;
            textBox2.Text += "Максимальная сумма: " + maxSum + "\r\n";
            textBox2.Text += "В строке: "+maxSumRowIndex+"\r\n";
            
        }
        int i = 0;
        int j = 51;

        private void button2_Click(object sender, EventArgs e)
        {
            
            Thread th1 = new Thread(Print1);
            Thread th2 = new Thread(Print2);
            th1.Start();
            th2.Start();
            


            void Print1()
            {
                while (i < 5001)
                {
                    
                    if (i % 5 == 0)
                    {
                        f += "В строке:1 " + i + " \r\n";
                        
                        i++;
                    }
                    else i++;
                }
                
            }
            void Print2()
            {
                while (j < 10001)
                {
                    if (j % 5 == 0)
                    {
                        f += "В строке:2 " + j + " \r\n";
                        j++;
                       
                    }
                    else j++;
                }

            }
            textBox2.Text += f;
            f = "";
            i = 0; 
            j = 50;
        }
        static bool flag = true;
        private void button3_Click(object sender, EventArgs e)
        {
            
            Thread th1 = new Thread(Print1);
            Thread th2 = new Thread(Print2);
            th1.Start();
            th2.Start();
            

            void Print1()
            {
                while (i <= 51)
                {
                    while (!flag) { }
                    if (i % 5 == 0)
                    {
                        f += "В строке:1 " + i + " \r\n";
                        i++;
                    }
                    else i++;
                    if (i == 51) flag = false;
                }
                
            }
            void Print2()
                {
                    while (j < 1000)
                    {
                        while (flag) { }
                        if (j % 5 == 0)
                        {
                            f += "В строке:2 " + j + " \r\n";
                            j++;

                        }
                        else j++;
                        
                    }
                }
            textBox1.Text += f;
        }
    }
}
