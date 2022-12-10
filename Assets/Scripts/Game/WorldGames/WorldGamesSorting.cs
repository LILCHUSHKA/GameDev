using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class WorldGamesSorting : MonoBehaviour
{
    [SerializeField] WorldGamesList worldGamesList;

    [SerializeField] Dropdown genreDropdown, platformDropdown, scoreDropdown, dateDropdown;

    [SerializeField] Text nameSortingText;

    [SerializeField] List<WorldGame> sortedGamesList;

    public void SortToGenre()
    {
        sortedGamesList.Clear();

        if (genreDropdown.value == 0) worldGamesList.SpawnAllGames();
        else
        {
            foreach (WorldGame worldGame in WorldGamesList.worldGames)
            {
                if (worldGame.gameGenre == genreDropdown.options[genreDropdown.value].text) sortedGamesList.Add(worldGame);
            }

            worldGamesList.RenderSortGames(sortedGamesList);
        }
    }

    public void SortToPlatform()
    {
        sortedGamesList.Clear();

        if (platformDropdown.value == 0) worldGamesList.SpawnAllGames();
        else
        {
            foreach (WorldGame worldGame in WorldGamesList.worldGames)
            {
                if (worldGame.gamePlatform == platformDropdown.options[platformDropdown.value].text) sortedGamesList.Add(worldGame);
            }

            worldGamesList.RenderSortGames(sortedGamesList);
        }
    }

    public void SortToDate()
    {
        sortedGamesList.Clear();

        if (dateDropdown.value == 0) worldGamesList.SpawnAllGames();
        else
        {
            foreach (WorldGame worldGame in WorldGamesList.worldGames)
            {
                if (worldGame.gameDate == dateDropdown.options[dateDropdown.value].text) sortedGamesList.Add(worldGame);
            }

            worldGamesList.RenderSortGames(sortedGamesList);
        }
    }

    public void SortToScore()
    {
        sortedGamesList.Clear();

        if (scoreDropdown.value == 0) worldGamesList.SpawnAllGames();
        else
        {
            foreach (WorldGame worldGame in WorldGamesList.worldGames)
            {
                if (worldGame.gameScore == Convert.ToInt32(scoreDropdown.options[scoreDropdown.value].text))
                    sortedGamesList.Add(worldGame);
            }

            worldGamesList.RenderSortGames(sortedGamesList);
        }
    }

    public void SortToName()
    {
        sortedGamesList.Clear();

        if (nameSortingText.text == "") worldGamesList.SpawnAllGames();
        else
        {
            foreach (WorldGame worldGame in WorldGamesList.worldGames)
            {
                if (worldGame.gameName == nameSortingText.text) sortedGamesList.Add(worldGame);
            }

            worldGamesList.RenderSortGames(sortedGamesList);
        }
    }

    public void ClearSotringField()
    {
        nameSortingText.text = "";

        genreDropdown.value = 0;
        platformDropdown.value = 0;
        dateDropdown.value = 0;
        scoreDropdown.value = 0;

        sortedGamesList.Clear();
    }
}