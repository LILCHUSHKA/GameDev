using UnityEngine;

[System.Serializable]
public class WorldGame
{
    public Sprite gameImage;
    public string gameName, gamePlatform, gameDate, gameGenre;

    [TextArea(3, 10)] public string gameDescription;

    public int gameScore;

    public void GetGameData(string _gameName, string _description, string _platform, string _date, string _genre, int _gameScore, Sprite _gameImage)
    {
        gameImage = _gameImage;

        gameName = _gameName;
        gameDescription = _description;
        gamePlatform = _platform;
        gameDate = _date;
        gameGenre = _genre;

        gameScore = _gameScore;
    }
}