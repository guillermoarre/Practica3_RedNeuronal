using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3_Agentes
{
    public partial class Form1 : Form
    {
        int m1, n1;
        int m2, n2;
        int entradas;
        int[] Mat;
        double Umbral;
        double[] Acumulador;
        
        public Form1()
        {
            InitializeComponent();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            dataGrid1.Columns.Clear();
            dataGrid1.Rows.Clear();
            dataGrid2.Columns.Clear();
            dataGrid2.Rows.Clear();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            int i, j;
            Mat = new int[m1];
            Acumulador = new double[m2];
            //Recolecta valores
            try
            {
                Umbral = double.Parse(tbx2.Text);
                for (i = 0; i < m1; i++)
                {
                    Mat[i] = int.Parse(dataGrid1.Rows[i].Cells[0].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ingresa Umbral!!!");

            }
            //Comienza a resolver
            //Paso 1, multiplica los valores por el valor de la tabla
            for (i = 0; i < m2; i++)   
            {
                for (j = 0; j < n2-1; j++)
                {
                    Acumulador[i] += double.Parse(dataGrid2.Rows[i].Cells[j].Value.ToString()) * Convert.ToDouble(Mat[j]);
                }

            }

            //Paso 2, compara los valores con el umbral y colocalos en Y
            for (i = 0; i < m2; i++)
            {
                if (Acumulador[i] > Umbral)
                {
                    dataGrid2.Rows[i].Cells[n2-1].Value = 1;
                }
                else 
                {
                    dataGrid2.Rows[i].Cells[n2-1].Value = 0;
                }

            }
            MessageBox.Show("Red Neuronal Resuelta!!");


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //Borrar datos en la memoria
            dataGrid1.Columns.Clear();
            dataGrid1.Rows.Clear();
            dataGrid2.Columns.Clear();
            dataGrid2.Rows.Clear();


            try
            {

                //Graficar tabla de valores
                entradas = int.Parse(tbx1.Text);
                m1 = entradas;
                n1 = 1;
                dataGrid1.RowCount = m1;
                dataGrid1.ColumnCount = n1;
                dataGrid1.Columns[0].HeaderText = "Pesos, Wn";
                //Graficar tabla de verdad
                double aux;
                aux = Math.Pow(2.0, Convert.ToDouble(entradas));
                m2 = Convert.ToInt32(aux);
                n2 = entradas + 1;
                //Columnas
                for (int j = 0; j < n2 + 1; j++)
                {
                    dataGrid2.ColumnCount = j;

                }
                for (int j = 0; j < n2 - 1; j++)
                {
                    dataGrid2.Columns[j].HeaderText = "x" + (j + 1).ToString();
                }
                dataGrid2.Columns[n2 - 1].HeaderText = "Y";


                //Filas
                for (int i = 1; i < m2 + 1; i++)
                {
                    dataGrid2.RowCount = i;

                }
                //dataGrid2.Rows[0].Cells[0].Value = 0;
                llenarTablaDeVerdad(m2, n2 - 1);
            }
            catch
            {
                MessageBox.Show("Ingresa No. de entradas!!!");
            }
            




        }

        public void llenarTablaDeVerdad(int m, int n)
        {
            MessageBox.Show("Tablas Generadas \n" +
                "m1 =" + m1.ToString() + " n1 =" + n1.ToString() + "\n" +
                "m2 =" + m2.ToString() + " n2 =" + (n2).ToString());
            //MessageBox.Show("Filas = " + m.ToString() + " Col =" + n.ToString());
            int i, j, c = 0, x2 = 0;
            int x1 = m / 2;

            for (j = 0; j < n; j++)
            {
                for (i = 0; i < m; i++)
                {
                    if (x2 == 0)
                    {
                        dataGrid2.Rows[i].Cells[j].Value = 0;
                        c++;
                    }
                    else if (x2 == 1)
                    {
                        dataGrid2.Rows[i].Cells[j].Value = 1;
                        c--;
                    }
                    if (c == x1)
                    {
                        //llegaste a la mitad de la tabla
                        x2 = 1;
                    }
                    if (c == 0)
                    {
                        //terminaste con la columa Xn
                        x2 = 0;
                    }
                }
                x1 = x1 / 2;
            
            }

        }
    }
}
