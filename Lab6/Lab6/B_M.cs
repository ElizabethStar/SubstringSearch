using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class B_M : ISubstringSearch
    {

        public void preprocess_strong_suffix(int[] shift, int[] borderPositions, char[] p, int m)
        {
            int i = m, j = m + 1;
            borderPositions[i] = j;
            while (i > 0)
            {
                while (j <= m && p[i - 1] != p[j - 1])
                {
                    if (shift[j] == 0) shift[j] = j - i;
                    j = borderPositions[j];
                }
                i--; j--;
                borderPositions[i] = j;
            }
        }


        public void preprocess_case2(int[] shift, int[] borderPositions, int m)
        {
            int i, j;
            j = borderPositions[0];
            for (i = 0; i <= m; i++)
            {
                if (shift[i] == 0) shift[i] = j;
                if (i == j) j = borderPositions[j];
            }
        }
        public List<int> SubstringSearch(string pat, string text)
        {
            List<int> list = new List<int>();
            int s = 0, j;
            int m = pat.Length;
            int n = text.Length;

            int[] borderPositions = new int[m + 1];
            int[] shift = new int[m + 1];

            for (int i = 0; i < m + 1; i++)
                shift[i] = 0;

            preprocess_strong_suffix(shift, borderPositions, pat.ToArray(), m);
            preprocess_case2(shift, borderPositions, m);

            while (s <= n - m)
            {
                j = m - 1;

                while (j >= 0 && pat[j] == text[s + j])
                    j--;

                if (j < 0)
                {
                    list.Add(s);
                    s += shift[0];
                }
                else
                    s += shift[j + 1];
            }
            return list;

        }



    }
    //public class B_M: ISubstringSearch
    //{
    //    public void preprocess_strong_suffix(int[] shift, int[] bpos,
    //                               char[] pat, int m)
    //    {

    //        int i = m, j = m + 1;
    //        bpos[i] = j;

    //        while (i > 0)
    //        {

    //            while (j <= m && pat[i - 1] != pat[j - 1])
    //            {

    //                if (shift[j] == 0)
    //                    shift[j] = j - i;


    //                j = bpos[j];
    //            }

    //            i--; j--;
    //            bpos[i] = j;
    //        }
    //    }


    //    public void preprocess_case2(int[] shift, int[] bpos,
    //                                char[] pat, int m)
    //    {
    //        int i, j;
    //        j = bpos[0];
    //        for (i = 0; i <= m; i++)
    //        {
    //            if (shift[i] == 0)
    //                shift[i] = j;

    //            if (i == j)
    //                j = bpos[j];
    //        }
    //    }
    //    public List<int> SubstringSearch(string pat, string text)
    //    {
    //        List<int> list = new List<int>();
    //        int s = 0, j;
    //        int m = pat.Length;
    //        int n = text.Length;

    //        int[] bpos = new int[m + 1];
    //        int[] shift = new int[m + 1];

    //        for (int i = 0; i < m + 1; i++)
    //            shift[i] = 0;

    //        preprocess_strong_suffix(shift, bpos, pat.ToArray(), m);
    //        preprocess_case2(shift, bpos, pat.ToArray(), m);

    //        while (s <= n - m)
    //        {
    //            j = m - 1;

    //            while (j >= 0 && pat[j] == text[s + j])
    //                j--;

    //            if (j < 0)
    //            {
    //                list.Add(s);
    //                s += shift[0];
    //            }
    //            else
    //                s += shift[j + 1];
    //        }
    //        return list;
    //    }
    //}
}
