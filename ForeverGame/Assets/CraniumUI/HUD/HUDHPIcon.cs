using System.Collections;
using UnityEngine;

public class HUDHPIcon : MonoBehaviour{
     //Add the HUD Manager to Script
    HUDManager HM;
    public GameObject hudManager;

    //Speed that the script will check for changes; Lower number for faster rate
    private float refreshRate = 0.1f;

    //The value of HP that this object represents
    public int HPNumber;

    //Reference the Textmesh component
    SpriteRenderer spriteRenderer;

    //Reference Sprites that the object will change to at different states
    public Sprite Normal;
	public Sprite Metal;
   
    //Function that runs once when the Object is enabled
    void Awake (){
        //Set up some shortcuts for the SpriteRenderer and the HUD Manager
        HM = hudManager.GetComponent<HUDManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Start checking for changes
        StartCoroutine(Refresh());
    }
    
    //A Function that is set to loop
    IEnumerator Refresh()
    {
        //Wait for the time to pass in seconds
        yield return new WaitForSeconds(refreshRate);

        //Run the CheckHP funtion
        CheckHP();
        
        //Restart the loop
        StartCoroutine(Refresh());
    }

    //This Function checks how much HP the player has and set the ojects SpriteRenderer to the correct Sprite
    void CheckHP()
    {
        //We don't want to changed the Value of HPNumber when CurrentHP is doubled, so we hold a copy in DoubleHP and then add 3.(Because we have 3 hearts in this project)
        int DoubleHP = HPNumber + 3;

        //We don't want to changed the Value of HPNumber when CurrentHP is doubled, so we hold a copy in HalfHP and then subtract 1.
        int HalfHP = HPNumber - 1;

        //If HM.CurrentHP is not lower then 0, make sure it's visible
        if (HM.CurrentHP >= 1){spriteRenderer.enabled = true; }

        //If HM.CurrentHP is a number lower then HPNumber, hide it
        if (HM.CurrentHP < HPNumber) {spriteRenderer.enabled = false; }

        //If the HM.CurrentHP is not being doubled and its not lower then HPNumber
        if (!HM.ArmorEquipped && HM.CurrentHP >= HPNumber)
        {
            //Make sure it's set to the Normal Sprite
            if (HM.CurrentHP >= HPNumber){spriteRenderer.sprite = Normal; return; }
        }
        //If the CurrentHP IS being doubled
        if (HM.ArmorEquipped)
        {
            //Set the Sprite to Normal if HM.CurrentHP is not Less then HalfHP. Which in this case is the Normal Amount.
            if (HM.CurrentHP >= HalfHP){spriteRenderer.sprite = Normal; }
           
            //If it's being doubled use the Metal Sprite
            if (HM.CurrentHP >= DoubleHP){spriteRenderer.sprite = Metal; return; }
        }
    }
}