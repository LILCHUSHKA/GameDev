using UnityEngine;

public class Panel : MonoBehaviour
{
    public void ActivePanel()
    {
        if (gameObject.activeSelf) gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }
}