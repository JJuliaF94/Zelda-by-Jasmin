using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool active;
    public BoolValue storedValue;
    //change the Sprite by Switch
    public Sprite activeSprite;
    //Reference to the Sprite Renderer
    private SpriteRenderer mySprite;
    //Reference to the Door
    public Door thisDoor;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        active = storedValue.RunTimeValue;
        if (active)
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        active = true;
        storedValue.RunTimeValue = active;
        thisDoor.Open();
        mySprite.sprite = activeSprite;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Is it the Player?
        if (other.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }
}
