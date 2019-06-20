using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;
    /*another option for the ContextClue without needing the Signal:
    public bool contextActive = false;
    instead of usign the following lines (not disabled) you could say:
    public void ChangeContext()
    {
    contextActive = !contextActive;
    if(contextActive){
    contextClue.setActive(true);
    }else{
    contextClue.setActive(false);
    }  

    than you have to remove one of the Signal Listener(Script)'s from the Player (Inspector)
    and put the ContextClue.ChangeContext Event (Signal) in the other
    now you have to change the Sign.cs Script:
    line 39 and 48 (in the Sign Script) if(other.CompareTag("Player"))
    you have to add:
    if(other.CompareTag("Player") && !other.isTrigger)  
    in both lines
    then you have to remove the public Signal contextOff; in line 9 in the Sign Script
    and change line 8 from public Signal contextOn; to:
    public Signal context; 
    and change line 41 and 50 in the Sign Script by removing the Off and On from the context
    than delete the Context Clue Off from the ScriptableObjects folder and put instead the Context Clue On in the missing Context'es:
    Player Signal and Sign Context  
    */

    public void Enable()
    {
        contextClue.SetActive(true);  
    }

    public void Disable()
    {
        contextClue.SetActive(false);
    }
}
