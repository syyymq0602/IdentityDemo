using System;
using MathNet.Numerics;
using System.Collections.Generic;
using System.Text;

namespace Diagnostic.Algrithm.FFT
{
    public class UnitRoot
    {
        public float Real 
        { 
            get; 
            set; 
        }
        public float Imaginary 
        { 
            get; 
            set; 
        }
        public int K 
        { 
            get; 
            set; 
        }
        public int N 
        { 
            get; 
            set; 
        }
        public Complex32 Value 
        { 
            get; 
            set; 
        }
        public UnitRoot(int k, int n)
        {
            K = k;
            N = n;
            double nk = (k / (double)n) * 2 * Math.PI;
            Value = new Complex32((float)Math.Cos(nk), (float)Math.Sin(nk));
            Real = Value.Real;
            Imaginary = Value.Imaginary;
        }
    }
}
