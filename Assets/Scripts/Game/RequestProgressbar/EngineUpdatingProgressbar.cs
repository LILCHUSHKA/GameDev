public class EngineUpdatingProgressbar : RequestProgressbar
{
    public void GetUpdatingData(OfficePresenter office)
    {
        busyOffice = office;
        busyOffice.UpdateOfficeState(true, this);
    }

    protected override void ProgressbarFinished()
    {
        base.ProgressbarFinished();
        busyOffice.SetUsedEngine(Engine.technologies);
    }
}