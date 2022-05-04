using UnityEngine;
using UnityEngine.Events;

namespace Ulbe.Transmitter
{
    public class CodeTransmitterReceiver : MonoBehaviour
    {
        public CodeTransmitter Transmitter;

        [SerializeField]
        protected UnityEvent OnActivate;

        [SerializeField]
        protected UnityEvent OnDeactivate;

        public void Awake()
        {
            if (Transmitter is null)
                Transmitter = GetComponent<CodeTransmitter>();

            if (Transmitter is null)
            {
                Debug.LogError($"{gameObject.name} is missing a CodeTransmitter!", gameObject);
                Destroy(this);
            }
        }

        public void OnEnable()
        {
            Transmitter.OnActivate += Activate;
            Transmitter.OnDeactivate += Deactivate;
        }

        public void OnDisable()
        {
            Transmitter.OnActivate -= Activate;
            Transmitter.OnDeactivate -= Deactivate;
        }

        protected virtual void Activate()
        {
            OnActivate.Invoke();
        }

        protected virtual void Deactivate()
        {
            OnDeactivate.Invoke();
        }
    }
}
