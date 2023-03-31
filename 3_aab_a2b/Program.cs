using System;
using System.Diagnostics;

namespace _3_aab_a2b {
    public class Program {
        static void Main(string[] args) {
            string AnyKey;
            string res = "";
            string str = "";
            int num = 0;

            str = "a";
            res = Transform(str);
            Console.WriteLine("Src={0} Res={1}", str, res);
            
            str = "abc";
            res = Transform(str);
            Console.WriteLine("Src={0} Res={1}", str, res);

            str = "aa";
            res = Transform(str);
            Console.WriteLine("Src={0} Res={1}", str, res);

            str = "aab";
            res = Transform(str);
            Console.WriteLine("Src={0} Res={1}", str, res);

            str = "aabb";
            res = Transform(str);
            Console.WriteLine("Src={0} Res={1}", str, res);

            str = "abb";
            res = Transform(str);
            Console.WriteLine("Src={0} Res={1}", str, res);
            
            
            //End
            Console.WriteLine("Press Enter..");
            AnyKey = Console.ReadLine();               
        }

        //aabb -> a2b2
        //Look at the first symbol
        //Find its consequent entrances 
        //If there's more than one entrance
        //than add to the result the symbol and the number of entrances
        //step over the number of entrances to the next different element
        //If there's only one entrance  
        //than add it to the result and go to the next symbol

        public static string Transform(string text)  {
                        
            int i = 0;
            int num = 0;
            string res = "";
            int len = text.Length;

            if(len==0)  {
                return "";
            }
                        
            i = 0;
            while(i<len)  {
                num=SymSeq(text, i);
                if(num<2)  {
                    res+=text[i];
                    i++;
                }  
                else  {
                    res+=text[i]+num.ToString();
                    i+=num;
                }
            }            

            return res;
            
            
        }
        

        //Count the sequence length of the symbol at the "pos" position 
        static int SymSeq(string str, int pos)  {
            int len = str.Length;
            int i = 0;
            int num = 0;
            char sym = str[pos];

            for(i=pos; i<len; i++)  {
                if(str[i]==sym)  {
                    num++;
                }
                else  {
                    break;
                }
            }

            return num;        
        }
    }
}
