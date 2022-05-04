using System.Collections;
using UnityEngine;

namespace Ulbe.Transmitter
{
    [RequireComponent(typeof(CodeTransmitter))]
    public class CodeTransmitterController : MonoBehaviour
    {
        [HideInInspector] 
        public CodeTransmitter Transmitter;

        public string Message;

        public float Delay = 1f;

        public float Speed = 10f;

        void Awake()
        {
            Transmitter = GetComponent<CodeTransmitter>();
        }

        void Update()
        {
            if (Transmitter.IsTransmitting)
                return;
            StartCoroutine(Transmit());
        }

        protected IEnumerator Transmit()
        {
            yield return new WaitForSeconds(Delay);
            Transmitter.TransmitMessage(Message,Speed);
        }
    }
}
