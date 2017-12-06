using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace handleString2
{
   public  class WordExtractor
    {
        //初始状态：wordBengin位于单词的起始处，设置wordEnd开始检索  
        int wordBengin = 0;
        int wordEnd = 0;
        int wordLength = 0;


        char ch;
        public void Getword(string myText, int adjTextLength, int minLength)
        {
            while (wordEnd < adjTextLength)
            {
                //将wordEnd前移一个字符  
                wordEnd++;
                ch = myText[wordEnd];
                //如果碰到了空白符  
                if (char.IsWhiteSpace(ch))
                {
                    wordLength = wordEnd - wordBengin;  //获取单词的长度  
                    if (wordLength >= minLength)   //如果单词的长度大于或者等于用户要求的单词长度  
                    {
                        Console.WriteLine(myText.Substring(wordBengin, wordLength));
                    }
                    //将wordBengin移到下一个单词的起始处  
                    wordBengin = wordEnd + 1;
                }
            }

            //处理最后一个单词  
            wordLength = myText.Length - wordBengin;    //获取最后一个单词的长度  
            if (wordLength >= minLength)
            {
                Console.WriteLine(myText.Substring(wordBengin, wordLength));
               
            }
            Console.ReadLine();
        }
    }
}
