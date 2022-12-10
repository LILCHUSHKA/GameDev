using UnityEngine.Events;

[System.Serializable]
public class TechnologyEvent : WorldEvent
{
    public UnityEvent OnAddTechnology;

    public override void ActiveEvent()
    {
        base.ActiveEvent();
        OnAddTechnology.Invoke();
    }
}