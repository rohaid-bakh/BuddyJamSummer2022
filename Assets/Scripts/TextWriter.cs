using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static void AddWriter_Static(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters);
    }

    private void AddWriter(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        textWriterSingleList.Add(new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters));
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

        public TextWriterSingle(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
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
                    uiText = null;
                    return true;
                }

                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex);
                }
                if(uiText!= null){
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
