using System.Collections;
using UnityEngine;

public class DownPanelSystems : MonoBehaviour
{
    [SerializeField] Battery batterySystem;

    [SerializeField] Clock clockSystem;

    [SerializeField] InternerConnection internerConnectionSystem;

    private void Start()
    {
        if (SystemInfo.batteryLevel < 0) batterySystem.batteryImage.gameObject.SetActive(false);

        UpdateSystemsData();
        StartCoroutine(CheckSystemTimer());
    }

    void UpdateSystemsData()
    {
        batterySystem.CheckBattery();
        clockSystem.SetClockInText();
        internerConnectionSystem.CheckConnect();
    }

    IEnumerator CheckSystemTimer()
    {
        yield return new WaitForSecondsRealtime(2f);

        UpdateSystemsData();
        StartCoroutine(CheckSystemTimer());
    }
}