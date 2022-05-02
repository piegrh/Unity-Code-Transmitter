using System.Collections;
using UnityEngine;

namespace Ulbe.Transmitter
{
    [RequireComponent(typeof(CodeTransmitter))]
    public class CodeTransmitterController : MonoBehaviour
    {
        [HideInInspector] public CodeTransmitter Transmitter;
        public string Message;
        public float startDelay = 1f;

        void Awake()
        {
            Transmitter = GetComponent<CodeTransmitter>();
        }

        void Update()
        {
            if (Transmitter.Transmitting)
                return;
            StartCoroutine(Delay(startDelay));
        }

        protected IEnumerator Delay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Transmitter.TransmitMessage(Message);
        }
    }
}
