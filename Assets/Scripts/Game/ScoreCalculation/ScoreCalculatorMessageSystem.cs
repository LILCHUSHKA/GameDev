using UnityEngine;

public class ScoreCalculatorMessageSystem : MonoBehaviour
{
    private void Start() =>
        GlobalEvents.OnCreateNewGame.AddListener(SendMessage);

    void SendMessage()
    {
        if (PastGamesList.GetScoreLastGame() > 5)
            MessageList.AddMessage("Game release", "Hey boss, our new game has been reviewed, you can check it out on " +
                "GamesScore.org or on our games page.", "Marvin");
        else MessageList.AddMessage("Game release", "Hey boss, our new game got rated... You better not see this", "Marvin");
    }
}