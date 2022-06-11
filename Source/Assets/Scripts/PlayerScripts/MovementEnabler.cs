using UnityEngine;
using UnityEngine.Events;

public class MovementEnabler : MonoBehaviour
{
    public UnityEvent enableMovement;
    public UnityEvent disableMovement;

    void Start() => enableMovement.Invoke();
    public void Enable() => enableMovement.Invoke();
    public void Disable() => disableMovement.Invoke();
}
