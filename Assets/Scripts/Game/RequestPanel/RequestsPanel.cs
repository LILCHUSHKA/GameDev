using UnityEngine;

public class RequestsPanel : MonoBehaviour
{
    [SerializeField] GameRequest GameRequestPresenter;

    [SerializeField] NewGameDataHandler newGameDataHandler;

    [SerializeField] PlatformsList platformsList;
    [SerializeField] ThemeList themeList;
    [SerializeField] ScoreCalculator scoreCalculator;

    [SerializeField] Transform GRPBag;

    [SerializeField] Genre[] genreObjects;

    static GameRequest GRP;
    static Transform GameRequestsBag;

    static PlatformsList _platformsList;
    static ThemeList _themeList;
    static ScoreCalculator _scoreCalculator;
    
    static Genre[] _genreObjects;

    static NewGameDataHandler _newGameDataHandler;
    static NewGameData gameData;

    private void Start()
    {
        GRP = GameRequestPresenter;
        GameRequestsBag = GRPBag;

        _platformsList = platformsList;
        _themeList = themeList;
        _scoreCalculator = scoreCalculator;

        _genreObjects = genreObjects;

        _newGameDataHandler = newGameDataHandler;
    }

    public static void AddIndependentGameRequest(OfficePresenter office)
    {
        int platformIndex = Random.Range(0, _platformsList.platforms.Count - 1);
        int preparedNameIndex = Random.Range(0, _newGameDataHandler.finalyName.preparedNames.Count - 1);

        gameData.office = office;
        gameData.finalyGenre= _genreObjects[Random.Range(0, _genreObjects.Length - 1)];
        gameData.finalyPlatform = _platformsList.platforms[platformIndex];
        gameData.finalyTheme = _themeList.themes[Random.Range(0, _themeList.themes.Count - 1)];
        gameData.finalyName = (_newGameDataHandler.finalyName.preparedNames[preparedNameIndex]);

        _newGameDataHandler.finalyPrice.GetPlatformPrice(_platformsList.platforms[platformIndex].platformPrice);
        _newGameDataHandler.finalyPrice.GetTechnologyPrice();

        gameData.finalyPrice = _newGameDataHandler.finalyPrice.GetGamePrice();

        _newGameDataHandler.finalyName.preparedNames.RemoveAt(preparedNameIndex);

        GRP.GetRequest(gameData, office);

        GRP.GetRequestTime(Engine.GetDevelopmentTime() +
            (gameData.finalyPrice / 1000000) +
                (office.office.employeesAmount / 10), office.Exp());

        Instantiate(GRP, GameRequestsBag);
    }
}