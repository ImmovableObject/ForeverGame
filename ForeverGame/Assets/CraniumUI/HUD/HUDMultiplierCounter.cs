using System.Collections;
using UnityEngine;

public class HUDMultiplierCounter : MonoBehaviour{

    //Add the HUD Manager to Script
    HUDManager HM;
    public GameObject hudManager;
   
    //Speed that the script will check for changes; Lower number for faster rate
    private float refreshRate = 0.1f;
    
    //Reference the TextMesh of the object
    TextMesh textMesh;

    //Function that runs once when the Object is enabled
    void Awake ()
    {
        //Set up some shortcuts for the TextMesh and the HUD Manager
        HM = hudManager.GetComponent<HUDManager>();
        textMesh = GetComponent<TextMesh>();
       
        //Start checking for changes
        StartCoroutine(Refresh());
    }
    
    //A Function that is set to loop
    IEnumerator Refresh()
    {
        //Wait for time to pass in seconds
        yield return new WaitForSeconds(refreshRate);
        
        //Check what the string value of textMesh should be
        CheckKillStreak();
        
        //Restart the loop
        StartCoroutine(Refresh());
    }

    //Set the String value of textMesh based on the value of HM.KillStreak
    void CheckKillStreak()
    {
        if (HM.KillStreak <= 10) { textMesh.text = ""; return; }
        if (HM.KillStreak <= 20) { textMesh.text = "2X Shard Multiplier!"; return; }
        if (HM.KillStreak <= 30) { textMesh.text = "3X Shard Multiplier!"; return; }
        if (HM.KillStreak <= 40) { textMesh.text = "4X Shard Multiplier!"; return; }
        if (HM.KillStreak <= 50) { textMesh.text = "5X Shard Multiplier!"; return; }
        if (HM.KillStreak <= 60) { textMesh.text = "6X Shard Multiplier!"; return; }
        if (HM.KillStreak <= 70) { textMesh.text = "7X Shard Multiplier!"; return; }
        if (HM.KillStreak <= 80) { textMesh.text = "8X Shard Multiplier!"; return; }
        if (HM.KillStreak <= 90) { textMesh.text = "9X Shard Multiplier!"; return; }
        if (HM.KillStreak <= 100) { textMesh.text = "10X Shard Multiplier!"; return; }
    }
}