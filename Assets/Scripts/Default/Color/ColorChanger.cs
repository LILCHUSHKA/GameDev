using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] ColorsPanelBlocker blocker;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            blocker.colorsPanel.GetObject(gameObject);

            Instantiate(blocker, GameObject.FindObjectOfType<Canvas>().transform);
        }
    }
}