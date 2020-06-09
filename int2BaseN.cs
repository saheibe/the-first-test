using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        public readonly char[] _ARRAY = {   '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' , 'j',
                            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                            'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
                            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                            'Y', 'Z', '!' ,'"' ,'#' ,'$' ,'%' ,'&' ,'\'','(',
                            ')', '*'  ,'+' ,',','-' ,'.' ,'/' ,':' ,';' ,'<',
                            '=', '>', '?','@' ,'[', '\\', ']', '^' ,'_' , '`','\0',
                            '{','|' , '}' ,'~' ,'€' ,'‚' ,'ƒ' ,'„' ,'…' ,'†' ,'‡' ,'ˆ' ,'‰' ,'Š' ,'‹' ,'Œ' ,'Ž' ,'‘' ,'’' ,'“' ,'”' ,'•' ,'–' ,'—' ,'˜' ,'™' ,'š' ,'›' ,'œ' ,'ž' ,'Ÿ' ,'¡' ,'¢' ,'£' ,'¤' ,'¥' ,'¦' ,'§' ,'¨' ,'©' ,'ª' ,'«' ,'¬' ,'­' ,'®' ,'¯' ,'°' ,'±' ,'²' ,'³' ,'´' ,'µ' ,'¶' ,'·' ,'¸' ,'¹' ,'º' ,'»' ,'¼' ,'½' ,'¾' ,'¿' ,'À' ,'Á' ,'Â' ,'Ã' ,'Ä' ,'Å' ,'Æ' ,'Ç' ,'È' ,'É' ,'Ê' ,'Ë' ,'Ì' ,'Í' ,'Î' ,'Ï' ,'Ð' ,'Ñ' ,'Ò' ,'Ó' ,'Ô' ,'Õ' ,'Ö' ,'×' ,'Ø' ,'Ù' ,'Ú' ,'Û' ,'Ü' ,'Ý' ,'Þ' ,'ß' ,'à' ,'á' ,'â' ,'ã' ,'ä' ,'å' ,'æ' ,'ç' ,'è' ,'é' ,'ê' ,'ë' ,'ì' ,'í' ,'î' ,'ï' ,'ð' ,'ñ' ,'ò' ,'ó' ,'ô' ,'õ' ,'ö' ,'÷' ,'ø' ,'ù' ,'ú' ,'û' ,'ü' ,'ý' ,'þ' ,'ÿ' };






        static bool IsSameWithHashSet(char[] arr)
        {
            ISet<char> set = new HashSet<char>();

            for (var i = 0; i < arr.Length; i++)
            {
                // 这里可利用该元素来实现统计重复的元素有哪些，及重复个数。
                //bool state = set.Add(arr[i]); // 如果返回false，表示set中已经有该元素。
                //Console.WriteLine(state);
                bool state = set.Add(arr[i]);
                if (!state) {
                    Console.WriteLine(arr[i]);
                    return true; }
            }

            return set.Count != arr.Length;
        }


        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine(Double.MaxValue);
            Console.WriteLine(Int2BaseN(211, 841));

        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(IsSameWithHashSet(_ARRAY));
            Console.WriteLine(_ARRAY.Length);
            string temp = "oDNSU591vtisERbRzim7PsAITGc";
            string ss = Short(temp);
            string hh = Long(ss);


            Console.WriteLine(temp);
            Console.WriteLine(ShortNew(temp));
            Console.WriteLine(ss);
            Console.WriteLine(hh);
            Console.WriteLine("=========================////====================");

            for (int i = 0; i < 10; i++)
            {
                string s = Guid.NewGuid().ToString().Substring(0).Replace("-", "");

                Console.WriteLine("yuan:"+s);
                string ns = ShortNew(s);
                Console.WriteLine("duan:" + ns);//变短
                Console.WriteLine( "chang:" + LongNew(ns, s));//还原
              





                Console.WriteLine();



                string re = Short(s);

                Console.WriteLine( "Ldaun:"+re); //变短

                Console.WriteLine("Lchang:"+ Long(re));//还原

                Console.WriteLine("-------------------------------------------");
            }


        }

        public string Short(string input)
        {
            BigInteger big = BaseN2Int(62, input);
            string to = Int2BaseN(_ARRAY.Length, big);
            //Console.WriteLine(big);
            return to;
        }

        public string Long(string input)
        {
            BigInteger to2 = BaseN2Int(_ARRAY.Length , input);
            string to = Int2BaseN(62, to2);
           // Console.WriteLine(to2);
            return to;
        }






        /// <summary>
        /// 十进制转换其他进制重载
        /// </summary>
        /// <param name="baseN">进制字符</param>
        /// <param name="input">十进制参数</param>
        /// <returns></returns>
        public string Int2BaseN(char[] _arr, BigInteger input)
        {
            //进制字符长度n 代表是n进制
            StringBuilder re = new StringBuilder();
            int baseN = _arr.Length;
            do
            {
                int index = (int)(input % baseN);
                re.Append(_arr[index]);
                input = input / baseN;

            } while (input != 0);
            char[] ss = re.ToString().ToCharArray();
            Array.Reverse(ss);
            return new String(ss);
        }






        /// <summary>
        /// 十进制转换其他进制
        /// </summary>
        /// <param name="baseN">要转换目标进制</param>
        /// <param name="input">十进制参数</param>
        /// <returns></returns>
        public string Int2BaseN(int baseN, BigInteger input)
        {
            StringBuilder re = new StringBuilder();
            //取模运算 ，找到对应字符
            do
            {
                int index = (int)(input % baseN);
                re.Append(_ARRAY[index]);
                input = input / baseN;

            } while (input != 0);
            char[] ss = re.ToString().ToCharArray();
            Array.Reverse(ss);
            return new String(ss);
        }

        /// <summary>
        /// 新版缩短算法， 进制根据原始字符串使用不重复字符个数得出； 缺点是还原时需要 原始字符串唯一使用的字符集。
        /// </summary>
        /// <param name="yuan"></param>
        /// <returns></returns>
        public string ShortNew( string yuan)
        {
            char[] sarr = yuan.ToCharArray().Distinct().ToArray();
            Array.Reverse(sarr);
            BigInteger fefe = BaseN2Int(sarr, yuan);


            char[] narr = new char[sarr.Length + _ARRAY.Length];
            sarr.CopyTo(narr,0);
            _ARRAY.CopyTo(narr ,sarr.Length);
            char[] nnarr = narr.Distinct().ToArray();
            //Console.WriteLine( new string (nnarr));
            return   Int2BaseN(  nnarr  , fefe );
        }


        public string LongNew(string s , string yuan )
        {
            char[] sarr = yuan.ToCharArray().Distinct().ToArray();
            Array.Reverse(sarr);
            char[] narr = new char[sarr.Length + _ARRAY.Length];
            sarr.CopyTo(narr, 0);
            _ARRAY.CopyTo(narr, sarr.Length);
            char[] nnarr = narr.Distinct().ToArray();

            BigInteger big = BaseN2Int( nnarr , s );
            return Int2BaseN(  sarr ,big  );

        }


        /// <summary>
        /// 其他进制转换成十进制重载
        /// </summary>
        /// <param name="baseN">进制字符集合</param>
        /// <param name="s">参数是什么</param>
        /// <returns></returns>
        public BigInteger BaseN2Int(char[]  _arr , string s)
        {
            //进制字符集合内包含多少字符就是多少进制
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            BigInteger re = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int temp = Array.IndexOf(_arr , arr[i]);
                re += temp * BigInteger.Pow(_arr.Length, i);
            }
            return re;
        }



        /// <summary>
        /// 其他进制转换成十进制
        /// </summary>
        /// <param name="baseN">参数是什么进制的</param>
        /// <param name="s">参数是什么</param>
        /// <returns></returns>
        public BigInteger BaseN2Int( int baseN , string s)
        { 
            //其他进制转10进制，就是对应位置的字符代表的数字 ，乘以进制n的 位（例：个十百千）数幂 ，
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            BigInteger re = 0;
            for (int i = 0; i < arr.Length; i++)
            {                
                int temp = Array.IndexOf(_ARRAY, arr[i]);
                re +=   temp *  BigInteger.Pow ( baseN  ,  i ) ;
            }
            return re;
        }
    }
}
