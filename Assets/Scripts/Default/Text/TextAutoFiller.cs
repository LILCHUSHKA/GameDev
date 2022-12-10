using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAutoFiller : MonoBehaviour
{
    Text textData;
    string sentenceData;

    [SerializeField] float delay = 0.03f;

    private void Awake() => textData = GetComponent<Text>();

    private void OnEnable()
    {
        sentenceData = textData.text;
        StartFilling();
    }

    public void StartFilling()
    {
        textData.text = "";

        StartCoroutine(FillTimer());
    }

    IEnumerator FillTimer()
    {
        for (int nameSentenceIndex = 0; nameSentenceIndex < sentenceData.Length; nameSentenceIndex++)
        {
            yield return new WaitForSecondsRealtime(delay);
            textData.text += sentenceData[nameSentenceIndex];
        }
    }
}