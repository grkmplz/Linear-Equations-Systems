using System;

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
}
