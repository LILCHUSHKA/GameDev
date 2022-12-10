using UnityEngine;
using UnityEngine.UI;

public class WorldGamePresenter : MonoBehaviour
{
    [SerializeField] Image icon;

    [SerializeField] Text name, description, score, platform, date;

    public void GetGameData(WorldGame gameData)
    {
        icon.sprite = gameData.gameImage;

        name.text = gameData.gameName;
        description.text = gameData.gameDescription;
        score.text = gameData.gameScore.ToString();
        platform.text = gameData.gamePlatform;
        date.text = gameData.gameDate;
    }
}