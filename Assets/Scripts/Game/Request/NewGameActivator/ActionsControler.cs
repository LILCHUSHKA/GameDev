using UnityEngine;
using UnityEngine.UI;

public class ActionsControler : MonoBehaviour
{
    [SerializeField] CityesPanel cityesPanel;

    [SerializeField] Image newGameRequestImage, engineRequestImage;
    [SerializeField] Sprite unlockSprite, lockSprite;

    [SerializeField] Button newGameRequestButton, engineRequestButton;

    private void OnEnable()
    {
        if (cityesPanel.BuyedCityesCount() != 0) UnlockEngineRequest(true, unlockSprite);
        else UnlockEngineRequest(false, lockSprite);

        if (cityesPanel.BuyedCityesCount() != 0 && Engine.GetEnginePrice() > 0) UnlockNewGameRequest(true, unlockSprite);
        else UnlockNewGameRequest(false, lockSprite);
    }

    void UnlockNewGameRequest(bool buttonState, Sprite stateSprite)
    {
        newGameRequestImage.sprite = stateSprite;
        newGameRequestButton.enabled = buttonState;
    }

    void UnlockEngineRequest(bool buttonState, Sprite stateSprite)
    {
        engineRequestImage.sprite = stateSprite;
        engineRequestButton.enabled = buttonState;
    }
}