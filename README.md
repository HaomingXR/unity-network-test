# Unity Network Test
If you want to check if the user is connected to the Internet inside Unity, a quick Google search may lead you to use:
```cs
if(Application.internetReachability == NetworkReachability.NotReachable)
{
    Debug.Log("Error. Check internet connection!");
}
```

However, even the official [Documentation](https://docs.unity3d.com/ScriptReference/Application-internetReachability.html) advised against this usage:
> **Note:** Do not use this property to determine the actual connectivity.

Furthermore, this might have worked for you in the Editor, but it will fail in a PC build, as mentioned below:
> Non-handhelds are considered to always be capable of NetworkReachability.ReachableViaLocalAreaNetwork.

**TL;DR:** Use the built-in `Ping` function to actually test for a connection instead.
> *Change the `TargetIP` if you're using some sort of restricted local network.*
