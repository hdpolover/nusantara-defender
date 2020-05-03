using UnityEngine;
using UnityEngine.Events;

namespace Polover.NusantaraDefender.Variables
{
    public class UnityEventRaiser : MonoBehaviour
    {
        public UnityEvent OnEnableEvent;

        public void OnEnable()
        {
            OnEnableEvent.Invoke();
        }
    }
}