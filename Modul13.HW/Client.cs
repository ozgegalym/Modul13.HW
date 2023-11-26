using System;

class Client
{
    public string ClientId { get; }
    public string ServiceType { get; }
    public DateTime ArrivalTime { get; }
    public int WaitTime { get; private set; }

    public Client(string clientId, string serviceType)
    {
        ClientId = clientId;
        ServiceType = serviceType;
        ArrivalTime = DateTime.Now;
    }

    public void SetWaitTime()
    {
        WaitTime = (int)(DateTime.Now - ArrivalTime).TotalMinutes;
    }
}
