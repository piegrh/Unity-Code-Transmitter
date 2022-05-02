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

        public float StartDelay = 1f;

        void Awake()
        {
            Transmitter = GetComponent<CodeTransmitter>();
        }

        void Update()
        {
            if (Transmitter.Transmitting)
                return;
            StartCoroutine(Transmit());
        }

        protected IEnumerator Transmit()
        {
            yield return new WaitForSeconds(StartDelay);
            Transmitter.TransmitMessage(Message);
        }
    }
}
