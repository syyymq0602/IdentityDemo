using System;

namespace qqq
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = MaxNum(9,2);
            Console.WriteLine(m);
        }
        // 比大小自定义函数
        public static int MaxNum(int a, int b)
        {
            int c = 1;
            for(int i =0;i<b;i++){
                c = c * a;
            }
            return c;
        }
    }
}
