using UnityEngine;
using UnityEngine.Events;

namespace Ulbe.Transmitter
{
    public class CodeTransmitterReceiver : MonoBehaviour
    {
        public CodeTransmitter Transmitter;
        [SerializeField] private UnityEvent OnTransmitEvent;
        [SerializeField] private UnityEvent OnTransmitStopEvent;

        public void Awake()
        {
            if (Transmitter is null)
            {
                Debug.LogError($"{this} missing Transmitter!");
                Destroy(this);
            }
        }

        public void OnEnable()
        {
            Transmitter.OnOnTransmitEvent += OnTransmitEvent.Invoke;
            Transmitter.OnOnTransmitStopEvent += OnTransmitStopEvent.Invoke;
        }

        public void OnDisable()
        {
            Transmitter.OnOnTransmitEvent -= OnTransmitEvent.Invoke;
            Transmitter.OnOnTransmitStopEvent -= OnTransmitStopEvent.Invoke;
        }
    }
}
