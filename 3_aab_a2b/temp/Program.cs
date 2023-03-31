//#define REAL_16384
#define REAL_16384_PERF


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.Threading;

namespace _00_Console_16_alglib_01_FFT
{
    class Program
    {
        static void Main(string[] args)
        {       
            //---------------REAL_16384-----------------
            #if REAL_16384
            string AnyKey;

            uint i = 0;
            const uint N = 16384;

            double[] s_in  = new double[N];
            alglib.complex[] s_out = new alglib.complex[N];

            //Create input
            for(i=0; i<N; i++)  {
                s_in[i] = 1.0*Math.Sin(2*Math.PI*46*i/N)+
    					  1.0*Math.Cos(2*Math.PI*1000*i/N)+
						  1.0*Math.Cos(2*Math.PI*1024*i/N);
            }

            //FFT
            alglib.fftr1d(s_in, out s_out);

            //Print results
            //for(i=1000-5; i<1000+5; i++)  {
		    //    Console.WriteLine("{0,4:D4}={1}", i, alglib.ap.format(s_out[i],3));
	        //}

            Console.WriteLine("----------------------");
	        for(i=46-5; i<46+5; i++)  {
		        Console.WriteLine("RE[{0,4:D}]={1,9:F3}   IM[{2,4:D}]={3,9:F3}", 
                                   i, s_out[i].x, i, s_out[i].y);
	        }
            Console.WriteLine("...");
            for(i=1000-5; i<1000+5; i++)  {
		        Console.WriteLine("RE[{0,4:D}]={1,9:F3}   IM[{2,4:D}]={3,9:F3}", 
                                   i, s_out[i].x, i, s_out[i].y);
	        }
            Console.WriteLine("...");
            for(i=1024-5; i<1024+5; i++)  {
		        Console.WriteLine("RE[{0,4:D}]={1,9:F3}   IM[{2,4:D}]={3,9:F3}", 
                                   i, s_out[i].x, i, s_out[i].y);
	        }

            //End
            Console.WriteLine("Press Enter..");
            AnyKey = Console.ReadLine();
            #endif


            //---------------REAL_16384 performance-----------------
            #if REAL_16384_PERF
            
            const uint N = 16384;
            const uint N_ITER = 100;
            
            string AnyKey;

            uint i = 0;
            uint j = 0;
            
            double[] s_in          = new double[N];
            alglib.complex[] s_out = new alglib.complex[N];

            Stopwatch stopwatch = new Stopwatch();
            int ms     = 0;
            double msd = 0.0;


            //Reset stopwatch
            stopwatch.Reset();

            //Iterations
            for(j=0; j<N_ITER; j++)  {
                
                //Create input
                for(i=0; i<N; i++)  {
                    s_in[i] = alglib.math.randomreal();
                }
    
                //FFT
                stopwatch.Start();
                
                alglib.fftr1d(s_in, out s_out);
           
                stopwatch.Stop();
            }
            

            ms = (int)stopwatch.ElapsedMilliseconds;
            msd= (double)ms/N_ITER;
            Console.WriteLine("ms_all={0,5:D5},ms   ms_one={1,0:F},ms", ms, msd);

            //Print results
            //for(i=1000-5; i<1000+5; i++)  {
		    //    Console.WriteLine("{0,4:D4}={1}", i, alglib.ap.format(s_out[i],3));
	        //}

            Console.WriteLine("----------------------");
	        for(i=46-5; i<46+5; i++)  {
		        Console.WriteLine("RE[{0,4:D}]={1,9:F3}   IM[{2,4:D}]={3,9:F3}", 
                                   i, s_out[i].x, i, s_out[i].y);
	        }
            Console.WriteLine("...");
            for(i=1000-5; i<1000+5; i++)  {
		        Console.WriteLine("RE[{0,4:D}]={1,9:F3}   IM[{2,4:D}]={3,9:F3}", 
                                   i, s_out[i].x, i, s_out[i].y);
	        }
            Console.WriteLine("...");
            for(i=1024-5; i<1024+5; i++)  {
		        Console.WriteLine("RE[{0,4:D}]={1,9:F3}   IM[{2,4:D}]={3,9:F3}", 
                                   i, s_out[i].x, i, s_out[i].y);
	        }
            #endif

            //End
            Console.WriteLine("Press Enter..");
            AnyKey = Console.ReadLine();
                   
        
        }     
      

        static void Hello()  {
            Console.WriteLine("Hello, World!");
        }


        static void PrintAr(string msg, double[] Ar, uint Len)  {
            uint i = 0;

            Console.WriteLine("{0}", msg);
            for(i=0; i<Len; i++)  {
                Console.WriteLine("{0,3:F3}", Ar[i]); //3 digits after comma
                //Console.WriteLine("{0,10:F3}", Ar[i]); //10 digits summary, 3 after comma
                //Console.WriteLine("{0,10:F3}", Ar[i]); //10 digits summary, 3 after comma
            }
        }
       
    }
}



