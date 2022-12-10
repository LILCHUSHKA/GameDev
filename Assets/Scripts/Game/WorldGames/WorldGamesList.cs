using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WorldGamesList : MonoBehaviour
{
    [SerializeField] WorldGamePresenter worldGamePresenter;

    [SerializeField] Transform bag;

    [SerializeField] float spawnDelay = 0.1f;

    public static List<WorldGame> worldGames { get; private set; } = new List<WorldGame>();

    private void OnEnable() => SpawnAllGames();

    public static void AddWorldGame(WorldGame worldGame) => worldGames.Add(worldGame);

    void ClearBag()
    {
        foreach (Transform child in bag) Destroy(child.gameObject);
    }

    public void SpawnAllGames()
    {
        ClearBag();
        StartCoroutine(SpawnDelay(worldGames));
    }

    public void RenderSortGames(List<WorldGame> sortingGames)
    {
        ClearBag();
        StartCoroutine(SpawnDelay(sortingGames));
    }

    IEnumerator SpawnDelay(List<WorldGame> rendererGamesList)
    {
        for (int i = 0; i < rendererGamesList.Count; i++)
        {
            worldGamePresenter.GetGameData(rendererGamesList[i]);
            Instantiate(worldGamePresenter, bag);

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
}