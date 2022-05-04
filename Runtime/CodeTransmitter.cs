using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Ulbe.Transmitter
{
    public abstract class CodeTransmitter : MonoBehaviour
    {
        public event Action OnActivate;

        public event Action OnDeactivate;

        private Coroutine _Coroutine;

        public void TransmitMessage(string message, float speed)
        {
            if (IsTransmitting)
                return;
            _Coroutine = StartCoroutine(DoTransmit(message, speed));
        }

        public virtual void StopTransmitting()
        {
            StopCoroutine(_Coroutine);
            Deactivate();
            _Coroutine = null;
        }

        protected virtual IEnumerator DoTransmit(string message, float speed = 10)
        {
            Activate();
            yield return new WaitForSeconds(1f * speed);
            Deactivate();
        }

        protected void Activate() => OnActivate?.Invoke();

        protected void Deactivate() => OnDeactivate?.Invoke();

        public bool IsTransmitting { get; protected set; }
    }
}