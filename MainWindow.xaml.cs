using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace compiladores03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

private void BtnLlenar_Click(object sender, RoutedEventArgs e)
        {                       

            string[,] mat;
            int es = int.Parse(txtEstado.Text);
            int se = int.Parse(txtSecuencia.Text);
            es++;
            se++;
            mat = new string[es, se];
            int sw = 0;
            int c = 0;
            
            int p = 1;
            int p1 = 1;
            int fil = 2;
            
            string[,] mat1;
            mat1 = new string[fil, se];

            string[,] copia;
            copia = new string[fil, se];

            for (int i = 0; i < es; i++)
            {
                if (i == 0)
                {
                    mat[i, 0] = 0.ToString();
                    
                }
                else
                {
                    string t = Microsoft.VisualBasic.Interaction.InputBox("Ingrese estado " + p, "Estados", "", 100, 0);
                    mat[i, 0] = t.ToString();
                    p = p + 1;
                }
            }
            for (int j = 0; j < se; j++)
            {
                if (j == 0)
                {
                    mat[0, j] = 0.ToString();

                }
                else
                {
                    string t2 = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la secuencia " + p1, "Secuencia", "", 100, 0);
                    mat[0, j] = t2.ToString();
                    p1 = p1 + 1;
                }
            }
            for (int i1=1; i1<es;i1++)
            {
                for (int j1 = 1; j1 < se; j1++)
                {
                    string ll = Microsoft.VisualBasic.Interaction.InputBox("Estando en " + mat[i1, 0] + " Me llega " + mat[0, j1], "", "", 100, 0);
                    mat[i1, j1] = ll.ToString();
                }
        
            }

            //CREACION DE LA NUEVA MATRIZ(ESTADOS/COLUMNAS)

            //LLENAR LA PRIMERA FILA IGUAL
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < se; j++)
                {                    
                    mat1[i, j] = mat[i, j];
                }
            }

            for (int i = 1; i < es; i++)
            {
                for (int j = 1; j < se; j++)
                {                   
                    for (int k = 1; k < fil;k++)
                    {
                        if (mat1[i, j] != mat1[k, 0])
                        {
                            sw = 1;
                        }
                        else
                        {
                            sw = 0;
                            k = es;
                        }                                                                       
                    }
                    if(sw==1)
                    {
                        mat1.CopyTo(copia, 0);
                        mat1 = new string[mat1.Length + 1, 0];
                        copia.CopyTo(mat1, 0);
                        mat1[mat1.Length, 0] = mat1[i, j];                       
                    }                   
                }
            }
            //LLENAR MATRIZ NUEVA
            for (int i = 2; i < es; i++)
            {
                for (int k = 1; k < fil; k++)
                {
                    if (mat1[i, 0].Contains(mat[k, 0]))
                    {

                        for (int ca = 1; ca < se; ca++)
                        {
                            mat1[i, ca] = mat1[i, ca] + mat[k, 0];
                        }
                    }

                }
            }

            }
    }       
}

