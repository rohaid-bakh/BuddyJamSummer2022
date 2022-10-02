using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UIAssistant : MonoBehaviour
{
    private TMP_Text messageText;

    [SerializeField] string StepOne;

    [SerializeField] float textSpeed;

    [SerializeField] int messageArrayNumber = 0;

    [SerializeField] Image npcImage;


    Color[] colors = new Color[] { Color.black, Color.white, Color.yellow, Color.blue };
    public Sprite[] npcSprites;


    string[] messageArray = new string[]
    {
    "This city is great! The supermarket is in the middle of town. It's only two blocks from my house on the east side.",
    "The playground I like is on the west side next to the courthouse.",
    "I work at the courthouse on the south side of town. The playground to the west of my office is too loud!",
    "I live at the southeast point of the city. I have to walk straight across town just to visit the playground!",
    };


    private void Awake()
    {
        messageText = transform.Find("Message").Find("MessageText").GetComponent<TMP_Text>();
        npcImage.color = Color.black;
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
        npcImage.color = colors[messageArrayNumber];
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
        npcImage.color = colors[messageArrayNumber];
        //change sprite
        npcImage.sprite = npcSprites[messageArrayNumber];
    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(messageText, StepOne, textSpeed, true);

        string message = messageArray[0];
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true);

        //change color of sprite
        npcImage.color = colors[messageArrayNumber];
        //change sprite
        npcImage.sprite = npcSprites[messageArrayNumber];
    }

}
