﻿using System;
using System.Collections.Generic;
using System.Collections;
using Verification;

namespace _12lab
{
    class Program
    {
        #region ConsoleWork

        static void openCons()
        {
            Console.CursorLeft = 1;
            Console.CursorTop += 2;
            Console.WriteLine("Для продолжение нажмите любую клавишу. \n" +
                " Внимание! Текущая консоль будет очищена.");
            Console.ReadKey();
        }                                                    // ожидание клика
        static int ShowMenu(string description, params string[] yourItems)
        {
            // функция, выводящая меню и возвращающая номер выбранного элемента (нуерация номера с 1)
            // очищает консоль
            // формат входных данных:
            // строка-описание меню, выводится сразу же
            // массив строк - пунктов меню. можно передавать через запятые
            Console.Clear();
            Console.WriteLine(description);
            int previousTop = Console.CursorTop;

            // Описание переменных и массивов для программы вывода меню
            int currentIndex = 0, previousIndex = 0, i;
            int positionX = 5, positionY = Console.CursorTop;
            bool itemSelected = false;

            // Пункты меню
            string[] items = yourItems;

            //Начальный вывод пунктов меню.
            for (i = 0; i < items.Length; i++)
            {
                // позиционирование
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + i;
                // выбор цвета кисти
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                // выписать пункт
                Console.Write(items[i]);
            }

            do
            {
                // Вывод предыдущего активного пункта основным цветом.
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + previousIndex;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[previousIndex]);

                //Вывод активного пункта.
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + currentIndex;
                Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(items[currentIndex]);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                previousIndex = currentIndex;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        currentIndex++;
                        break;
                    case ConsoleKey.UpArrow:
                        currentIndex--;
                        break;
                    case ConsoleKey.Enter:
                        itemSelected = true;
                        break;
                }

                if (currentIndex == items.Length)
                    currentIndex = items.Length - 1;
                else if (currentIndex < 0)
                    currentIndex = 0;
            } while (!itemSelected);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorTop = 2 + items.Length + previousTop;
            return ++currentIndex;
        }        // вывод меню
        static int AskNum(string description)
        {
            Console.WriteLine(description);
            int n;
            while (!(int.TryParse(Console.ReadLine(), out n)) || !(n > 0))
                Console.WriteLine("Неверный ввод. ");

            return n;
        }
        static int AskNum(string description, int num)
        {
            Console.WriteLine(description);
            int n;
            while (!(int.TryParse(Console.ReadLine(), out n)) || !(n > 0) || !(n < num))
                Console.WriteLine("Неверный ввод. ");

            return n;
        }

        #endregion

        static Random rand = new Random();

        static void Create(Hashtable l)
        {
            l.Clear();
            int num = AskNum("Введите количество элементов");
            Verification.Verification cur;

            for (int i = 0; i < num; i++)
            {
                switch (rand.Next(0,2))
                {
                    case 1:
                        cur = new Test();
                        break;
                    case 2:
                        cur = new Exam();
                        break;
                    default:
                        cur = new FinalExam();
                        break;
                }
                l.Add(cur.ToString(), cur);
            }
        }
        static void Add(Hashtable l)
        {
            Verification.Verification cur;
            switch (rand.Next(0, 2))
            {
                case 1:
                    cur = new Test();
                    break;
                case 2:
                    cur = new Exam();
                    break;
                default:
                    cur = new FinalExam();
                    break;
            }
            l.Add(cur.ToString(), cur);
        }
        static void Delete(Hashtable l)
        {
            foreach (Verification.Verification ver in l)
            {
                Console.WriteLine("Этот удалить? (да)");
                if (Console.ReadLine() == "да") l.Remove(ver.ToString());
            }
        }
        static void Show(Hashtable l)
        {
            foreach(Verification.Verification ver in l)
            {
                Console.WriteLine(ver.ToString() + "\n");
            }
        }
        static void Count(Hashtable l)
        {
            int count = 0;
            foreach (Test t in l)
            {
                count++;
            }
            Console.WriteLine("Тестов: " + count);
        }
        static void ShowFinal(Hashtable l)
        {
            foreach (FinalExam f in l)
            {
                Console.WriteLine(f.ToString());
            }
        }
        static void HashCods(Hashtable l)
        {
            foreach (Exam e in l)
            {
                Console.WriteLine("Хеш-код: " + (e.ToString()).GetHashCode() + "\nВыражение: ");
                Console.WriteLine(e.ToString());
            }
        }
        static Hashtable Clone(Hashtable l) {
            Hashtable clone = (Hashtable)l.Clone();
            Show(clone);
            return clone;
        }
        static void Sort(Hashtable l) {
            Array arr = null;
            int ind = 0;
            foreach (Verification.Verification ver in l)
            {
                l.CopyTo(arr, ind);
                ind++;
            }
            Array.Sort(arr);
            Console.WriteLine("Попытка первая, через отправление все в array");
            foreach (Verification.Verification ver in arr)
                Console.WriteLine(ver.ToString());

            Console.WriteLine("Попытка 2: ");
            Hashtable h = Clone(l);
            Array.Sort((Array)(h.Keys), (Array)(h.Values));
            Show(h);
        }
        static void Search(Hashtable l) {
            foreach (Verification.Verification ver in l)
            {
                Console.WriteLine("Этот поискать? (да)");
                if (Console.ReadLine() == "да")
                {


                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" Кузнецовой Влады. В мире Варьки\n" +
                " Лабораторная работа №12 (старая нумерация 11)\n" +
                " Структура испытание -> тест, испытание -> экз -> финальный экз\n" +
                " Текст задания: \n" +
                " 1. создать коллекцию, добавить туда объекты\n" +
                " 2. используя меню, реализовать добавление и удаление объектов\n" +
                " 3. запросы кол-ва эл-ов опр-ого вида, печать опр-ого вида, еще что-то (3 запроса)\n" +
                " 4. перебор через foreach\n" +
                " 5. клонирование коллекции\n" +
                " 6. сортировку коллекции и поиск элемента"
                );
            openCons();

            Hashtable list = new Hashtable();
            int choise = 1;
            while (choise != 11)
            {
                switch (choise)
                {
                    case 1:
                        Create(list);
                        break;
                    case 2:
                        Add(list);
                        break;
                    case 3:
                        Delete(list);
                        break;
                    case 4:
                        Show(list);
                        break;
                    case 5:
                        Count(list);
                        break;
                    case 6:
                        ShowFinal(list);
                        break;
                    case 7:
                        HashCods(list);
                        break;
                    case 8:
                        Clone(list);
                        break;
                    case 9:
                        Sort(list);
                        break;
                    case 10:
                        Search(list);
                        break;
                }

                choise = ShowMenu("Введите, что бы вы хотели сделать",
                    "Создать коллекцию", "Добавить элемент", "Удалить элемент",
                    "Напечатать foreach", "Сколько тестов", "Все финальные экзамены", "Хеш-коды экзов",
                    "Клонирование", "Сортировка по дате");
            }
        }
    }
}
