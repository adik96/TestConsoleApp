using System;

namespace ConsoleApp1
{
    public static class Multithreading
    {
        public static void Test1()
        {
            Thread thread1 = new Thread(TestMethod);
            Thread thread2 = new Thread(new ThreadStart(TestSingMethod));

            

            thread1.Start();
            
            thread2.Start();
            Console.WriteLine(ThreadPool.ThreadCount);
        }

        public static void TestMethod()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("Do something... [" + i + "]");
                if (i % 3 == 0)
                {
                    Console.WriteLine("Sleep 30 ms");
                    Thread.Sleep(30);
                }
            }
        }

        public static void TestSingMethod()
        {
            for (int i = 0; i < 30; i++)
            {
                if (i % 4 == 0)
                {
                    Console.WriteLine("Sleep 30 ms");
                    Thread.Sleep(30);
                }
                Console.WriteLine("Lalalala... [" + i + "]");
            }
        }

        

        public static void MyFunction1(object obj1, object obj2)
        {
            lock (obj1)
            {
                Console.WriteLine("lock 1 - MyFunction1");
                Thread.Sleep(1000);
                lock (obj2)
                {
                    Console.WriteLine("lock 2 - MyFunction1");
                }
            }
        }

        public static void MyFunction2(object obj1, object obj2)
        {
            lock (obj2)
            {
                Console.WriteLine("lock 2 - MyFunction2");
                Thread.Sleep(1000); 
                lock (obj1)
                {
                    Console.WriteLine("lock 1 - MyFunction2");
                }
            }
        }

        public static void DeadlockTest()
        {
            object obj1 = new object();
            object obj2 = new object();

            Thread thread1 = new Thread(() => MyFunction1(obj1, obj2));
            Thread thread2 = new Thread(() => MyFunction2(obj1, obj2));

            thread1.Start();
            thread2.Start();

            
        }

        public static void Test2()
        {
            Thread thread1 = new Thread(LockMethod);
            thread1.Name = "thread1";
            Thread thread2 = new Thread(LockMethod);
            thread2.Name = "thread2";

            thread1.Start();
            thread2.Start();
        }

        public static void LockMethod()
        {
            object initLock = new object();

            Console.WriteLine("przed lock - " + Thread.CurrentThread.Name);
            lock (initLock)
            {
                Console.WriteLine("w lock - " + Thread.CurrentThread.Name);

                Console.WriteLine("lock - LockMethod -- " + Thread.CurrentThread.Name);
                Thread.Sleep(1000); 
            }
            Console.WriteLine("po lock - " + Thread.CurrentThread.Name);
        }
    }
}
