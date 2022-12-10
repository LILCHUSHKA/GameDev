using UnityEngine;
using UnityEngine.UI;

public class TechnologyPresenter : MonoBehaviour
{
    [SerializeField] Technology technologyData;
    [SerializeField] TechnologyList parent;

    [SerializeField] Text technologyNameText;
    [SerializeField] Toggle toggle;

    public void GetTechnologyData(Technology technology, TechnologyList _parent)
    {
        technologyData = technology;
        parent = _parent;

        technologyNameText.text = technologyData.technologyName + " (" + technologyData.dayAmount.ToString() + " days)";
        toggle.isOn = false;
    }

    public void ActiveTechnology()
    {
        technologyData.isActive = toggle.isOn;
        parent.HandleUsedTechnology(technologyData);
    }
}