using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] NewGameData newGameData;

    [SerializeField] ProfitGraph profitGraph;

    int finalyScore;

    void CalculateScore()
    {
        finalyScore = 10;

        ReturnPlatformResult();
        ReturnThemeResult();
        ReturnTechnologiesResult();

        AddProfit();

        PastGamesList.AddGame(newGameData.finalyGenre, newGameData.finalyPlatform,
        newGameData.finalyTheme, newGameData.finalyName, newGameData.finalyPrice, finalyScore);
    }

    public void GetNewGameData(NewGameData newGame)
    {
        newGameData = newGame;

        CalculateScore();
        GlobalEvents.OnCreateNewGame.Invoke(PastGamesList.GetNameLastGame());
    }

    void ReturnTechnologiesResult()
    {
        int missingTechnologies = 0;

        bool isMissing = true;

        foreach (Technology recomendedTechnology in newGameData.finalyGenre.recomendedTechnologies)
        {
            foreach (Technology usedTechnology in newGameData.office.usedTechnologies)
            {
                if (recomendedTechnology.technologyName == usedTechnology.technologyName)
                {
                    isMissing = false;
                    break;
                }
            }

            if (isMissing == true) missingTechnologies++;
        }

        finalyScore -= missingTechnologies;
    }

    void ReturnThemeResult()
    {
        bool notFit = true;

        foreach (RecomendedGenre recomendedGenre in newGameData.finalyTheme.RecomendedGenres)
        {
            if (recomendedGenre.genreName == newGameData.finalyGenre.genre.ToString())
                notFit = false;
        }

        if (notFit) finalyScore--;
    }

    void ReturnPlatformResult()
    {
        bool notFit = true;

        foreach (RecomendedGenre recomendedGenre in newGameData.finalyPlatform.RecomendedGenres)
        {
            if (recomendedGenre.genreName == newGameData.finalyGenre.genre.ToString())
                notFit = false;
        }

        if (notFit) finalyScore -= 2;
    }

    void AddProfit()
    {
        Profit profit = new Profit();

        profit.startProfitValue = (ActionPanel.fans + Random.Range(0, 1000)) *
            finalyScore * newGameData.interestMultiplier * (newGameData.office.office.employeesAmount / 25);

        profit.profitValue = profit.startProfitValue;

        profitGraph.AddProfitValue(profit);

        if (profitGraph.gameObject.activeSelf == false) profitGraph.gameObject.SetActive(true);
    }
}