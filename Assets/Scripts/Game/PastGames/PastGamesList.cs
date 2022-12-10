using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PastGamesList : MonoBehaviour
{
    [SerializeField] PastGamesPresenter gamesPresenter;

    [SerializeField] Transform bag;

    [SerializeField] float spawnDelay = 0.1f;

    public static List<PastGame> pastGames { get; private set; } = new List<PastGame>();

    private void OnEnable() => SpawnAllGames();

    void ClearBag()
    {
        foreach (Transform child in bag) Destroy(child.gameObject);
    }

    public void SpawnAllGames()
    {
        ClearBag();
        StartCoroutine(SpawnDelay(pastGames));
    }

    public static void AddGame(Genre gameGenre, Platform gamePlatrfom, Theme gameTheme, string gameName, int gamePrice, int gameScore)
    {
        PastGame pastGame = new PastGame();

        pastGame.finalyGenre = gameGenre;
        pastGame.finalyPlatform = gamePlatrfom;
        pastGame.finalyTheme = gameTheme;
        pastGame.name = gameName;
        pastGame.price = gamePrice;
        pastGame.score = gameScore;
        pastGame.year = GameTime.year.ToString();

        pastGames.Add(pastGame);
    }

    public void RenderSortGames(List<PastGame> sortingGames)
    {
        ClearBag();
        StartCoroutine(SpawnDelay(sortingGames));
    }

    public static string GetNameLastGame()
    {
        return pastGames[pastGames.Count - 1].name;
    }

    public static int GetScoreLastGame()
    {
        return pastGames[pastGames.Count - 1].score;
    }

    IEnumerator SpawnDelay(List<PastGame> renderedPastGamesList)
    {
        for (int i = 0; i < renderedPastGamesList.Count; i++)
        {
            gamesPresenter.GetGameData(renderedPastGamesList[i]);
            Instantiate(gamesPresenter, bag);

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
}