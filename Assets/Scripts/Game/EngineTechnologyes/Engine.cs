using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public static Engine thisEngine;

    public static List<Technology> technologies { get; private set; } = new List<Technology>();

    private void Awake() => thisEngine = this;

    public static void UpdateEngine(List<Technology> newTechnologies)
    {
        technologies.Clear();
        technologies = newTechnologies;

        GlobalEvents.OnEngineUpdate.Invoke();
    }

    public static int GetEnginePrice()
    {
        int enginePrice = 0;

        foreach (Technology technology in technologies) enginePrice += technology.technologyPrice;

        return enginePrice;
    }

    public static int GetDevelopmentTime()
    {
        int developmentTime = 0;

        foreach (Technology technology in technologies) developmentTime += technology.dayAmount;

        return developmentTime;
    }
}