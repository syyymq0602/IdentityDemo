using System;
using System.Collections.Generic;
using System.Text;

namespace Diagnostic.Algrithm.FFT
{
    public class Parameter: IDisposable
    {
        public int Start1 
        { 
            get; 
            set;
        }
        public int End1 
        { 
            get; 
            set; 
        }
        public int Start2 
        { 
            get; 
            set; 
        }
        public int End2 
        { 
            get; 
            set; 
        }
        public int Group 
        { 
            get; 
            set;
        }
        public int N 
        { 
            get; 
            set; 
        }
        public int Split 
        { 
            get;
            set; 
        }
        public double[] Input_Re 
        { 
            get; 
            set; 
        }
        public double[] Input_Im
        { 
            get; 
            set; 
        }
        public bool Flag 
        { 
            get; 
            set;
        }

        public void Dispose()
        {
            Dispose(true);
            //通知垃圾回收器不再调用终结器
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            //清理托管资源
            if (disposing)
            {
                if (Input_Re != null)
                {
                    Input_Re = null;
                }
                if(Input_Im!=null)
                {
                    Input_Im = null;
                }
            }
        }
    }
}
