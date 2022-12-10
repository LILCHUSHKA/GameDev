using UnityEngine;
using UnityEngine.UI;

public class PastGamesPresenter : MonoBehaviour
{
    [SerializeField] Text nameText, priceText, scoreText;

    [SerializeField] Image genreImage, platformImage;

    public void GetGameData(PastGame pastGame) 
    {
        nameText.text = pastGame.name;
        priceText.text = pastGame.price.ToString();
        

        /*Скорее всего нужно убрать этот момент
         * salesText.text = pastGame.sales;
        profitText.text = pastGame.profit;*/
        scoreText.text = pastGame.score.ToString();

        genreImage.sprite = pastGame.finalyGenre.IconSprite;
        platformImage.sprite = pastGame.finalyPlatform.platformIcon;
    }
}