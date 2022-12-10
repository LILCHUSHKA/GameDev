using UnityEngine;
using UnityEngine.UI;

public class InternerConnection : MonoBehaviour
{
    [SerializeField] Image connectionImage;

    [SerializeField] Sprite onConnectionSprite, offConnectSprite;

    public void CheckConnect()
    {
        bool disConnect = Application.internetReachability == NetworkReachability.NotReachable;

        if (disConnect) connectionImage.sprite = offConnectSprite;
        else connectionImage.sprite = onConnectionSprite;

        GlobalEvents.OnInternetDisconect.Invoke(disConnect);
    }
}