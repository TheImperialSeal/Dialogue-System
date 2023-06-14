using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Quest Highlight")]
    [SerializeField] private GameObject visualCue;

    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);

        //Player is not in range by default and the glow is disabled. 
        //This is how the tutorial I followed did the indicator, having it activate when next to an NPC to show they could be talked to
        //Our system will be different but I decided to go with it for the time being
    }

    private void Update()
    {
        //if player is close enough and there is not already dialogue playing
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);

            //this and the spacebar input in the dialogue manager will be replaced with the proper input system
            //but I don't really know how that works yet so I just focused on getting this up and running for now
            //can sort that out later
            if (Input.GetKeyDown("e"))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }

        else
        {
            visualCue.SetActive(false);
        }
    }

    //This is pretty self explanatory, checks whether the player is in range of an NPC to talk to them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
