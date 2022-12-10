using UnityEngine;
using UnityEngine.UI;

public class CompanyName : MonoBehaviour
{
    [SerializeField] SavedGamesArea savedGames;

    Text textData;

    private void Awake() => textData = GetComponent<Text>();

    private void OnEnable() => textData.text = savedGames.GetNameLastSave();
}