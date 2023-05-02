using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Rabin_Karp: ISubstringSearch
    {
        public List<int> SubstringSearch(string pat, string txt)
        {
            List<int> answer = new List<int>();
            int q = 14969;
            int d = 256;
            int M = pat.Length;
            int N = txt.Length;

            int patHash;

            int txtHash;
            int firstIndexHash = 1;

            patHash = (int)pat[0] % q;
            txtHash = (int)txt[0] % q;
            for (int i = 1; i < M; i++)
            {
                patHash = ((patHash<<8)+ (int)pat[i])%q;
                txtHash = ((txtHash<<8)+ (int)txt[i])%q;
                firstIndexHash = (firstIndexHash<<8)%q;
            }

            for (int i = 0; i <= N - M; i++)
            {

                if (patHash == txtHash)
                {
                    bool f = true;
                    for (int j = 0; j < M; j++)
                    {
                        if (txt[i + j] != pat[j])
                        {
                            f = false;
                        }
                    }
                    if (f)
                        answer.Add(i);
                }

                if (i < N - M)
                {
                    txtHash -= ((int)(txt[i]) * firstIndexHash) % q;
                    txtHash =(((txtHash+ q)<<8)+ (int)(txt[i + M]))%q;
                }
            }
            return answer;
        }


    }
}

