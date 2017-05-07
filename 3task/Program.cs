using System;
using System.Collections.Generic;

namespace _3task
{
    class Program
    {

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

        #region tasks

        

        #endregion


        static void Main()
        {

            Console.WriteLine(" Кузнецовой Влады. В мире Варьки\n" +
                              " Лабораторная работа №12 (старая нумерация 11)\n" +
                              " Вариант 5, MyStack\n" +
                              " Реализовать обобщенные коллекции:\n" +
                              " Реализовать конструкторы: без параметров, параметром-числом, параметром-коллекцией, параметром-массивом\n" + 
                              " Реализовать в коллекциях интерфейсы IEnurable, IEnumerator\n" + 
                              " Методы коллекции: \n" +
                              "     Capacity - свойство, емкость,\n" + 
                              "     Item - get/set по номеру,\n" +
                              "     Count - свойство, фактическое кол-во,\n" +
                              "     Contains(obj v) - проверка наличия в стеке,\n" +
                              "     Clear - эффективно очищает стек,\n" +
                              "     Peek - возврат элемента в вершине стека, \n" +
                              "     Pop - удаление элемента в вершине стека, его возврат,\n" +
                              "     Push(obj v) - помещает в стек,\n" +
                              "     ToArray - возвращает массив с копиями элементов, \n" +
                              "     Clone - поверхностное копирование,\n" +
                              "     CopyTo - копирует в массив с индекса" 
            );
            OpenCons();

            int choise = 1;

            while (choise != 9)
            {
                switch (choise)
                {
                    case 1:
                        // create
                    case 2:
                        // properties (capacity and count)
                    case 3:
                        // contains, auto with random and elem from stack
                    case 4:
                        // clear, so, redirect to create
                    case 5:
                        // peek, pop, push
                    case 6:
                        // to array, copyTo
                    case 7:
                        // clone
                    case 8: 
                        // remind
                        break;
                }

                OpenCons();
                choise = ShowMenu(" Выберите действие", "Создать", "Свойства", "Contains",
                    "Clear", "Peek, Pop, Push","ToArray, CopyTo", "Clone", "Show");
            }


        }
    }
}
