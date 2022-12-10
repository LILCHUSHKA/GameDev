using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "New platform")]
public class Platform : ScriptableObject
{
    public enum Platforms
    {
        PC,
        PS,
        PSP,
        Switch,
        Mobile
    }
    public Platforms gamePlatform;

    public List<RecomendedGenre> RecomendedGenres;

    public Sprite platformIcon;
    public string platformName;
    public int platformPrice;
}