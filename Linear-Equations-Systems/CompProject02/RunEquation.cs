using System;
using System.Collections.Generic;
using System.Linq;


namespace CompProject02
{
    class RunEqu
    {
        public List<MainEquation> equations = new List<MainEquation>();
        private RunNumber_Numeral operations = new RunNumber_Numeral();
        private double[][] Matrix;
        private double[] Solutions;

        public void AddEquation(MainEquation eq)
        {
            equations.Add(eq);
        }

        public void EquPrint()
        {
            foreach (MainEquation item in equations)
            {
                Console.WriteLine(item.GetFormOfEquation);
            }
        }

        private double[][] AugmentedMatrix()
        {
            int Size = equations.Count();
            double[][] array = new double[Size][];

            for (int i = 0; i < array.Length; i++)
            {
                string[] Temp = equations[i].GetMatrixAugRow;
                double[] arrayTemp = new double[Temp.Length];

                for (int t = 0; t < arrayTemp.Length; t++)
                {
                    arrayTemp[t] = double.Parse(Temp[t]);
                }

                array[i] = arrayTemp;
            }

            return array;
        }
        private void SetAugMatrix()
        {
            this.Matrix = AugmentedMatrix();
        }

        private void SetSolutions()
        {
            SetAugMatrix();
            this.Solutions = operations.SolveEquation(this.Matrix);
        }
        public void PrintSolution()
        {
            SetSolutions();

            for (int i = 0; i < Solutions.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {Solutions[i]}");
            }
        }
    }
}
