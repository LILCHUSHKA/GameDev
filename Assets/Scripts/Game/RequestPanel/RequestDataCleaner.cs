using UnityEngine;
using UnityEngine.Events;

public class RequestDataCleaner : MonoBehaviour
{
    [SerializeField] UnityEvent OnStartDataCleaning;

    public void StartCleaning() => OnStartDataCleaning.Invoke();
}