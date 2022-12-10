using UnityEngine;
using UnityEngine.UI;

public class MessagesSite : MonoBehaviour
{
    [SerializeField] Button scoresButton, sharesButton;

    private void OnEnable()
    {
        if (GameTime.year >= 1984) sharesButton.enabled = true;

        if (GameTime.year >= 2001) scoresButton.enabled = true;
    }
}