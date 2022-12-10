using UnityEngine;

public class NewGameDataHandler : MonoBehaviour
{
    [SerializeField] GameRequest GRP;

    public NewGameData newGameData;

    public RequestCity requestCity;
    public FinalyGenre finalyGenre;
    public FinalyPlatform finalyPlatform;
    public FinalyTheme finalyTheme;
    public FinalyPrice finalyPrice;
    public FinalyName finalyName;

    [SerializeField] GameObject requestsPanel;
    [SerializeField] GameObject gameRequestPanel;

    public Transform GRPBag;

    public void CreateNewGame()
    {
        newGameData.finalyGenre = finalyGenre.genre;
        newGameData.finalyName = finalyName.GetName();
        newGameData.finalyPlatform = finalyPlatform.platform;
        newGameData.finalyPrice = finalyPrice.GetGamePrice();
        newGameData.finalyTheme = finalyTheme.theme;
        newGameData.office = requestCity.officePresenter;

        if (GameIsReady())
        {
            GRP.GetRequest(newGameData, requestCity.officePresenter);

            GRP.GetRequestTime((Engine.GetDevelopmentTime() + (finalyPrice.GetGamePrice() / 1000000) + 
                (requestCity.officePresenter.office.employeesAmount / 10)) / 2, requestCity.officePresenter.Exp());

            requestsPanel.SetActive(true);
            gameRequestPanel.SetActive(false);

            Instantiate(GRP, GRPBag);
        }
    }

    bool GameIsReady()
    {
        bool isReady = false;

        if (newGameData.finalyGenre != null) isReady = true;
        else isReady = false;
        if (newGameData.finalyPlatform != null) isReady = true;
        else isReady = false;
        if (newGameData.finalyTheme != null) isReady = true;
        else isReady = false;
        if (newGameData.finalyName.Length > 1) isReady = true;
        else isReady = false;

        return isReady;
    }
}