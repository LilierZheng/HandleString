using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace ConsoleHandleString
{
    class Program
    {
        static void Main(string[] args)
        {
            //output timespan
            string text = File.ReadAllText(@"F:\HandleString\Article.txt");
            text.Replace(',', ' ');
            text.Replace('.', ' ');
            Regex regex = new Regex("\\s+");
            String[] ary = regex.Split(text);
            // 分词并且定义英文中不代表实际意义的一些单词，如介词、代词、情态动词等  
            String[] keys = { "you", "i", "he", "she", "me", "him", "her", "it",  
                "they", "them", "we", "us", "your", "yours", "our", "his",  
                "her", "its", "my", "in", "into", "on", "for", "out", "up",  
                "down", "at", "to", "too", "with", "by", "about", "among",  
                "between", "over", "from", "be", "been", "am", "is", "are",  
                "was", "were", "without", "the", "of", "and", "a", "an",  
                "that", "this", "be", "or", "as", "will", "would", "can",  
                "could", "may", "might", "shall", "should", "must", "has",  
                "have", "had", "than" };
            // 将一部分常见的无意义的英语单词替换为字符 '#' 以便后面输出单词出现次数时的判断 
            DateTime dtBegin = DateTime.Now;
            for (int i = 0; i < ary.Length; i++)
            {
                for (int j = 0; j < keys.Length; j++)
                {
                    if (ary[i].ToLower().Contains(keys[j]))
                    {
                        ary[i] = "#";
                    }
                    else
                    {
                        ary[i] = ary[i].ToLower();
                    }
                }
            }
            DateTime dtEnd = DateTime.Now;
            TimeSpan ts = dtEnd - dtBegin;
            Console.Write("替换无意义单词为#，所需时间间隔数：{0}秒", ts.TotalSeconds);
            Console.ReadLine();
            dtBegin = DateTime.Now;
            Dictionary<string, int> noRepeatWordsDic = new Dictionary<string, int>();
            for (int i = 0; i < ary.Length; i++)
            {
                if (ary[i] == "#")
                {
                    continue;
                }

                if (noRepeatWordsDic.ContainsKey(ary[i]))
                {
                    noRepeatWordsDic[ary[i]] = noRepeatWordsDic[ary[i]] + 1;
                }
                else
                {
                    noRepeatWordsDic.Add(ary[i], 1);
                }


            }
            dtEnd = DateTime.Now;
            ts = dtEnd - dtBegin;
            Console.WriteLine("统计不重复单词数量，所需时间间隔数：{0}秒", ts.TotalSeconds);
            Console.ReadLine();
            string path = @".\outPut.txt";
            Console.WriteLine("写入文件路径{0}", path);
            Console.ReadLine();

            FileStream fs = new FileStream(@"F:\HandleString\outPut.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            string s = dictionaryToJson(noRepeatWordsDic);
            sw.Write(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public static string dictionaryToJson(Dictionary<string, int> dic)
        {
            //实例化JavaScriptSerializer类的新实例  
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象  
                return jss.Serialize(dic);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
