using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformsList : MonoBehaviour
{
    [SerializeField] PlatformPresenter platformPresenter;
    [SerializeField] FinalyPrice gamePrice;
    [SerializeField] FinalyPlatform finalyPlatform;

    [SerializeField] Image addPlatformButton;

    [SerializeField] Transform bag;

    [SerializeField] float spawnDelay = 0.1f;

    public List<Platform> platforms;

    private void OnEnable() => SpawnPlatforms();

    void ClearBag()
    {
        foreach (Transform child in bag) Destroy(child.gameObject);
    }

    public void SpawnPlatforms()
    {
        ClearBag();
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            platformPresenter.GetPlatformData(platforms[i]);
            platformPresenter.GetAdditionalData(this);

            Instantiate(platformPresenter, bag);

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }


    public void SetPlatform(int value, Sprite icon, Platform platform)
    {
        finalyPlatform.GetPlatform(platform);

        gamePrice.GetPlatformPrice(value);
        addPlatformButton.sprite = icon;
    }

    public void AddPlatform(Platform platrform) => platforms.Add(platrform);
}