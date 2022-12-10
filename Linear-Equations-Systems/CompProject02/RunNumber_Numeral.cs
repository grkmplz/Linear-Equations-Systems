using System;

namespace CompProject02
{
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
