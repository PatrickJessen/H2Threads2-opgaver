using System;
using System.Threading;

namespace Threads2
{
    class Program
    {
        static int counter = 0;
        static object locker = new object();

        static int opg2Counter = 0;
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(CountingUp);
            //Thread t2 = new Thread(CountingDown);
            //t1.Start();
            //t2.Start();

            //t1.Join();
            //t2.Join();

            Thread t3 = new Thread(Stars);
            Thread t4 = new Thread(Hashtags);
            t3.Start();
            t4.Start();

            t3.Join();
            t4.Join();

            Console.Read();
        }

        /// <summary>
        /// Counting our counter 2 up every second using monitor
        /// </summary>
        public static void CountingUp()
        {
            while (true)
            {

                Monitor.Enter(locker);
                try
                {
                    counter += 2;
                    Console.WriteLine($"t1 : {counter}");
                }
                finally
                {
                    Monitor.Exit(locker);
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Counting out counter 1 down every second using monitor
        /// </summary>
        public static void CountingDown()
        {
            while (true)
            {
                Monitor.Enter(locker);
                try
                {
                    counter--;
                    Console.WriteLine($"t2 : {counter}");
                }
                finally
                {
                    Monitor.Exit(locker);
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Prints out * using monitor
        /// </summary>
        public static void Stars()
        {
            while (true)
            {

                string stars = "";
                Monitor.Enter(locker);
                try
                {

                    for (int i = 0; i < 60; i++)
                    {
                        stars += "*";
                        opg2Counter++;
                    }
                    Console.Write(stars + " " + opg2Counter + "\n");
                }
                finally
                {
                    Monitor.Exit(locker);
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Prints out # using monitor
        /// </summary>
        public static void Hashtags()
        {
            while (true)
            {

                string hashtags = "";
                Monitor.Enter(locker);
                try
                {

                    for (int i = 0; i < 60; i++)
                    {
                        hashtags += "#";
                        opg2Counter++;
                    }
                    Console.Write(hashtags + " " + opg2Counter + "\n");
                }
                finally
                {
                    Monitor.Exit(locker);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
