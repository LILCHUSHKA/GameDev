using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Genre : MonoBehaviour
{
    public Sprite IconSprite { get; private set; }

    [SerializeField] FinalyGenre finalyGenre;

    [SerializeField] Image genreIcon, addGenreButton;

    public List<Technology> recomendedTechnologies;

    private void Start() => IconSprite = genreIcon.sprite;

    public enum Genres
    {
        rpg,
        action,
        simulator,
        strategy,
        adventure,
        puzzle
    }
    public Genres genre;

    public void SetGenre()
    {
        addGenreButton.sprite = genreIcon.sprite;
        finalyGenre.GetGenre(this);
    }

    public void AddRecomendedTechnology(Technology technology) => recomendedTechnologies.Add(technology);
}