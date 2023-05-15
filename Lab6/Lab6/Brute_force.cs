using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Brute_force: ISubstringSearch
    {
        public List<int> SubstringSearch(string match, string text)
        {
            List<int> answer = new List<int>();
            //int textLength = text.Length;
            //int matchLenght = match.Length;
            for (int i = 0; i <= text.Length - match.Length; i++)
            {
                //bool OK = true;

                string textpart = text.Substring(i, match.Length);
                if (textpart == match)
                {                 
                    answer.Add(i);
                }
            }
            return answer;

        }
    }
}









//for (int j = 0; j < match.Length; j++)
//{
//    string textChar = text.Substring(i + j, 1);
//    string matchChar = match.Substring(j, 1);
//    if (matchChar != textChar)
//    {
//        OK = false;
//        break;

//    }
//}
