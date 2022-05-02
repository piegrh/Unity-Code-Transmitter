﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Ulbe.Transmitter
{
    public abstract class CodeTransmitter : MonoBehaviour
    {
        public event Action OnOnTransmitEvent;

        public event Action OnOnTransmitStopEvent;

        public float TimeFactor = 10f;

        private Coroutine _Coroutine;

        public void TransmitMessage(string message)
        {
            if (Transmitting)
                return;
            _Coroutine = StartCoroutine(DoTransmit(message));
        }

        public virtual void StopTransmitting()
        {
            StopCoroutine(_Coroutine);
            TransmitStop();
            _Coroutine = null;
        }

        protected virtual IEnumerator DoTransmit(string message)
        {
            TransmitStart();
            yield return new WaitForSeconds(1f * TimeFactor);
            TransmitStop();
        }

        protected void TransmitStart() => OnOnTransmitEvent?.Invoke();

        protected void TransmitStop() => OnOnTransmitStopEvent?.Invoke();

        public bool Transmitting { get; protected set; }
    }
}