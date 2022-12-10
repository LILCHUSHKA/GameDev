using System.Collections.Generic;
using UnityEngine;

public class TechnologyList : MonoBehaviour
{
    [SerializeField] RequestCity requestCity;
    [SerializeField] TechnologyRequest TRP;

    [SerializeField] TechnologyPresenter technologyPresenter;
    [Space(10)]
    [SerializeField] Animator selectStudioButton;
    [Space(10)]
    [SerializeField] GameObject requestsPanel;
    [SerializeField] GameObject engineRequestPanel;
    [Space(10)]
    [SerializeField] Transform bag;
    [SerializeField] Transform TRPBag;
    [Space(10)]
    [SerializeField] List<Technology> technologies;

    public void RenderTechnologies(List<Technology> renderTechnologies)
    {
        ClearBag();

        for (int i = 0; i < renderTechnologies.Count; i++)
        {
            technologyPresenter.GetTechnologyData(renderTechnologies[i], this);
            Instantiate(technologyPresenter, bag);
        }
    }

    public void ClearBag()
    {
        foreach (Transform child in bag) Destroy(child.gameObject);
    }

    void SpawnRequestProgressbar()
    {
        TRP.GetRequest(technologies, requestCity.officePresenter);
        TRP.GetRequestTime(GetTechnologiesTime(), 0);

        Instantiate(TRP, TRPBag);
    }

    public void IntegrateNewTechnologies()
    {
        if (!requestCity.CityIsNull() && technologies.Count != 0)
        {
            SpawnRequestProgressbar();

            requestsPanel.SetActive(true);
            engineRequestPanel.SetActive(false);

            technologies.Clear();
            requestCity.ClearCity();
        }
        else selectStudioButton.Play("Error");
    }

    public void HandleUsedTechnology(Technology technology)
    {
        bool technologyInList = false;
        int removeIndex = 0;

        if (technology.isActive)
        {
            for (; removeIndex < technologies.Count; removeIndex++)
            {
                if (technology.technologyName == technologies[removeIndex].technologyName) technologyInList = true;
            }

            if (!technologyInList) technologies.Add(technology);
        }
        else technologies.RemoveAt(removeIndex);
    }

    int GetTechnologiesTime()
    {
        int timeAmount = 0;

        for (int i = 0; i < technologies.Count; i++)
        {
            timeAmount += technologies[i].dayAmount;
        }

        return timeAmount - (requestCity.officePresenter.office.employeesAmount / 100);
    }

    public void ClearTechnologyList() => technologies.Clear();
}