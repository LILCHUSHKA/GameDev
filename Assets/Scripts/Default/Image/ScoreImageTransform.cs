using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreImageTransform : MonoBehaviour
{
    [SerializeField] Text scoreText;

    [SerializeField] Image image;

    [SerializeField] Color yellow, green;

    private void OnEnable()
    {
        if (Convert.ToInt32(scoreText.text) > 4 && Convert.ToInt32(scoreText.text) < 7) image.color = yellow;
        else if(Convert.ToInt32(scoreText.text) > 7) image.color = green;
    }
}