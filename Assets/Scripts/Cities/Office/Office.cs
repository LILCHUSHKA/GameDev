using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "New office")]
public class Office : ScriptableObject
{
    public UnityEvent OnActiveIndependent = new UnityEvent();

    public string officeName;

    [TextArea(5,10)] public string officeDescription;

    public int employeesAmount, salary, weeklyPaymentValue, releasedGamesAmount, price;

    public bool isPlayerOffice = false, isBotOffice, isBuy, isRent, canSpawn;

    public Sprite officePhoto;

    public List<string> countryNames = new List<string>();
}