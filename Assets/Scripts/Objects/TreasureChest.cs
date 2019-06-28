using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    [Header("Contents")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signals and Dialog")]
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animator")]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RunTimeValue;
        if (isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                //Open the chest
                OpenChest();
            }
            else
            {
                //Chest is already open
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        //Dialog window on
        dialogBox.SetActive(true);
        //Dialog text = contents text
        dialogText.text = contents.itemDescription;
        //Add contents to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //Raise the signal to the player to animate
        raiseItem.Raise();
        //Raise the context clue
        context.Raise();
        //Set the chest to opened
        isOpen = true;
        anim.SetBool("opened", true);
        storedOpen.initialValue = isOpen;

    }

    public void ChestAlreadyOpen()
    {
        //Dialog off
        dialogBox.SetActive(false);
        //Raise the signal to the player to stop animating
        raiseItem.Raise();
           
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
