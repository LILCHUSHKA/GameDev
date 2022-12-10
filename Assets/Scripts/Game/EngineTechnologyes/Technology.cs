using UnityEngine;

[CreateAssetMenu(menuName = "New technology")]
public class Technology : ScriptableObject
{
    public string technologyName;

    public bool isActive = false;

    public int dayAmount, technologyPrice;
}