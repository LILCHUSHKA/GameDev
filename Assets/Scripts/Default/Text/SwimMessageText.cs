using UnityEngine;
using UnityEngine.UI;

public class SwimMessageText : MonoBehaviour
{
    [SerializeField] string text;

    [SerializeField] int translateSpeed;

    [SerializeField] float destroyDelay = 1.5f;

    private void OnEnable()
    {
        text = GetComponent<Text>().text;
        Destroy(gameObject, destroyDelay * text.Length);
    }

    private void FixedUpdate() => transform.Translate(0 + (-translateSpeed * Time.deltaTime), 0, 0);


}