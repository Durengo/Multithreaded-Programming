using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace source.Math.Matrix
{
    using DurlibMathDefinition;
    using durlibcsharp;
    public class SquareMatrix : Matrix
    {
        private MatrixDefine SquareMatrixLeft;
        private MatrixDefine SquareMatrixRight;
        private int SquareSize = 0;

        public SquareMatrix(MatrixDefine sqmL, MatrixDefine sqmR)
        {
            SquareMatrixLeft = sqmL;
            SquareMatrixLeft.Name = "Left Matrix";
            SquareMatrixRight = sqmR;
            SquareMatrixLeft.Name = "Right Matrix";
            ValidateSquareMatrix();
        }
        public SquareMatrix(float[] sqmL, float[] sqmR)
        {
            SquareMatrixLeft = new MatrixDefine(sqmL);
            SquareMatrixLeft.Name = "Left Matrix";
            SquareMatrixRight = new MatrixDefine(sqmR);
            SquareMatrixRight.Name = "Right Matrix";
            ValidateSquareMatrix();
        }



        public void PrintSquare()
        {
            durlibsharplog.LogL($"{SquareMatrixLeft.Name} values:");
            for(int i = 0; i < SquareMatrixLeft.Matrix.Length; i++)
            {
                if(i + 1 / SquareSize == 1)
                {
                    durlibsharplog.LogL(SquareMatrixLeft.Matrix[i]);
                }
                else
                {
                    durlibsharplog.Log(SquareMatrixLeft.Matrix[i] + " ");
                }
            }
            durlibsharplog.LogL("");
            durlibsharplog.LogL($"{SquareMatrixRight.Name} values:");
            for(int i = 0; i < SquareMatrixRight.Matrix.Length; i++)
            {
                if(i + 1 / SquareSize == 1)
                {
                    durlibsharplog.LogL(SquareMatrixRight.Matrix[i]);
                }
                else
                {
                    durlibsharplog.Log(SquareMatrixRight.Matrix[i] + " ");
                }
            }
            durlibsharplog.LogL("");
        }
        public void Print()
        {
            PrintMatrix(SquareMatrixLeft);
            PrintMatrix(SquareMatrixRight);
        }
        private void FindSquareSize()
        {
            int size = 1;
            while(SquareSize == 0)
            {
                if(SquareMatrixLeft.Matrix.Length / size == size)
                {
                    SquareSize = size;
                }
                else
                {
                    size++;
                }

            }
        }
        private void ValidateSquareMatrix()
        {
            if(SquareMatrixLeft.Matrix.Length < 4 || SquareMatrixRight.Matrix.Length < 4)
            {
                throw new FormatException();
            }
            if(SquareMatrixLeft.Matrix.Length % 2 != SquareMatrixRight.Matrix.Length % 2)
            {
                throw new FormatException();
            }
            FindSquareSize();
        }
    }
}