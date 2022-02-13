using System;

namespace NGPInform_TestTask
{
    class Program
    {
        // O(n logn)
        // Отсортируем массив по возрастанию, найдем произведениедвух первых элементов с последним
        // И произведение трех последних элементов
        // Вернем максимум
        public int Product1(int[] list, int n)
        {
            Array.Sort(list); // Сортировка выполнится за O(n logn)

            // Максимум достигается в двух случаях:
            // Первые два элемента - отрицательные, они умножаются на последний элемент массива
            //
            int pr1 = list[0] * list[1] * list[n - 1];
            int pr2 = list[n - 3] * list[n - 2] * list[n - 1];
            return Math.Max(pr1, pr2);
        }




        // О(n)
        // Найдем три наибольших числа
        // И два наименьших
        // Найдем мксимальное произведение
        public int Product2(int[] list, int n)
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;
            int max3 = int.MinValue;

            int min1 = int.MaxValue;
            int min2 = int.MaxValue;


            for (int i = 0; i <n; ++i)
            {
                if (list[i] > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = list[i];
                }
                else if (list[i] > max2)
                    {
                        max3 = max2;
                        max2 = list[i];
                    }
                else if (list[i] > max3)
                {
                    max3 = list[i];
                }


                if (list[i] < min1)
                {
                    min2 = min1;
                    min1 = list[i];
                }
                else if (list[i] < min2)
                {
                    min2 = list[i];
                }

                int pr1 = max1 * max2 * max3;
                int pr2 = min1 * min2 * max1;
                return Math.Max(pr1, pr2);

            }

            return - 1;
        }


        static void Main(string[] args)
        {
            int N = 7;
            int[] list_of_ints = new int[N];

            if (N < 3)
            {
                Console.WriteLine("Размер массива меньше 3");
                return;
            }

            

            Random rnd = new Random();

            // Тесты
            int numb_of_tests = 10;
            for (int counter = 0; counter < numb_of_tests; ++counter)
            {
                Console.WriteLine("Тест номер " + counter.ToString());
                Console.Write("Массив: [");
                for (int i = 0; i < N; ++i)
                {
                    list_of_ints[i] = rnd.Next(-10, 10);
                    if (i != N - 1)
                        Console.Write(list_of_ints[i].ToString() + ", ");
                    else
                        Console.WriteLine(list_of_ints[i].ToString() + "]");
                }

                Program pr = new Program();


                // первый вариант
                Console.WriteLine("Var1 - Произведение: " + pr.Product1(list_of_ints, N).ToString());

                // второй вариант
                Console.WriteLine("Var2 - Произведение: " + pr.Product1(list_of_ints, N).ToString());
            }


        }
    }
}
