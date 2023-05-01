using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Knuth_Morris_Pratt:ISubstringSearch
    {
        public int[] Prefics(string Search)//префикс функция 
        {
            int[] PreficsFunction = new int[Search.Length];
            for (int i = 1; i < Search.Length; i++)
            {
                int k = PreficsFunction[i - 1];
                while (k > 0 && Search[i] != Search[k])//ищем максимальную длину совпадения( Если символы не равны, используем префиксфункцию для оптимизации сдвигов)
                {
                    k = PreficsFunction[k - 1];
                }
                if (Search[i] == Search[k])
                {                           // если символ совпал увеличиваем значение для префикс функции и после записываем в неё
                    k++;
                }
                PreficsFunction[i] = k;
            }
            return PreficsFunction;
        }
        public List<int> SubstringSearch( string pattern, string text)
        {
            string Search = pattern + '#' + text;
            int[] PreficsFunction = Prefics(Search);

            List<int> shiftCollection = new List<int>();
            for (int i = 0; i < PreficsFunction.Length; i++)
            {
                if (PreficsFunction[i] == pattern.Length)   //проходим по префикс функции забираем в лист все  k равные длине образца вычисляем сдвиг
                {
                    var result = i - 2 * pattern.Length;
                    shiftCollection.Add(result);
                }
            }
            return shiftCollection;
        }
    }
}
