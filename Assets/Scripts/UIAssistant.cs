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
    private void Awake()
    {
        messageText = transform.Find("Message").Find("MessageText").GetComponent<TMP_Text>();
    }

    public void NextButton()
    {
        //Debug.Log("next");


        string[] messageArray = new string[]
        {
            "This city is great! The supermarket is in the middle of town. It's only two blocks from my house on the east side.",
            "The playground I like is on the west side next to the courthouse.",
            "I work at the courthouse on the south side of town. The playground to the west of my office is too loud!",
            "I live at the southeast point of the city. I have to walk straight across town just to visit the playground!",
        };

        messageArrayNumber++;

        if (messageArrayNumber >= messageArray.Length)
        {
            messageArrayNumber = 0;
        }
        

        string message = messageArray[messageArrayNumber];
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true);

        
    }

    public void PreviousButton()
    {
        string[] messageArray = new string[]
        {
            "This city is great! The supermarket is in the middle of town. It's only two blocks from my house on the east side.",
            "The playground I like is on the west side next to the courthouse.",
            "I work at the courthouse on the south side of town. The playground to the west of my office is too loud!",
            "I live at the southeast point of the city. I have to walk straight across town just to visit the playground!",
        };

        messageArrayNumber--;

        if (messageArrayNumber < 0)
        {
            messageArrayNumber = 2;
        }

        string message = messageArray[messageArrayNumber];
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true);

        
    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(messageText, StepOne, textSpeed, true);
        string[] messageArray = new string[]
{
            "This city is great! The supermarket is in the middle of town. It's only two blocks from my house on the east side.",
            "The playground I like is on the west side next to the courthouse.",
            "I work at the courthouse on the south side of town. The playground to the west of my office is too loud!",
            "I live at the southeast point of the city. I have to walk straight across town just to visit the playground!",
};

        string message = messageArray[0];
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true);
    }

}
