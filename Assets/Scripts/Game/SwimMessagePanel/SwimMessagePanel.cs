using UnityEngine;
using UnityEngine.UI;

public class SwimMessagePanel : MonoBehaviour
{
    [SerializeField] Text messagePrefab;

    [SerializeField] Text playerNameText, playerSurnameText, companyNameText;

    private void OnEnable()
    {
        GlobalEvents.OnPlayerBuyStudio.AddListener(studioName => {
        SpawnMessage(playerNameText.text + " " + playerSurnameText.text + " buy new studio in " + studioName);
        });

        GlobalEvents.OnCreateNewGame.AddListener(gameName =>
        {
            if (PastGamesList.GetScoreLastGame() > 5 && PastGamesList.GetScoreLastGame() < 10) 
                SpawnMessage(companyNameText.text + " released a new game called " + PastGamesList.GetNameLastGame() + ". " 
                    + "Based on GamesScores.org, the game was enjoyed by most players.");
            else SpawnMessage(companyNameText.text + " released a new game called " + PastGamesList.GetNameLastGame() + ". "
                    + "Based on GamesScores.org, players do not really like this creation.");

            if (PastGamesList.GetScoreLastGame() == 10)
                SpawnMessage(companyNameText.text + " released a new game called " + PastGamesList.GetNameLastGame() + ". "
                    + "Based on GamesScores.org, a game with such reviews can boast the title of an absolute masterpiece of the gaming industry.");
        });
    }

    public void SpawnMessage(string messageText)
    {
        messagePrefab.text = messageText;
        Instantiate(messagePrefab, gameObject.transform);
    }
}