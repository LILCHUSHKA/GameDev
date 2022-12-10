using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PastGameSorting : MonoBehaviour
{
    [SerializeField] PastGamesList pastGames;

    [SerializeField] Genre sortingGenre;

    [SerializeField] Platform sortingPlatform;

    [SerializeField] Text nameSortingText, yearSortingText;

    [SerializeField] Image genreButton, platformButton;

    [SerializeField] List<PastGame> sortedGamesList;

    public void SortingToName()
    {
        if (nameSortingText.text == "") pastGames.SpawnAllGames();
        else
        {
            ClearSortingField();

            foreach (PastGame pastGame in PastGamesList.pastGames)
            {
                if (pastGame.name == nameSortingText.text) sortedGamesList.Add(pastGame);
            }

            pastGames.RenderSortGames(sortedGamesList);
        }
    }

    public void SortingToYear()
    {
        if (yearSortingText.text == "") pastGames.SpawnAllGames();
        else
        {
            ClearSortingField();

            foreach (PastGame pastGame in PastGamesList.pastGames)
            {
                if (pastGame.year == yearSortingText.text) sortedGamesList.Add(pastGame);
            }

            pastGames.RenderSortGames(sortedGamesList);
        }
    }

    public void SortingToGenre(Genre genre)
    {
        sortingGenre = genre;

        if (sortingGenre == null) pastGames.SpawnAllGames();
        else
        {
            ClearSortingField();

            foreach (PastGame pastGame in PastGamesList.pastGames)
            {
                if (pastGame.finalyGenre.genre == sortingGenre.genre) sortedGamesList.Add(pastGame);
            }

            pastGames.RenderSortGames(sortedGamesList);
            genreButton.sprite = sortingGenre.IconSprite;
        }
    }

    public void SortingToPlatform(Platform platform)
    {
        sortingPlatform = platform;

        if (sortingPlatform == null) pastGames.SpawnAllGames();
        else
        {
            ClearSortingField();

            foreach (PastGame pastGame in PastGamesList.pastGames)
            {
                if (pastGame.finalyPlatform.gamePlatform == sortingPlatform.gamePlatform) sortedGamesList.Add(pastGame);
            }

            pastGames.RenderSortGames(sortedGamesList);
            platformButton.sprite = sortingPlatform.platformIcon;
        }
    }

    public void SortingToScore(int score)
    {
        ClearSortingField();

        foreach (PastGame pastGame in PastGamesList.pastGames)
        {
            if (pastGame.score == score) sortedGamesList.Add(pastGame);
        }

        pastGames.RenderSortGames(sortedGamesList);
    }

    public void ClearSortingField()
    {
        nameSortingText.text = "";
        yearSortingText.text = "";

        sortingPlatform = null;
        sortingGenre = null;

        sortedGamesList.Clear();
    }
}