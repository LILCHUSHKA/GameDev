using UnityEngine;

public class Window : MonoBehaviour
{
    public void CloseWindow() => gameObject.SetActive(false);

    public void DestroyWindow() => Destroy(gameObject);
}