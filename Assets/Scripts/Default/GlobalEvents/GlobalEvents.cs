using UnityEngine.Events;

public class GlobalEvents
{
    public static UnityEvent<int, int, int, int> OnDateChange = new UnityEvent<int, int, int, int>();

    public static UnityEvent OnMessageAdd = new UnityEvent();

    public static UnityEvent<string> OnPlayerBuyStudio = new UnityEvent<string>();

    public static UnityEvent OnPlayerSellStudio = new UnityEvent();

    public static UnityEvent<string> OnCreateNewGame = new UnityEvent<string>();

    public static UnityEvent OnEngineUpdate = new UnityEvent();

    public static UnityEvent<bool> OnInternetDisconect = new UnityEvent<bool>();
}