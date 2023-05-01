using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Boyer_Moore: ISubstringSearch
    {
		public static void BadCharacterHeuristic(string Substring, int SubstringSize, int[] badcharacters)
		{
			for (int i = 0; i < 256 * 5; i++)
			{
				badcharacters[i] = -1;
			}
			for (int i = 0; i < SubstringSize; i++)//По сути, пары <ключ, значение>
			{
				badcharacters[Substring[i]] = i;
			}
		}
		public List<int> SubstringSearch(string Substring, string Source)
		{
			List<int> result = new List<int>();
			int m = Substring.Length;
			int n = Source.Length;
			int[] badcharacter = new int[256 * 5];
			BadCharacterHeuristic(Substring, m, badcharacter);//Составление таблицы плохих символов
			int index = 0;
			while (index <= (n - m))// Двигаемся до конца текста
			{
				int j = m - 1;
				while (j >= 0 && Substring[j] == Source[index + j])//уменьшаем j до тех пор, пока символы Substring и Source не совпадут при текущем значениинии сдвига
				{
					j--;
				}
				if (j < 0)//Указатель на наличие паттерна в текущем значениинии сдвига
				{
					result.Add(index);
					//Сдвиг index + m < n необходим для обработки шаблона в конце текста
					if (index + m < n)
					{
						index += m - badcharacter[Source[index + m]];
					}
					else
					{
						index += 1;
					}
				}
				else//Максимум дает положительный сдвиг (если последнее появление плохого символа находится справа от текущего, то возможно отрицательное значение сдвига)
				{
					index += Math.Max(1, j - badcharacter[Source[index + j]]);
				}
			}
			return result;
		}
	}
}
