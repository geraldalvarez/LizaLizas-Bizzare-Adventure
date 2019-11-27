using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationSequence : MonoBehaviour
{
    //distance in which the player can interact with this npc
    public float interactableDistance = 1.5f;

    //can player interacts with this npc
    public bool isInteractable = true;

    private bool conversationComplete = false;

    //conversation state
    private bool startConversation = false;

    private Conversation converse;

    //player's head transform
    private Transform playerHead;

    //audio manager
    private AudioManager audioManager;

    //array of dialogue object
    public Dialogue[] dialogues;

    //structing the dialogues array in 2D matrix 
    private Dialogue[,] dialogueLinesTree;

    //empty sample of dialogue
    private Dialogue emptyDialogue;

    //counter for the dialogue array
    private int dialogueClipCounter = 0;

    //boolean for indicating if the npc/player is currently playing its dialogue clip
    private bool isDialoguePlaying = false;


    private string dialogueNamePlaying = "";


    void Awake()
    {
        //player's head transform
        playerHead = GameObject.Find("FollowHead").GetComponent<Transform>();

        //audio manager reference
        audioManager = GetComponent<AudioManager>();

        emptyDialogue = new Dialogue();

        converse = GameObject.Find("ConversationStates").GetComponent<Conversation>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //function that deconstrcut the 1D array "dialogues" into 2D array "DialogueLinesTree"
        ConstructDialogueLines();

    }

    // Update is called once per frame
    void Update()
    {
        PlayDialogueSequence();
    }


    void PlayDialogueSequence()
    {
        //check if player initiated the conversation
        if (startConversation)
        {
            
            bool inRange = InInteractableDistance(transform, playerHead, interactableDistance);

            if (!isDialoguePlaying)
            {
                isDialoguePlaying = true;

                //play dialogue
                PlayDialogueClip(inRange);
            }
            else
            {

                //check if the corresponding dialogue clip is not playing
                if (IsDialogueClipPlaying(dialogueNamePlaying) == false)
                {
                    isDialoguePlaying = false;

                    if (dialogueClipCounter < (dialogueLinesTree.GetUpperBound(0) + 1))
                    {
                        dialogueClipCounter++;
                    }
                    else
                    {
                        print("End of the conversation");
                        startConversation = false;
                        isInteractable = false;
                        conversationComplete = true;
                        converse.SetOnConversation(false);

                    }

                }
            }
        }

        if(dialogueClipCounter > (dialogueLinesTree.GetUpperBound(0) + 1) && startConversation == false)
        {

        }

    }

    public void PlayDialogueClip(bool inRange)
    {

        if (dialogueClipCounter < (dialogueLinesTree.GetUpperBound(0) + 1))
        {

            for (int i = 0; i < dialogueLinesTree.GetUpperBound(1) + 1; i++)
            {
                if (inRange)
                {
                    //extract the 'n' or 't' in the column array
                    if (dialogueLinesTree[dialogueClipCounter, i].dialogueChoice == 'n' || dialogueLinesTree[dialogueClipCounter, i].dialogueChoice == 't')
                    {
                        //play the dialogue clip
                        audioManager.Play(dialogueLinesTree[dialogueClipCounter, i].dialogueName);

                        //store the name
                        dialogueNamePlaying = dialogueLinesTree[dialogueClipCounter, i].dialogueName;
                    }
                }
                else
                {
                    if (dialogueLinesTree[dialogueClipCounter, i].dialogueChoice == 'f')
                    {
                        //play the dialogue clip
                        audioManager.Play(dialogueLinesTree[dialogueClipCounter, i].dialogueName);

                        //store the name
                        dialogueNamePlaying = dialogueLinesTree[dialogueClipCounter, i].dialogueName;
                    }
                }
            }
        }

    }

    public bool IsDialogueClipPlaying(string name)
    {

        return audioManager.isPlaying(name);

    }

    public void StopDialogueClip(string name)
    {
        audioManager.Stop(name);
    }

    public bool GetConversationComplete()
    {
        return conversationComplete;
    }

    public bool GetStartConversation()
    {
        return startConversation;
    }

    public void SetStartConversation(bool f)
    {
        startConversation = f;
    }

    public bool InInteractableDistance(Transform subjectA, Transform subjectB, float interactableDistance)
    {
        float dist = Vector3.Distance(subjectA.position, subjectB.position);
        return dist <= interactableDistance;
    }

    //function is called from the NPCSlectionResponse 
    public void InitiateConversation()
    {
        if (converse.GetOnConversation() == false && isInteractable)
        {
            //check if the player is within the interactacle distance
            if (InInteractableDistance(transform, playerHead, interactableDistance))
            {
                startConversation = true;
                converse.SetOnConversation(true);
            }
        }
    }

    void ConstructDialogueLines()
    {
        //the length of the dialogueLines matrix. set to 0 as lowest threshold
        int dialogueLinesLength = 0;

        //loop to find the biggest number of index for the dialogueLines' length
        for (int i = 0; i < dialogues.Length; i++)
        {
            if (dialogues[i].dialogueIndex >= dialogueLinesLength)
            {
                dialogueLinesLength = dialogues[i].dialogueIndex;
            }
        }

        //instantiate the dialogueLines with the proper dimension
        dialogueLinesTree = new Dialogue[(dialogueLinesLength + 1), 3];

        //populate the matrix with empty dialogue
        for (int n = 0; n < dialogueLinesTree.GetUpperBound(0) + 1; n++)
        {
            for (int m = 0; m < dialogueLinesTree.GetUpperBound(1) + 1; m++)
            {
                dialogueLinesTree[n, m] = emptyDialogue;
            }
        }

        //setting the dialogues in the dialogueLinesTree
        for (int l = 0; l < dialogues.Length; l++)
        {

            if (dialogues[l].dialogueChoice == 'n')
            {
                dialogueLinesTree[dialogues[l].dialogueIndex, 0] = dialogues[l];
            }

            if (dialogues[l].dialogueChoice == 'f')
            {
                dialogueLinesTree[dialogues[l].dialogueIndex, 1] = dialogues[l];
            }

            if (dialogues[l].dialogueChoice == 't')
            {
                dialogueLinesTree[dialogues[l].dialogueIndex, 2] = dialogues[l];
            }
        }
    }
}
