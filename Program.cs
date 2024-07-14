using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    /*
    static bool StopkRavny(int[] chips2, int dim2, int midl2)
    {
        //равны ли стопки. дим2-размерность массива, для удобства работы. Мидл2-среднее число фишек которое должно быть у игрока

        int test2 = 0;
        while (test2 < dim2)
        {
            if (chips2[test2] != midl2)
            {
                return (false);
                //нашлась неправильная стопка
            }
            test2++;

        }

        //пока полузаглушка, надо гонять
        return (true);
    }




    public static int MinStopka(int[] chips1, int dim)
    {
        int test = 0, tmin = 0, test2 = 0;
        tmin = chips1[test];

        while (test2 < dim)
        {
            if (chips1[test2] < tmin)
            {
                tmin = chips1[test2];
                test = test2;

            }
            test2++;

        }

        return (test);
        //функция должна возвращать положение наименьшей кучки фишек
    }
    */
    //но это не совсем то что нужно по алгоритму. нужны все такие минимальные стопки!
    //т.е. мы провели первый шаг, нашли минимальное значение фишек в стопках, теперь надо найти все
    //такие минимальные  стопки



    /*Если стопки не равны, то цикл
          Определяются стопки с наименьшим количеством фишек
          Из найденных стопок выбирается та рядом с которой самая большая стопка
            Из большей стопки перекладывается в меньшую.
           Возврат на 1-й шаг*/
    
    /*
    public static int[] VseMinStopki(int[] chips, int dim, int minimum, ref int dim2)
    {
        int[] minchips = { 0 };//c помощью этого массива вернём номера минимальных стопок и длина его будет dim2
        int[] chips3 = { 0 };//промежуточный массив для помещения номеров минимальных стопок
        int count = 0, i = 0;

        Array.Resize(ref chips3, dim);//чтобы точно поместились минимальные стопки

        while (i < dim)
        {
            if (chips[i] == minimum)
            {
                chips3[count] = i;
                count++;
                //каждый раз когда попадаем на минимальную стопку, добавляем её номер в очередной элемент
                //массива chips3
            }
            i++;
        }


        dim2 = count;
        if (dim2 == 0)
        {
            //вдруг случится внутренний сбой, надо разбирать будет
            Console.WriteLine("внутренний сбой, надо разбирать");
            dim2 = 1;
        }

        i = 0;
        Array.Resize(ref minchips, dim2);
        while (i < dim2)
        {
            minchips[i] = chips3[i];
            i++;
        }


        return (minchips);
      
    }







    public static void Sosedi(int indstopk, int dim, ref int neigh1, ref int neigh2)
    {

        //разбираем сперва краевые случаи, когда рассмаривается первая или самая последняя стопка
        if (indstopk == 0)
        {
            neigh1 = dim - 1;
            neigh2 = 1;
            return;
        }

        if (indstopk == dim - 1)
        {
            neigh1 = dim - 2;
            neigh2 = 0;
            return;
        }

        //соседи в общем случае
        neigh1 = indstopk - 1;
        neigh2 = indstopk + 1;

        return;
        
    }
    */
    //..остатки первоначального неоптимального алгоритма


   

    public static int[] sdvigrazrez(int[] mass, int dim3, int sdvig)
    {
        if (sdvig >= dim3||sdvig<0) return (mass);//защита

        int[] massprom = { 0 };
        //сдвигаем массив "вправо", сохраняя его в масспром
        int i = 0,j=0;


        Array.Resize(ref massprom, dim3);



        while (i < dim3-sdvig) 
          {
            massprom[i+sdvig] = mass[i];
            i++;
          }

        i = dim3 - sdvig;
        //

        while (j < sdvig)
          {
            massprom[j] = mass[j + i];
            j++;
          }
        //образно говоря --поворот стола вправо на sdvig и разрезание.

        return (massprom);
      //  
    }



    //трассировка для контроля
    public static void Print1(int[] chips4, int dim4)
    {
        int i = 0;

        while (i < dim4)
        { 
            Console.Write(" {0} ",chips4[i]);
            i++;
        }

        Console.WriteLine();

        //трассировка для контроля
        return;
    }

    //алгоритм "руки"
    public static int AlgRuki1(int midl4, int[] chips4, int dim4)
    {
        int hand = 0;
        int i = 0;
        int otvet = 0;
        int tst1;


        while (i < dim4) 
        {
            // Имеем фишки "в руке". Если сейчас у игрока больше чем надо фишек, мы
            // забираем лишние в руку. Если не хватает - отдаём с руки (да в руке
            // может быть отрицательное число). После каждого шага добавляем к
            // ответу модуль того что в руке.
            tst1 = chips4[i];
            if (tst1 > midl4)
            {
                hand += tst1 - midl4;
                //забираем в руку
            }
            else 
            {
                hand -= midl4 - tst1;
                //отдаём из руки
            }
            otvet += Math.Abs(hand);
            //прибавляем к сумме модуль "руки"

            i++;
        }

        return(otvet);
        }




    private static void Main(string[] args)
    {

        Console.WriteLine("Hose and chips");

        /*Давайте решим это задачу если бы был обычный стол (не круглый). Алгоритм простой. Идём сначала. Имеем монеты "в руке".
         * Если сейчас у игрока больше чем надо монет, мы забираем лишние в руку. Если не хватает - отдаём с руки (да в руке может быть отрицательное число).
         * После каждого шага добавляем к ответу модуль того что в руке.

..

Теперь если у нас стол круглый. По сути, не нарушая общности его можно разрезать в любом месте, главное знать сколько
        фишек уйдёт через границу не в том направлении обхода.

..эту ситуацию можно перебрать...
        */



        String line1 = new string(""), line2 = new string("");
        String line3 = new string(""), line4 = new string("");
        string[] chips0;//сюда разместим записи о фишках из строки ввода

        int midl1 = new int();//среднее число фишек, поставленное Хосе
      //  int minimum = 0;//текущий минимум фишек
        //int maks = 1;//сслужебный максимум фишек

        int dim = new int();//число игроков
        int[] chips1 = { 1, 1 };//фишки

        int[] minchips2 = { 0 };//номера минимальных стопок фишек будут тут
        //int dim22 = 0;//и длина этого массива


        int test = 0, test1 = 0, i = 0;//служебные переменные для подсчётов
       // bool stprv = false;//равны ли стопки


        int steps = 0;//шаги алгоритма
       // int neigh1 = 0, neigh2 = 0, neightek = 0, z1, z2, z;//соседи обрабатываемой стопки
       // int tek_stp = 0;//служебная переменная для обработки стопок
        //int tek_minstpk = 0;//служебная переменная для обработки стопок
        int sdvig2 = 0;//служебная переменная
        int[] mass2= { 0 };//служебная переменная
        int[] steps3 = { 0 };//служебная переменная



        ///загружаем массив фишек
        try
        {   // Открываем текстовый файл входных данных с помощью средства чтения потока 
            //файл должен лежать в одной директории с екзешником проекта
            using (StreamReader sr = new StreamReader("input2.txt"))
            {
                // Содержимое текстового файла копируется в строку, а строка выводится на консоль
                //String 
                line1 = sr.ReadToEnd();
                Console.WriteLine(line1);
                //надо будет просто парсить её, особую защиту "от дурака" не предусматриваем
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Файл входных данных не может быть прочитан!:");
            Console.WriteLine(e.Message);
        }


        if (line1.Contains("chips:"))

        {
            line2 = line1.Replace("chips:", "");
            //парсим строку входных данных, особую защиту "от дурака" не предусматриваем
            //Console.WriteLine(line1);
           //Console.WriteLine(line2);
            line3 = line2.Replace("[", "");
            line4 = line3.Replace("]", "");
            //Console.WriteLine(line4);

            chips0 = line4.Split(',');//разрезаем строку на массив подстрок по запятой

            //dim = Array.Length(chips0);
            dim = 0;
            foreach (string item in chips0)
            {
                
                dim++;
                //..test1 = String.ParseInt();
                test = Convert.ToInt32(item);
                test1 += test;
                //Console.Write(" {0}  ", test);//просто трассировка была

            }//не очень удобный подсчёт числа игроков


            midl1 = test1 / dim;//сколько фишек должно быть у каждого игрока по изначальному решению Хосе


            Console.WriteLine();



            //Console.WriteLine("число игроков {0}", dim);
            //Console.WriteLine("число фишек которое в итоге должно быть у игрока {0}", midl1);

            Array.Resize(ref chips1, dim);
            //выставляем массиву фишек размерность по числу игроков

            test1 = 0;
            foreach (string item in chips0)
            {


                test = Convert.ToInt32(item);
                chips1[test1] = test;
                //заполняем целочисленный массив фишек, он потребуется для работы алгоритма
                test1++;

            }






            Array.Resize(ref steps3, dim);

            sdvig2 = 0;

            while (sdvig2 < dim)
            {
            
                //алгоритм "руки" с перебором сдвига разреза стола  реализуем

                mass2 = sdvigrazrez(chips1, dim, sdvig2);
                
                //Print1(mass2, dim);
                //просто трассировка

                steps = AlgRuki1(midl1, mass2, dim);
              //  Console.WriteLine("{0} шагов потребовалось алгоритму при таком разрезе стола",steps);
                ///получилос


                steps3[sdvig2] = steps;

                sdvig2++;
            }


            //теперь ищем минимум в массиве "чисел шагов"  степс3
            steps = steps3[0];
            i = 0;
            while(i<dim)
            {
                if (steps > steps3[i])
                 {
                    steps = steps3[i];
                 }
                i++;

            }



            Console.WriteLine(steps);



           



          




        }



    }
}
