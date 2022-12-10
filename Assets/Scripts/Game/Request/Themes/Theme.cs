using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "New theme")]
public class Theme : ScriptableObject
{
    public Sprite icon;

    public string themeName;

    public enum GameThemes
    {
        city,
        fighting,
        racing
    }
    public GameThemes gameTheme;

    public List<RecomendedGenre> RecomendedGenres;
}