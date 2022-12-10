using UnityEngine;
using UnityEngine.Events;

public class ActiveEvents : MonoBehaviour
{
    [SerializeField] UnityEvent Enabled, Disabled;

    private void OnEnable() => Enabled.Invoke();
    private void OnDisable() => Disabled.Invoke();
}