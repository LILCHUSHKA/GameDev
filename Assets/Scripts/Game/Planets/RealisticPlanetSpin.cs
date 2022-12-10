using UnityEngine;
using System.Collections;
using System;

public class RealisticPlanetSpin : MonoBehaviour
{
    [SerializeField] float timeCheckDelay;

    private void Awake()
    {
        SpinEarth();
        StartCoroutine(PositionCheckTimer());
    }

    void SpinEarth() => 
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, EarthRealPosition(), -23f);

    private float EarthRealPosition()
    {
        return ((0.25f * DateTime.Now.Minute) + (DateTime.Now.Hour * 15)) / 2;
    }

    IEnumerator PositionCheckTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeCheckDelay);
            SpinEarth();
        }
    }
}