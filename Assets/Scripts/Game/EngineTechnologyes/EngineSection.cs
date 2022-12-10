using System.Collections.Generic;
using UnityEngine;

public class EngineSection : MonoBehaviour
{
    [SerializeField] TechnologyList technologyList;

    [SerializeField] List<Technology> technologiesInSection;

    public void ShowSectionTecnologies() => technologyList.RenderTechnologies(technologiesInSection);

    public void AddTechnology(Technology technology) => technologiesInSection.Add(technology);
}