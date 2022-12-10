using UnityEngine;
using System.Collections.Generic;

public class GameExhibition : MonoBehaviour
{
    [SerializeField] static List<NewGameData> games = new List<NewGameData>();

    public static bool exhibitionTime { get; private set; }

    int finalyFansValue;

    private void Start()
    {
        GlobalEvents.OnDateChange.AddListener((day, week, month, year) =>
        {
            if (month == 5 && week == 4 && day == 1)
            {
                if (ActionPanel.fans < 50000) MessageList.AddMessage("Game exhibition",
                    "Hi boss, the next game exhibition will be held in a week. " +
                    "Since no one is inviting us yet, we need to take the initiative and send the projects to the exhibition. " +
                    "The more often our projects appear at the exhibition, the faster people will find out about us", "Marvin");

                else MessageList.AddMessage("Game exhibition",
                    "Hi, since you have achieved some success in the gaming industry, " +
                    "we cannot pass by and not invite you to the next gaming exhibition, " +
                    "which is due to take place next week.", "Administration of the gaming exhibition");

                exhibitionTime = true;
            }

            if (month == 6 && week == 1 && day == 3)
            {
                ReturnPlatformResult();
                ReturnTechnologiesResult();
                ReturnThemeResult();

                if (games.Count > 0)
                {
                    ActionPanel.AddFans(finalyFansValue);

                    MessageList.AddMessage("End of the exhibition", "Preliminary estimates :" + GamesReview(), "Marvin");
                }

                else
                {
                    ActionPanel.TakeFans(Random.Range(0, 1000));

                    MessageList.AddMessage("End of the exhibition",
                        "It is a pity that you could not participate in our exhibition of games. " +
                        "We hope you didn't have too serious reasons or you just didn't want to.", "Administration of the gaming exhibition");
                }

                exhibitionTime = false;
            }
        });
    }

    void ReturnTechnologiesResult()
    {
        bool isMissing = true;

        foreach (NewGameData gameData in games)
        {
            foreach (Technology recomendedTechnology in gameData.finalyGenre.recomendedTechnologies)
            {
                foreach (Technology usedTechnology in gameData.office.usedTechnologies)
                {
                    if (recomendedTechnology.technologyName == usedTechnology.technologyName)
                    {
                        isMissing = false;
                        break;
                    }
                }
            }

            if (isMissing == false)
            {
                gameData.interestMultiplier++;
                finalyFansValue += Random.Range(0, 1000);
            }
        }
    }

    void ReturnThemeResult()
    {
        bool notFit = true;

        foreach (NewGameData gameData in games)
        {
            foreach (RecomendedGenre recomendedGenre in gameData.finalyTheme.RecomendedGenres)
            {
                if (recomendedGenre.genreName == gameData.finalyGenre.genre.ToString())
                    notFit = false;
            }

            if (notFit == false)
            {
                gameData.interestMultiplier++;
                finalyFansValue += Random.Range(0, 1000);
            }
        }
    }

    void ReturnPlatformResult()
    {
        bool notFit = true;

        foreach (NewGameData gameData in games)
        {
            foreach (RecomendedGenre recomendedGenre in gameData.finalyPlatform.RecomendedGenres)
            {
                if (recomendedGenre.genreName == gameData.finalyGenre.genre.ToString())
                    notFit = false;
            }

            if (notFit == false)
            {
                gameData.interestMultiplier++;
                finalyFansValue += Random.Range(0, 1000);
            }
        }
    }

    string GamesReview()
    {
        string gamesReview = "";

        foreach (NewGameData gameData in games)
        {
            switch (gameData.interestMultiplier)
            {
                case 1:
                    gamesReview += "/n" + gameData.finalyName + " - " + Random.Range(1, 4);
                    break;
                case 2:
                    gamesReview += "/n" + gameData.finalyName + " - " + Random.Range(5, 8);
                    break;
                case 3:
                    gamesReview += "/n" + gameData.finalyName + " - " + Random.Range(8, 10);
                    break;
            }

            finalyFansValue *= gameData.interestMultiplier;
        }

        return gamesReview;
    }

    public static void AddGameToExhibition(NewGameData exhibitionGameData) => games.Add(exhibitionGameData);
}