using System;
using System.Collections;
using System.Collections.Generic;
using Verification;

namespace _2task
{
    class Program
    {

        static Random rand = new Random();

        #region ConsoleWork

        static void OpenCons()
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

        #endregion
        #region задания
        static void Create(Queue<Verification.Verification> l)
        {
            l.Clear();
            int num = AskNum("Введите количество элементов");
            Verification.Verification cur;

            for (int i = 0; i < num; i++)
            {
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
                l.Enqueue(cur);
            }
        }
        static void Add(Queue<Verification.Verification> l)
        {
            Verification.Verification cur;
            switch (rand.Next(1, 4))
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
            l.Enqueue(cur);
        }
        static void Delete(Queue<Verification.Verification> l)
        {
            l.Dequeue();
        }
        static void Show(Queue<Verification.Verification> l)
        {
            Array arr = l.ToArray();
            foreach (Verification.Verification ver in arr)
                Console.WriteLine(ver + "\n");
        }
        static void Count(Queue<Verification.Verification> l)
        {
            int count = 0;
            Array arr = l.ToArray();

            foreach (Verification.Verification t in l)
                if (t is Test) count++;
            Console.WriteLine("Тестов: " + count);
        }
        static void ShowFinal(Queue<Verification.Verification> l)
        {
            Array arr = l.ToArray();

            foreach (Verification.Verification f in l)
            {
                if (f is FinalExam) Console.WriteLine(f);
            }
        }
        static void HashCods(Queue<Verification.Verification> l)
        {
            Array arr = l.ToArray();

            foreach (Verification.Verification e in l)
            {
                Console.WriteLine("Хеш-код: " + e.ToString().GetHashCode() + "\nВыражение: ");
                Console.WriteLine(e);
            }
        }
        static void Clone(Queue<Verification.Verification> l)
        {
            Array arr = l.ToArray();
            Queue<Verification.Verification> clone = null;
            foreach (Verification.Verification ver in arr)
            {
                clone.Enqueue(ver);
            }
            
            Show(clone);
        }
        static void Sort(Queue<Verification.Verification> l)
        {
            Array arr = l.ToArray();

            Array.Sort(arr);

            foreach (Verification.Verification v in arr)
                Console.WriteLine(v.ToString());
        }
        static void Search(Queue<Verification.Verification> l)
        {
            Array arr = l.ToArray();
            Array.Sort(arr);

            foreach (Verification.Verification ver in arr)
            {
                Console.WriteLine(ver);
                Console.WriteLine("Этот поискать? (да)");
                if (Console.ReadLine() == "да")
                {
                    int n = Array.BinarySearch(arr, ver);
                    Console.WriteLine("Номер: " + n);
                    return;
                }
            }
        }
        #endregion

        static void Main()
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
                              " 6. сортировку коллекции и поиск элемента" +
                              " Вариант 5, HashTable"
            );
            OpenCons();

            Queue<Verification.Verification> list = new Queue<Verification.Verification>();
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
                OpenCons();
                choise = ShowMenu("Введите, что бы вы хотели сделать",
                    "Создать коллекцию", "Добавить элемент", "Удалить элемент",
                    "Напечатать foreach", "Сколько тестов", "Все финальные экзамены", "Хеш-коды",
                    "Клонирование", "Сортировка", "Поиск");
            }
        }


    }
}
