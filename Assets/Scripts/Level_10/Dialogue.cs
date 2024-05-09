using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AdvancedHorrorFPS
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private SummonUndead summon;

        public TextMeshProUGUI dialogueText;
        public float typingSpeed = 0.05f;
        public float sentenceSpeed = 3.5f;
        //public List <string[]> DialogueHolder; //= new List <string>[]();
        public string[] beginningDialogue;
        public string[] nextDialogue;
        public string[] finalDialogue;
        public Camera dialogueCamera;

        private Camera mainCamera;
        private int index;
        private int dialogueIndex;

        private bool isTriggered = false;

        void Start()
        {
            //DialogueHolder.Add(beginningDialogue);
            //DialogueHolder.Add(nextDialogue);
        }


        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && !isTriggered)
            {
                isTriggered = true;
                StartDialogue();
            }
        }


        public void StartDialogue()
        {
        // dialogueCamera.enabled = true;
        // Camera.main.enabled = false;
            StartCoroutine(TypeSentence(beginningDialogue[index]));
        }

        public void NextDialogue()
        {
            StartCoroutine(TypeSentence(nextDialogue[index]));
            //StartCoroutine(TypeSentence(nextSentences[nextIndex]));
        }
        public void FinalDialogue()
        {
            StartCoroutine(TypeSentence(finalDialogue[index]));
            //StartCoroutine(TypeSentence(nextSentences[nextIndex]));
        }


        private IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            yield return new WaitForSeconds(sentenceSpeed);
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            index++;
            if (index < beginningDialogue.Length && dialogueIndex == 0)
            {
                StartCoroutine(TypeSentence(beginningDialogue[index]));
                //StartCoroutine(TypeSentence(DialogueHolder[dialogueIndex][index])); 
            }
            else if (index < nextDialogue.Length && dialogueIndex == 1)
            {
                StartCoroutine(TypeSentence(nextDialogue[index]));

            }
            else if (index < finalDialogue.Length && dialogueIndex == 2)
            {
                StartCoroutine(TypeSentence(finalDialogue[index]));
            }
            else
            {
                index = 0;
                dialogueIndex++;
                dialogueText.text = "";
            // Camera.main.enabled = true;
            // dialogueCamera.enabled = false;
                summon.StartSummoning();
            }
        }
    }
}
