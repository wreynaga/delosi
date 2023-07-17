using Delosi.Domain.Entity;
using Delosi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delosi.Domain.Core
{
    public class LogicDomain : ILogicDomain
    {
        public Matrix Rotate(Matrix request)
        {
            int longitud = request.values.Length;
            int[][] nuevaMatriz = new int[longitud][];

            for (int i = 0; i < longitud; i++) { nuevaMatriz[i] = new int[longitud]; }
            for (int i = 0; i < longitud; i++)
            {
                for (int j = 0; j < longitud; j++)
                {
                    nuevaMatriz[i][j] = request.values[j][longitud - i - 1];
                }
            }
            Matrix matrix = new Matrix();
            matrix.values = nuevaMatriz;
            return matrix;
        }
    }
}
