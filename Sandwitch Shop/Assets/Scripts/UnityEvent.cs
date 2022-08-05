using UnityEngine;
using UnityEngine.Events;

public class UnityEvent : MonoBehaviour
{
    [SerializeField] private UnityEngine.Events.UnityEvent myEvent;

    public void InvokeUnityEvent()
    {
        myEvent.Invoke();
    }
}
