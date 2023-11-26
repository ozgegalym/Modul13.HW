using System;
using System.Collections.Generic;

class BankOperations
{
    public static void EnqueueClient(Queue<Client> clientQueue)
    {
        Console.Write("Введите ИИН клиента: ");
        string clientId = Console.ReadLine();

        Console.Write("Выберите услугу (кредит, вклад, консультация): ");
        string serviceType = Console.ReadLine();

        Client newClient = new Client(clientId, serviceType);
        clientQueue.Enqueue(newClient);

        Console.WriteLine($"Клиент {clientId} добавлен в очередь для услуги {serviceType}.");
        DisplayQueueStatus(clientQueue);
    }

    public static void ServeNextClient(Queue<Client> clientQueue, List<Client> servedClients)
    {
        if (clientQueue.Count > 0)
        {
            Client servedClient = clientQueue.Dequeue();
            servedClient.SetWaitTime();
            servedClients.Add(servedClient);

            Console.WriteLine($"Обслужен клиент {servedClient.ClientId} (услуга: {servedClient.ServiceType}).");
        }
        else
        {
            Console.WriteLine("Очередь пуста. Нет клиентов для обслуживания.");
        }

        DisplayQueueStatus(clientQueue);
    }

    public static void DisplayAverageWaitTime(List<Client> servedClients)
    {
        if (servedClients.Count > 0)
        {
            int totalWaitTime = 0;

            foreach (var client in servedClients)
            {
                totalWaitTime += client.WaitTime;
            }

            double averageWaitTime = (double)totalWaitTime / servedClients.Count;
            Console.WriteLine($"Среднее время ожидания: {averageWaitTime} минут.");
        }
        else
        {
            Console.WriteLine("Еще нет обслуженных клиентов для расчета среднего времени ожидания.");
        }
    }

    public static void DisplayServedClientsHistory(List<Client> servedClients)
    {
        if (servedClients.Count > 0)
        {
            Console.WriteLine("История обслуженных клиентов:");

            foreach (var client in servedClients)
            {
                Console.WriteLine($"Клиент {client.ClientId} (услуга: {client.ServiceType}, Время ожидания: {client.WaitTime} минут)");
            }
        }
        else
        {
            Console.WriteLine("Еще нет обслуженных клиентов.");
        }
    }

    static void DisplayQueueStatus(Queue<Client> clientQueue)
    {
        Console.WriteLine("Текущее состояние очереди:");

        foreach (var client in clientQueue)
        {
            Console.WriteLine($"Клиент {client.ClientId} (услуга: {client.ServiceType})");
        }

        Console.WriteLine();
    }
}
