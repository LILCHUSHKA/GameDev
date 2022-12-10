using System.Collections.Generic;
using UnityEngine;

public class SavedGamesArea : MonoBehaviour
{
    [SerializeField] List<Save> saves;

    public string GetNameLastSave()
    {
        return saves[saves.Count - 1].companyName;
    }
}

[System.Serializable]
public class Save
{
    public string companyName = "CD Project Red";
}