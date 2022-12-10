using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Battery : MonoBehaviour
{
    [SerializeField] GameObject batteryWarningWindow;

    [SerializeField] Sprite battery_0, battery_1, battery_2, battery_3;

    [SerializeField] Sprite battery_Charging_0, battery_Charging_1, battery_Charging_2, battery_Charging_3;

    public Image batteryImage;

    bool warningIsSend = false;

    private void Start() => warningIsSend = false;

    public void CheckBattery()
    {
        float batteryValue = SystemInfo.batteryLevel;

        BatteryStatus batteryStatus = SystemInfo.batteryStatus;

        if (batteryStatus == BatteryStatus.Discharging)
        {
            if (batteryValue == 1) ChangeBatteryImage(battery_0);
            if (batteryValue < 1 && batteryValue > 0.4f) ChangeBatteryImage(battery_1);
            if (batteryValue < 0.4f && batteryValue > 0) ChangeBatteryImage(battery_2);
            if (batteryValue == 0) ChangeBatteryImage(battery_3);
        }

        if (batteryStatus == BatteryStatus.Charging || batteryStatus == BatteryStatus.Full)
        {
            if (batteryValue == 1) ChangeBatteryImage(battery_Charging_0);
            if (batteryValue < 1 && batteryValue > 0.4f) ChangeBatteryImage(battery_Charging_1);
            if (batteryValue < 0.4f && batteryValue > 0) ChangeBatteryImage(battery_Charging_2);
            if (batteryValue == 0) ChangeBatteryImage(battery_Charging_3);
        }

        if (batteryValue < 0.2f && !warningIsSend)
        {
            warningIsSend = true;
            Instantiate(batteryWarningWindow, GameObject.FindObjectOfType<Canvas>().transform);
        }
    }

    void ChangeBatteryImage(Sprite batterySprite) => batteryImage.sprite = batterySprite;
}