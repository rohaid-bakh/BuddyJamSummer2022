using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UIAssistant : MonoBehaviour
{
    //Ro - Commented out all code that changed the color of sprites
    //The npcSprites[] and messageArray[] will be set by LevelHandler
    private TMP_Text messageText;

    [SerializeField] string StepOne;

    [SerializeField] float textSpeed;

    [SerializeField] int messageArrayNumber = 0;

    [SerializeField] Image npcImage;


    // Color[] colors = new Color[] { Color.black, Color.white, Color.yellow, Color.blue };
    public Sprite[] npcSprites;

//changed so that it can be accessed by LevelHandler
    public string[] messageArray;

    private void Awake()
    {
        messageText = transform.Find("Message").Find("MessageText").GetComponent<TMP_Text>();
        // npcImage.color = Color.black;
    }

    public void NextButton()
    {

        messageArrayNumber++;


        if (messageArrayNumber >= messageArray.Length)
        {
            messageArrayNumber = 0;
        }
        

        string message = messageArray[messageArrayNumber];
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true);

        //change color of sprite
        // npcImage.color = colors[messageArrayNumber];
        //change sprite
        npcImage.sprite = npcSprites[messageArrayNumber];

        
    }

    public void PreviousButton()
    {

        messageArrayNumber--;

        if (messageArrayNumber < 0)
        {
            messageArrayNumber = 3;
        }

        string message = messageArray[messageArrayNumber];
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true);

        //change color of sprite
        // npcImage.color = colors[messageArrayNumber];
        //change sprite
        npcImage.sprite = npcSprites[messageArrayNumber];
    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(messageText, StepOne, textSpeed, true);

        string message = messageArray[0];
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true);

        //change color of sprite
        // npcImage.color = colors[messageArrayNumber];
        //change sprite
        npcImage.sprite = npcSprites[messageArrayNumber];
    }

}
