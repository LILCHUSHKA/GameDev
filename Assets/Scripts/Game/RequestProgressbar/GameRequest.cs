using UnityEngine;
using UnityEngine.UI;

public class GameRequest : RequestProgressbar
{
    [Header("Game request")] [SerializeField] NewGameData newGame;

    [SerializeField] Button exhibitionButton;

    [SerializeField] Text interestMultiplierText;

    private void OnEnable()
    {
        if (newGame.interestMultiplier > 1) interestMultiplierText.text = "X" + newGame.interestMultiplier.ToString();
    }

    protected override void SetStadyNames() => SetRequestName(newGame.finalyName);

    public override void GetRequest(NewGameData newGameData, OfficePresenter office)
    {
        base.GetRequest(newGameData, office);

        newGame = newGameData;
    }

    protected override void ProgressbarFinished()
    {
        base.ProgressbarFinished();

        busyOffice.AddReleasedGame();

        StartScoreCalculation();
    }

    protected override void ShowAdditionalAction(bool state)
    {
        base.ShowAdditionalAction(state);

        exhibitionButton.gameObject.SetActive(false);

        if (GameExhibition.exhibitionTime) exhibitionButton.gameObject.SetActive(true);
    }

    public void StartScoreCalculation() => GameObject.FindObjectOfType<ScoreCalculator>().GetNewGameData(newGame);

    public void SendGameToExhibition() => GameExhibition.AddGameToExhibition(newGame);
}