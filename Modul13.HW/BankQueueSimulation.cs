using System;
using System.Collections.Generic;

class BankQueueSimulation
{
    static Queue<Client> clientQueue = new Queue<Client>();
    static List<Client> servedClients = new List<Client>();

    public static void StartSimulation()
    {
        while (true)
        {
            Console.WriteLine("1. Встать в очередь");
            Console.WriteLine("2. Обслужить следующего клиента");
            Console.WriteLine("3. Показать среднее время ожидания");
            Console.WriteLine("4. Показать историю обслуженных клиентов");
            Console.WriteLine("5. Выйти");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BankOperations.EnqueueClient(clientQueue);
                    break;
                case "2":
                    BankOperations.ServeNextClient(clientQueue, servedClients);
                    break;
                case "3":
                    BankOperations.DisplayAverageWaitTime(servedClients);
                    break;
                case "4":
                    BankOperations.DisplayServedClientsHistory(servedClients);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
