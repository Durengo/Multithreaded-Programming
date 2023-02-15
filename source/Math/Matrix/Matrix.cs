using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using durlibcsharp;

namespace DurlibMathDefinition
{
    public struct MatrixDefine : IEnumerable
    {
        private float[] matrix;
        private string name;

        public float[] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public MatrixDefine(float[] mat)
        {
            matrix = mat;
        }

        public IEnumerator GetEnumerator()
        {
            return matrix.GetEnumerator();
        }
    }
}

namespace source.Math.Matrix
{

using DurlibMathDefinition;

    public class Matrix
    {

        protected void PrintMatrix(MatrixDefine matrix)
        {
            durlibsharplog.Log($"{matrix.Name} values:");
            foreach (float val in matrix)
            {
                durlibsharplog.LogL(val);
            }
        }

    }
}