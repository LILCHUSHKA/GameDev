using UnityEngine;
using System.Collections;

public class ColorImage : MonoBehaviour
{
    [SerializeField] ColorsPanel colorsPanel;

    [SerializeField] Texture2D tex;

    void OnEnable() => tex = new Texture2D(1, 1, TextureFormat.RGB24, false);

    IEnumerator ReadPixelColor()
    {
        yield return new WaitForEndOfFrame();

        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        tex.ReadPixels(new Rect(x, y, 1, 1), 0, 0);
        tex.Apply();

        colorsPanel.ChangeColor(tex.GetPixel(0, 0));
    }

    void OnMouseDown() => StartCoroutine(ReadPixelColor());
}