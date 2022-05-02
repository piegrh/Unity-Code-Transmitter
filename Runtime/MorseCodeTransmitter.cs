using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ulbe.Transmitter
{
    public class MorseCodeTransmitter : CodeTransmitter
    {
        protected const float DotFlashTime = 1f;

        protected const float DashFlashTime = 3f;

        protected const float NewSymbolDelay = 1f;

        protected const float NewCharacterDelay = 3f;

        protected const float NewWordDelay = 4f;

        protected static Dictionary<char, string> MorseCodeAlphabet = new Dictionary<char, string>()
        {
            {'A', ".-"},
            {'B', "-..."},
            {'C', "-.-."},
            {'D', "-.."},
            {'E', "."},
            {'F', "..-."},
            {'G', "--."},
            {'H', "...."},
            {'I', ".."},
            {'J', ".---"},
            {'K', "-.-"},
            {'L', ".-.."},
            {'M', "--"},
            {'N', "-."},
            {'O', "---"},
            {'P', ".--."},
            {'Q', "--.-"},
            {'R', ".-."},
            {'S', "..."},
            {'T', "-"},
            {'U', "..-"},
            {'V', "...-"},
            {'W', ".--"},
            {'X', "-..-"},
            {'Y', "-.--"},
            {'Z', "--.."},
            {'0', "-----"},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
        };

        protected override IEnumerator DoTransmit(string message)
        {
            message = message.ToUpper();
            Transmitting = true;
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == ' ')
                {
                    yield return new WaitForSeconds(NewWordDelay / TimeFactor);
                    continue;
                }

                if (MorseCodeAlphabet.ContainsKey(message[i]) == false)
                    continue;

                string code = MorseCodeAlphabet[message[i]];
                foreach (var m in code)
                {
                    Activate();
                    yield return new WaitForSeconds((m == '.' ? DotFlashTime : DashFlashTime) / TimeFactor);
                    Deactivate();
                    yield return new WaitForSeconds(NewSymbolDelay / TimeFactor);
                }

                yield return new WaitForSeconds(NewCharacterDelay / TimeFactor);
            }
            Transmitting = false;
        }
    }
}
