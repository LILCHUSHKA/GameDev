using UnityEngine;
using UnityEngine.UI;

public class GameName : MonoBehaviour
{
    [SerializeField] Text gameNameText;

    [SerializeField] FinalyName finalyName;

    public void SetGameName() => finalyName.SetGameName(gameNameText.text);
}