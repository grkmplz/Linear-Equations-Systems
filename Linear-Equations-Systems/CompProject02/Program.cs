using System;
using System.Collections.Generic;
using System.Linq;

namespace CompProject02
{
    class MainEquation
    {
        public string[] Input_Matrix_Row { get; }
        public string Input_FormofEqu { get; }

        public MainEquation(string augmentedEquation)
        {
            this.Input_Matrix_Row = SetMatrixRow(augmentedEquation);
            this.Input_FormofEqu = SetFormOfEquation(Input_Matrix_Row);
        }
        // to detect the wrong characters , create a method
        private string[] SetMatrixRow(string Input)
        {
            for (int i = 0; i < Input.Length; i++)
            {
                if (!double.TryParse(Input[i].ToString(), out double val) && Input[i] != ' ' && Input[i] != '-')
                    throw new Exception("Warning : Wrong character detected!!!");
            }
            string[] splittedEquation = Input.Split(' ');

            return splittedEquation;
        }

        private string SetFormOfEquation(string[] equationMain)
        {
            int Index = 1;
            string equation = null;

            for (int i = 0; i < equationMain.Length; i++)
            {
                if (i == 0)
                {
                    equation += equationMain[i] + "*x" + Index;
                    Index++;
                }

                else if (i == equationMain.Length - 1)
                {
                    equation += " = " + equationMain[i];
                }

                else
                {
                    equation += " + " + equationMain[i] + "*x" + Index;
                    Index++;
                }
            }

            return equation;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string whileValue;
            do
            {
                Console.Clear();
                Console.WriteLine("Fill in the blanks with linear equations in augmented matrix notation: " +
                                    "\na1 a2... aN d, where a1..N are coefficients and d is a constant.");
                Console.WriteLine("Space divides them to complete entering equations, type END.\n");
                // ask for the values
                RunEqu RunEqu = new RunEqu();
                int NumbEqu = 1;
                // use try catch to get the wrong forms or numbers
                try
                {
                    while (true)
                    {
                        Console.Write($"Eq #{NumbEqu}: ");
                        string get_input = Console.ReadLine();
                        if (get_input.ToLower() == "end")
                        {
                            Console.WriteLine("\nThe equations are:");
                            break;
                        }
                        RunEqu.Equation_Add(new MainEquation(get_input));
                        NumbEqu++;
                    }

                    RunEqu.EquPrint();

                    Console.WriteLine("\nAnd solutions are: ");
                    RunEqu.PrintSolution();
                }

                catch (Exception Except)
                {
                    Console.WriteLine(Except.Message + " Please try again");
                }
                //  request value to continue the mechanism 
                Console.WriteLine("Please type any to continue.. or exit");
                whileValue = Console.ReadLine();
              // have a do while to at least work once , it depends to continue
            } while (whileValue != "exit");
            
        }
    }

    class RunEqu
    {
        public List<MainEquation> equationMain = new List<MainEquation>();
        private RunNumber_Numeral operations = new RunNumber_Numeral();
        private double[][] Matrix;
        private double[] Solutions;

        public void Equation_Add(MainEquation eq)
        {
            equationMain.Add(eq);
        }

        public void EquPrint()
        {
            foreach (MainEquation item in equationMain)
            {
                Console.WriteLine(item.Input_FormofEqu);
            }
        }

        private double[][] AugMatrix()
        {
            int Size = equationMain.Count();
            double[][] array = new double[Size][];

            for (int i = 0; i < array.Length; i++)
            {
                string[] Temp = equationMain[i].Input_Matrix_Row;
                double[] arrayTemp = new double[Temp.Length];

                for (int t = 0; t < arrayTemp.Length; t++)
                {
                    arrayTemp[t] = double.Parse(Temp[t]);
                }

                array[i] = arrayTemp;
            }

            return array;
        }
        private void ContructAugmatrix()
        {
            this.Matrix = AugMatrix();
        }

        private void ConstrtSolution()
        {
            ContructAugmatrix();
            this.Solutions = operations.SolveEquation(this.Matrix);
        }
        public void PrintSolution()
        {
            ConstrtSolution();

            for (int i = 0; i < Solutions.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {Solutions[i]}");
            }
        }
    }

    class RunNumber_Numeral
    {
        public double[] BackwardSubstitution(double[][] rows)
        {
            double val = 0;
            int length = rows[0].Length;
            double[] result = new double[rows.Length];
            for (int i = rows.Length - 1; i >= 0; i--)
            {
                val = rows[i][length - 1];
                for (int x = length - 2; x > i - 1; x--)
                {
                    val -= rows[i][x] * result[x];
                }
                result[i] = val / rows[i][i];
            }

            return result;
        }

        public double[] SolveEquation(double[][] row)
        {
            int length = row[0].Length;

            for (int i = 0; i < row.Length - 1; i++)
            {
                if (row[i][i] == 0 && !Pivot(row, i, i)) return null;

                for (int j = i; j < row.Length; j++)
                {
                    double[] d = new double[length];

                    for (int x = 0; x < length; x++)
                    {
                        d[x] = row[j][x];
                        if (row[j][i] != 0)
                            d[x] = d[x] / row[j][i];
                    }

                    row[j] = d;
                }

                for (int y = i + 1; y < row.Length; y++)
                {
                    double[] f = new double[length];
                    for (int g = 0; g < length; g++)
                    {
                        f[g] = row[y][g];
                        if (row[y][i] != 0)
                        {
                            f[g] = f[g] - row[i][g];
                        }

                    }
                    row[y] = f;
                }
            }

            return BackwardSubstitution(row);
        }

        public bool Pivot(double[][] rows, int row, int column)
        {
            bool swapped = false;
            for (int z = rows.Length - 1; z > row; z--)
            {
                if (rows[z][row] != 0)
                {
                    double[] temp = new double[rows[0].Length];
                    temp = rows[z];
                    rows[z] = rows[column];
                    rows[column] = temp;
                    swapped = true;
                }
            }

            return swapped;
        }
    }

}
