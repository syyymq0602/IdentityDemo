using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics;
using System.Threading;

namespace Diagnostic.Algrithm.FFT
{
    public class FFT
    {
        public List<Parameter> Parameters 
        { 
            get; 
            set; 
        }
        public FFT()
        {
            ThreadPool.SetMaxThreads(8, 8);
            Parameters = new List<Parameter>();
        }
        public void DataSort(ref double[] dataReal)
        {
            int len = dataReal.Length;
            int[] count = new int[len];
            int M = (int)(Math.Log(len) / Math.Log(2));

            double[] temp_r = new double[len];
            dataReal.CopyTo(temp_r, 0);

            for (int l = 0; l < M; l++)
            {
                int space = (int)Math.Pow(2, l);
                int add = (int)Math.Pow(2, M - l - 1);
                for (int i = 0; i < len; i++)
                {
                    if ((i / space) % 2 != 0)
                        count[i] += add;
                }
            }
            for (int i = 0; i < len; i++)
            {
                dataReal[i] = temp_r[count[i]];
            }
        }
        private void Butterfly(object p)
        {

            var parameter = p as Parameter;
            double omega_Re, omega_Im;
            //蝶形算法中上半区中复数乘法的临时变量；
            double temp1_Re, temp1_Im;
            //蝶形算法中下半区中复数乘法的临时变量；
            double temp2_Re, temp2_Im;
            parameter.Flag = false;
            for (int i = parameter.Start1; i < parameter.End1; i++)
            {
                for (int j = parameter.Start2; j < parameter.End2; j++)
                {
                    #region
                    omega_Re = Math.Cos(2 * Math.PI / parameter.N * parameter.Group * j);//查表优化
                    omega_Im = -Math.Sin(2 * Math.PI / parameter.N * parameter.Group * j);//查表优化
                    temp1_Re = parameter.Input_Re[i * parameter.Split + j];
                    temp1_Im = parameter.Input_Im[i * parameter.Split + j];
                    temp2_Re = parameter.Input_Re[i * parameter.Split + j + parameter.Split / 2];
                    temp2_Im = parameter.Input_Im[i * parameter.Split + j + parameter.Split / 2];
                    var k1 = temp2_Re * omega_Re;
                    var k2 = temp2_Im * omega_Im;
                    var k3 = temp2_Im * omega_Re;
                    var k4 = temp2_Re * omega_Im;
                    parameter.Input_Re[i * parameter.Split + j] = temp1_Re + k1 - k2;
                    parameter.Input_Im[i * parameter.Split + j] = temp1_Im + k3 + k4;
                    parameter.Input_Re[i * parameter.Split + j + parameter.Split / 2] = temp1_Re - k1 + k2;
                    parameter.Input_Im[i * parameter.Split + j + parameter.Split / 2] = temp1_Im - k3 - k4;
                    #endregion
                }
            }
            parameter.Flag = true;
        }
        private int Length(int a)
        {
            int count = 0;
            while (a >> 1 != 0)
            {
                a >>= 1;
                count++;
            }
            if (1 << count < a && 1 << (count + 1) > a)
            {
                return count + 1;
            }
            else
            {
                return count;
            }
        }
        private double[] Datatemp(int count,int n,ref double[] data)
        {
            double[] datatemp = new double[n];
            for(int i = 0; i < count; i++)
            {
                datatemp[i] = data[i];
            }
            for(int i = count; i < n; i++)
            {
                datatemp[i] = 0;
            }
            return datatemp;
        }
        public double[] Execute(ref double[] data)
        {
            int Count = data.Length;
            int N = 0;
            if (Count == 0) 
                throw new Exception("The Length of the Data Must Larger than 0");
            else if (Count > 0 && Count < 6)
            {
                N = 1<<6;
            }
            else
            {
                N = 1<<Length(Count);
            }
            double[] datatemp = Datatemp(Count, N,ref data);
            ///将实数信号转换成复数，并进行初始化
            double[] input_Re = new double[N];
            double[] input_Im = new double[N];
            int M = (int)(Math.Log(N) / Math.Log(2));
            var index = SortTable.IndexMap[N];
            for (int i = 0; i < N; i++)
            {
                //tempReal[i] = data[i];
                input_Re[i] = datatemp[index[i]];
                input_Im[i] = 0;
            }
            for (int l = 1; l <= M; l++)
            {
                int split = (int)Math.Pow(2, l);
                int group = (int)Math.Pow(2, M - l);
                Parameter parameter1;
                Parameter parameter2;
                Parameter parameter3;
                Parameter parameter4;
                if (l < M / 2)
                {
                    parameter1 = new Parameter() { Start1 = 0, End1 = group / 4, Start2 = 0, End2 = split / 2, N = N, Group = group, Split = split, Input_Re = input_Re, Input_Im = input_Im, Flag = false };
                    parameter2 = new Parameter() { Start1 = group / 4, End1 = group / 2, Start2 = 0, End2 = split / 2, N = N, Group = group, Split = split, Input_Re = input_Re, Input_Im = input_Im, Flag = false };
                    parameter3 = new Parameter() { Start1 = group / 2, End1 = 3 * group / 4, Start2 = 0, End2 = split / 2, N = N, Group = group, Split = split, Input_Re = input_Re, Input_Im = input_Im, Flag = false };
                    parameter4 = new Parameter() { Start1 = 3 * group / 4, End1 = group, Start2 = 0, End2 = split / 2, N = N, Group = group, Split = split, Input_Re = input_Re, Input_Im = input_Im, Flag = false };
                }
                else
                {
                    parameter1 = new Parameter() { Start1 = 0, End1 = group, Start2 = 0, End2 = split / 8, N = N, Group = group, Split = split, Input_Re = input_Re, Input_Im = input_Im, Flag = false };
                    parameter2 = new Parameter() { Start1 = 0, End1 = group, Start2 = split / 8, End2 = 2 * split / 8, N = N, Group = group, Split = split, Input_Re = input_Re, Input_Im = input_Im, Flag = false };
                    parameter3 = new Parameter() { Start1 = 0, End1 = group, Start2 = 2 * split / 8, End2 = 3 * split / 8, N = N, Group = group, Split = split, Input_Re = input_Re, Input_Im = input_Im, Flag = false };
                    parameter4 = new Parameter() { Start1 = 0, End1 = group, Start2 = 3 * split / 8, End2 = split / 2, N = N, Group = group, Split = split, Input_Re = input_Re, Input_Im = input_Im, Flag = false };
                }
                ThreadPool.QueueUserWorkItem(Butterfly, parameter1);
                ThreadPool.QueueUserWorkItem(Butterfly, parameter2);
                ThreadPool.QueueUserWorkItem(Butterfly, parameter3);
                ThreadPool.QueueUserWorkItem(Butterfly, parameter4);
                while (true)
                {
                    if (parameter1.Flag == true && parameter2.Flag == true && parameter3.Flag == true && parameter4.Flag == true)
                        break;
                }
            }
            double[] result = new double[2 * N];
            for(int i = 0; i < N; i++)
            {
                result[i] = input_Re[i];
                result[i + N] = input_Im[i];
            }
            return result;
        }
        public double[] PowerSpectrum(ref double[] data,int fs)
        {
            var result=Execute(ref data);
            var M = result.Length;
            int N = M / 4;
            double[] powerspectrum = new double[2 * N];
            for(int i = 0; i < N; i++)
            {
                powerspectrum[i] = Convert.ToDouble(i * fs) / N;
                powerspectrum[i + N] = Math.Sqrt(result[i] * result[i] + result[i + M / 2] * result[i + M / 2])/N;
            }
            powerspectrum[N] = powerspectrum[N] / 2;
            return powerspectrum;
        }
    }
}
