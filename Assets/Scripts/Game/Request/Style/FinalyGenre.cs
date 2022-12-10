using UnityEngine;
using UnityEngine.UI;

public class FinalyGenre : MonoBehaviour
{
    public Genre genre;

    [SerializeField] Image genreButton;
    [SerializeField] Sprite defaultSprite;

    public void GetGenre(Genre _genre) => genre = _genre;

    public void ClearGenreField()
    {
        if (genre != null)
        {
            genre = null;
            genreButton.sprite = defaultSprite;
        }
    }
}