using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;

namespace Microsoft.MixedReality.Toolkit.Diagnostics
{
    /// <summary>
    /// Class that listens for and acts upon diagnostic system voice commands.
    /// </summary>
    [AddComponentMenu("Scripts/MRTK/Services/SpeechTest")]
    public class SpeechTest : MonoBehaviour, IMixedRealitySpeechHandler
    {
        bool registeredForInput = false;

        private void Start()
        {
            this.gameObject.GetComponent<TextMeshPro>().text = "hello world";
        }

        private void OnEnable()
        {
            if (!registeredForInput)
            {
                if (CoreServices.InputSystem != null)
                {
                    CoreServices.InputSystem.RegisterHandler<IMixedRealitySpeechHandler>(this);
                    registeredForInput = true;
                }
            }
        }

        private void OnDisable()
        {
            if (registeredForInput)
            {
                CoreServices.InputSystem.UnregisterHandler<IMixedRealitySpeechHandler>(this);
                registeredForInput = false;
            }
        }

        /// <inheritdoc />
        void IMixedRealitySpeechHandler.OnSpeechKeywordRecognized(SpeechEventData eventData)
        {
            switch (eventData.Command.Keyword.ToLower())
            {
                case "hello":
                    printWord(eventData.ToString());
                    break;

                case "bye":
                    printWord(eventData.ToString());
                    break;
            }
        }

        /// <summary>
        /// Shows or hides all enabled diagnostics.
        /// </summary>
        /// 
        public void printWord(string speechWord)
        {
            this.gameObject.GetComponent<TextMeshPro>().text = speechWord;
        }

    }
}
