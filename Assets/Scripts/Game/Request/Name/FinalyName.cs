using UnityEngine;
using System.Collections.Generic;

public class FinalyName : MonoBehaviour
{
    [SerializeField] string gameName;

    public List<string> preparedNames;

    public void SetGameName(string _name) => gameName = _name;

    public string GetName()
    {
        return gameName;
    }
}