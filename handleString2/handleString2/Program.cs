using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace handleString2
{
    class Program
    {
        static void Main(string[] args)
        {
            string myText;
            int minLength = 0;
            int adjTextLength = 0;
            WordExtractor word = new WordExtractor();

            Console.Write("请输入要分析的字符串：");
            myText = Console.ReadLine();
            Console.Write("请输入要显示的单词的最小长度：");
            minLength = Convert.ToInt32(Console.ReadLine());
            //调整文本长度和数组下标匹配  
            adjTextLength = myText.Length - 1;

 word.Getword(myText, adjTextLength, minLength);

        }
    }
}
