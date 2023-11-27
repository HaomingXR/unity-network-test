using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public static class NetworkTest
{
    private const string TargetIP = "8.8.8.8";
    private static bool? isConnected;

    public static async Task<bool> CheckConnection(MonoBehaviour caller, byte threshold = 1)
    {
        isConnected = null;

        caller.StartCoroutine(CheckConnection(threshold));

        while (isConnected == null)
            await Task.Delay(5 * threshold);

        return (bool)isConnected;
    }

    private static IEnumerator CheckConnection(byte threshold)
    {
        Ping ping = new Ping(TargetIP);

        yield return new WaitForSecondsRealtime(0.25f * threshold);

        isConnected = ping.isDone;
    }
}
