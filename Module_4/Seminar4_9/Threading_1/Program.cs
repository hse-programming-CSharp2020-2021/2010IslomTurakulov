using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Task_1
{
    class BankAccount
    {
        private object thisLock = new object();

        volatile int accountAmount;

        private static Random rand = new Random();

        public BankAccount(int sum)
        {
            accountAmount = sum;
        }

        private int Buy(int sum)
        {
            Thread currentThread = Thread.CurrentThread;
            switch (accountAmount)
            {
                case 0:
                    throw new InvalidOperationException($"Нулевой баланс{currentThread.GetHashCode()}");
                case < 0:
                    throw new InvalidOperationException($"Отрицательный баланс {currentThread.GetHashCode()}");
                default:
                {
                    bool lockBool = false;
                    try
                    {
                        Monitor.Enter(thisLock, ref lockBool);

                        if (accountAmount >= sum)
                        {
                            Console.WriteLine($"Текущий поток: {currentThread.GetHashCode()}");
                            Console.WriteLine($"Состояние счета: {accountAmount}");
                            Console.WriteLine($"Покупка на сумму: {sum}");
                            Console.WriteLine($"Счет после покупки: { accountAmount -= sum}");
                            return sum;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    finally
                    {
                        if (lockBool)
                            Monitor.Exit(thisLock);
                    }
                }
            }
        }

        public void DoTransactions()
        {
            try
            {
                while (true)
                {
                    Buy(rand.Next(1, 50));
                    Thread.Sleep(rand.Next(1, 10));
                }
            }
            catch (InvalidOperationException ex)
            {
                Thread currentThread = Thread.CurrentThread;
                Console.WriteLine($"Обработано исключение: {ex.Message}" + Environment.NewLine + 
                                  $"Поток {currentThread.GetHashCode()}");
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            var threads = new Thread[10];

            var dep = new BankAccount(1000);
            for (int i = 0; i < threads.Length; i++)
                threads[i] = new Thread(dep.DoTransactions);

            for (int i = 0; i < threads.Length; i++)
                threads[i].Start();


        }
    }
}