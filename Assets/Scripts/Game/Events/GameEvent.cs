[System.Serializable]
public class GameEvent : WorldEvent
{
    public WorldGame eventGame;

    void AddGameInWorldGamesList()
    {
        eventGame.GetGameData(
            eventGame.gameName, eventGame.gameDescription, "Platform : " + eventGame.gamePlatform, GameTime.year.ToString(),
            eventGame.gameGenre, eventGame.gameScore, eventGame.gameImage);

        WorldGamesList.AddWorldGame(eventGame);
    }

    public override void ActiveEvent(SwimMessagePanel messagePanel)
    {
        messagePanel.SpawnMessage(eventName + " : " + eventText);
        AddGameInWorldGamesList();
    }
}