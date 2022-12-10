using UnityEngine;
using System.Collections;

public class SortingPlatformsList : MonoBehaviour
{
    [SerializeField] PastGameSorting pastGameSorting;

    [SerializeField] PlatformsList platformsList;

    [SerializeField] SortingPlatformPresenter sortingPlatformPresenter;

    [SerializeField] Transform bag, parentPanel;

    [SerializeField] float spawnDelay = 0.03f;

    private void OnEnable() => SpawnPlatforms();

    void ClearBag()
    {
        foreach (Transform child in bag) Destroy(child.gameObject);
    }


    void SpawnPlatforms()
    {
        ClearBag();
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        for (int i = 0; i < platformsList.platforms.Count; i++)
        {
            sortingPlatformPresenter.GetPlatformData(platformsList.platforms[i], pastGameSorting);
            sortingPlatformPresenter.GetParent(parentPanel);

            Instantiate(sortingPlatformPresenter, bag);

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
}