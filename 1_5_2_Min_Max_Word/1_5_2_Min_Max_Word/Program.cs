using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _1_5_2_Min_Max_Word
{
    class Program
    {
        /// <summary>
        /// Ввод текста
        /// </summary>
        /// <returns></returns>
        static string Input()
        {
            return ReadLine();
        }
        /// <summary>
        /// Ввод чисел и проверка соответствия условиям
        /// </summary>
        /// <param name="paramMax">Максимальное значение для вводимого числа</param>
        /// <param name="paramMin">Минимальное значение для вводимого числа</param>
        /// <returns>Проверенное введенное число</returns>
        static int Input(int paramMax, int paramMin)
        {
            int input;
            while (true)
            {
                if (int.TryParse(ReadLine(), out input) && input <= paramMax && input >= paramMin) break;
                else Write($"Число должно быть целым от {paramMin} до {paramMax}, попробуйте еще раз: ");
            }
            return input;
        }

        /// <summary>
        /// Принимает текст и возвращает слова, содержащие максимальное кол-во букв
        /// </summary>
        /// <param name="theText">Исходный текст</param>
        /// <returns>Массив самых длинных слов</returns>
        static string [] WordMax (string theText)
        {
            int count = 0;
            string[] words = theText.Split(new char[] {' ', ',', '.'}, StringSplitOptions.RemoveEmptyEntries);
            int length = words[0].Length;

            for (int ind = 0; ind < words.Length; ind++)
            {
                if (words[ind].Length > length) length = words[ind].Length;
            }
            foreach (string e in words)
            {
                if (e.Length == length) count++;
            }

            string[] theWords = new string[count];
            count = 0;

            for (int ind = 0; ind < words.Length; ind++)
            {
                if (words[ind].Length == length)
                {
                    theWords[count] = words[ind];
                    count++;
                }
            }

            return theWords;
        }

        /// <summary>
        /// Принимает текст и возвращает слова, содержащие минимальное кол-во букв
        /// </summary>
        /// <param name="theText">Исходный текст</param>
        /// <returns>Массив самых коротких слов</returns>
        static string[] WordMin(string theText)
        {
            int count = 0;
            string[] words = theText.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            int length = words[0].Length;

            for (int ind = 0; ind < words.Length; ind++)
            {
                if (words[ind].Length < length) length = words[ind].Length;
            }
            foreach (string e in words)
            {
                if (e.Length == length) count++;
            }

            string[] theWords = new string[count];
            count = 0;

            for (int ind = 0; ind < words.Length; ind++)
            {
                if (words[ind].Length == length)
                {
                    theWords[count] = words[ind];
                    count++;
                }
            }

            return theWords;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Write("Введите текст: ");
                string text = Input();

                WriteLine("\n--------------------------------");
                WriteLine("Самые большие слова:\n");

                foreach (string e in WordMax(text))
                {
                    WriteLine(e);
                }
                ReadKey(true);
                WriteLine("\n--------------------------------");
                WriteLine("Самые маленькие слова:\n");

                foreach (string e in WordMin(text))
                {
                    WriteLine(e);
                }
                ReadKey(true);
                WriteLine("\n--------------------------------\n");

                #region Повтор или выход

                WriteLine("Запустить заново? 1 - Повтор | 0 - Выход");
                Write("Выбор: ");
                if (Input(1, 0) == 0) break; // Завершение программы
                WriteLine();

                #endregion
            }
        }
    }
}
