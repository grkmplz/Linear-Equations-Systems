using System;

namespace CompProject02
{
    class MainEquation
    {
        public string[] GetMatrixAugRow { get; }
        public string GetFormOfEquation { get; }

        public MainEquation(string augmentedEquation)
        {
            this.GetMatrixAugRow = SetMatrixRow(augmentedEquation);
            this.GetFormOfEquation = SetFormOfEquation(GetMatrixAugRow);
        }

        private string[] SetMatrixRow(string Input)
        {
            for (int i = 0; i < Input.Length; i++)
            {
                if (!double.TryParse(Input[i].ToString(), out double val) && Input[i] != ' ' && Input[i] != '-')
                    throw new Exception("Wrong character detected");
            }
            string[] splittedEquation = Input.Split(' ');

            return splittedEquation;
        }

        private string SetFormOfEquation(string[] Equations)
        {
            int Index = 1;
            string equation = null;

            for (int i = 0; i < Equations.Length; i++)
            {
                if (i == 0)
                {
                    equation += Equations[i] + "*x" + Index;
                    Index++;
                }

                else if (i == Equations.Length - 1)
                {
                    equation += " = " + Equations[i];
                }

                else
                {
                    equation += " + " + Equations[i] + "*x" + Index;
                    Index++;
                }
            }

            return equation;
        }
    }
}
