using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListObjectSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> objects;

    [SerializeField] float spawnDelay = 0.1f;

    private void OnEnable() => SpawnObjects();

    void SpawnObjects()
    {
        ClearBag();
        StartCoroutine(SpawnObject());
    }

    void ClearBag()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
    }

    public void AddObject(GameObject newObject) => objects.Add(newObject); 

    IEnumerator SpawnObject()
    {
        foreach (GameObject gameObject in objects)
        {
            yield return new WaitForSecondsRealtime(spawnDelay);
            Instantiate(gameObject, transform);
        }
    }
}