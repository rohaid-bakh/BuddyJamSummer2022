using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class TextWriter : MonoBehaviour
{
    public static TextWriter instance;
    public List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static void AddWriter_Static(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, SoundManager soundManagerScript) //added soundManager reference
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters, soundManagerScript);
    }

    private void AddWriter(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, SoundManager soundManagerScript)
    {
        textWriterSingleList.Add(new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, soundManagerScript));
    }


    private void RemoveWriter(TMP_Text uiText)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        //Debug.Log(textWriterSingleList.Count);
        for(int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    public class TextWriterSingle
    {
        TMP_Text uiText;
        string textToWrite;
        int characterIndex;
        float timePerCharacter;
        float timer;
        bool invisibleCharacters;

        SoundManager soundManagerScript;

        public TextWriterSingle(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, SoundManager soundManagerScript)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.soundManagerScript = soundManagerScript;
            characterIndex = 0;
        }

        //returns true on complete
        public bool Update()
        {
            //count down
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //display next character
                timer += timePerCharacter;
                characterIndex++;

                if (characterIndex >= textToWrite.Length)
                {
                    //testing to remove invis characters once text is complete
                    //text = text.Replace("<color=#00000000>", "");
                    //uiText.text = text;

                    //audiotesting
                    Debug.Log("endSound");
                    soundManagerScript.textFinished = true;

                    uiText = null;
                    return true;
                }

                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex);
                }

                if(uiText != null)
                {
                    uiText.text = text;
                }

            }

            return false;
        }

        public TMP_Text GetUIText()
        {
            return uiText;
        }
    }

}
