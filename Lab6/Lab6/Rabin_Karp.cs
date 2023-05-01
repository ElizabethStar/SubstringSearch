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
            ulong q = 2147483647;
            ulong d = 256;
            int M = pat.Length;
            int N = txt.Length;

            ulong patHash;

            ulong txtHash;
            ulong firstIndexHash = 1;

            patHash = (ulong)pat[0] % q;
            txtHash = (ulong)txt[0] % q;
            for (int i = 1; i < M; i++)
            {
                patHash = (patHash*d+ (ulong)pat[i])%q;
                txtHash = (txtHash*d+ (ulong)txt[i])%q;
                firstIndexHash = firstIndexHash*d%q;
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
                    txtHash -= ((ulong)(txt[i]) * firstIndexHash) % q;
                    txtHash =((txtHash+ q)*d+ (ulong)(txt[i + M]))%q;
                }
            }
            return answer;
        }


    }
}

