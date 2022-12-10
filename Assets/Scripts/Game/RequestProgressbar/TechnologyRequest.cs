using System.Collections.Generic;
using UnityEngine;

public class TechnologyRequest : RequestProgressbar
{
    [Header("Technology request")]
    [SerializeField] List<Technology> usedTechnologies;

    protected override void SetStadyNames()
    {
        SetRequestName("Engine");
        foreach(Technology technology in usedTechnologies) stadyNames.Add(technology.technologyName);
    }

    public override void GetRequest(List<Technology> newTechnologies, OfficePresenter Office)
    {
        base.GetRequest(newTechnologies, Office);
        usedTechnologies = newTechnologies;
    }

    protected override void ProgressbarFinished()
    {
        base.ProgressbarFinished();

        Engine.UpdateEngine(usedTechnologies);
        busyOffice.SetUsedEngine(usedTechnologies);
    }
}