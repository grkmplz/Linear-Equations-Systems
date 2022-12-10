using System;
using System.Collections.Generic;
using System.Linq;


namespace CompProject02
{
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
}
