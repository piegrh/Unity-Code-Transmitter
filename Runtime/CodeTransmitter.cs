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

        public float Speed = 10f;

        private Coroutine _Coroutine;

        public void TransmitMessage(string message)
        {
            if (IsTransmitting)
                return;
            _Coroutine = StartCoroutine(DoTransmit(message));
        }

        public virtual void StopTransmitting()
        {
            StopCoroutine(_Coroutine);
            Deactivate();
            _Coroutine = null;
        }

        protected virtual IEnumerator DoTransmit(string message)
        {
            Activate();
            yield return new WaitForSeconds(1f * Speed);
            Deactivate();
        }

        protected void Activate() => OnActivate?.Invoke();

        protected void Deactivate() => OnDeactivate?.Invoke();

        public bool IsTransmitting { get; protected set; }
    }
}