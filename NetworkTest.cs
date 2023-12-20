using System.Threading.Tasks;
using UnityEngine;

public static class NetworkTest
{
    private const string TargetIP = "8.8.8.8";
    private static bool? isConnected = false;
    private static Ping ping;

    public static async Task<bool> CheckConnection(byte safety = 1)
    {
        if (isConnected != null)
        {
            isConnected = null;
            ping = new Ping(TargetIP);

            await Task.Delay(25 * safety);

            isConnected = ping.isDone;
        }
        else
        {
            while (isConnected == null)
                await Task.Delay(1);
        }

        return (bool)isConnected;
    }
}
