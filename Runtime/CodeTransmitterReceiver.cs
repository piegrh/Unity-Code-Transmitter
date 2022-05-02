using UnityEngine;
using UnityEngine.Events;

namespace Ulbe.Transmitter
{
    public class CodeTransmitterReceiver : MonoBehaviour
    {
        public CodeTransmitter Transmitter;

        [SerializeField]
        private UnityEvent OnActivate;

        [SerializeField]
        private UnityEvent OnDeactivate;

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
            Transmitter.OnActivate += OnActivate.Invoke;
            Transmitter.OnDeactivate += OnDeactivate.Invoke;
        }

        public void OnDisable()
        {
            Transmitter.OnActivate -= OnActivate.Invoke;
            Transmitter.OnDeactivate -= OnDeactivate.Invoke;
        }
    }
}
