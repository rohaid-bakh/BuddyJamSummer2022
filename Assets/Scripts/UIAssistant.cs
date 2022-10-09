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

    public int messageArrayNumber = 0;

    // [SerializeField] Image npcImage;

    //added soundManager reference
    public SoundManager soundManagerReference;


    // Color[] colors = new Color[] { Color.black, Color.white, Color.yellow, Color.blue };
    public Characters[] npcSprites;
    // Dog = 0 , Frog = 1 , Raccoon = 3
    public GameObject[] Sprites;

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
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true, soundManagerReference); //added soundManager reference
        LoadSprite(npcSprites[messageArrayNumber]);
        //change color of sprite
        // npcImage.color = colors[messageArrayNumber];
        //change sprite
        

        
    }

    public void PreviousButton()
    {

        messageArrayNumber--;

        if (messageArrayNumber < 0)
        {
            messageArrayNumber = messageArray.Length - 1;
        }

        string message = messageArray[messageArrayNumber];
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true, soundManagerReference);

        LoadSprite(npcSprites[messageArrayNumber]);
        //change color of sprite
        // npcImage.color = colors[messageArrayNumber];
        //change sprite
       
    }

    public void LoadNewDialogue()
    {
        //TextWriter.AddWriter_Static(messageText, StepOne, textSpeed, true);

        string message = messageArray[0];
        TextWriter.AddWriter_Static(messageText, message, textSpeed, true, true, soundManagerReference);
        LoadSprite(npcSprites[0]);
        //change color of sprite
        // npcImage.color = colors[messageArrayNumber];
        //change sprite

    }
    private void LoadSprite(Characters current){

        switch(current){
            case Characters.Dog: 
                Sprites[0].SetActive(true);
                Sprites[1].SetActive(false);
                Sprites[2].SetActive(false);
                break;
            case Characters.Frog:
                Sprites[0].SetActive(false);
                Sprites[1].SetActive(true);
                Sprites[2].SetActive(false);
                break;
            case Characters.Raccoon:
                Sprites[0].SetActive(false);
                Sprites[1].SetActive(false);
                Sprites[2].SetActive(true);
                break;
        }
    }
    private void Start()
    {
        LoadNewDialogue();
    }

}
