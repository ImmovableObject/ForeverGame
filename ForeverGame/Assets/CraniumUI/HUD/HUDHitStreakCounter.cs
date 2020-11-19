using System.Collections;
using UnityEngine;

public class HUDHitStreakCounter : MonoBehaviour {
    //Add the HUD Manager to Script
    HUDManager HM;
    public GameObject hudManager;

    //Speed that the script will check for changes; Lower number for faster rate
    private float refreshRate = 0.1f;

    //Reference the Textmesh component
    TextMesh textMesh;

    //Function that runs once when the Object is enabled
    void Awake() {
        //Set up some shortcuts for the Textmesh and the HUD Manager
        HM = hudManager.GetComponent<HUDManager>();
        textMesh = GetComponent<TextMesh>();
       
        //Start checking for changes
        StartCoroutine(RefreshText());
    }
    
    //A Function that is set to loop
    IEnumerator RefreshText(){
        //Wait for the time to pass in seconds
        yield return new WaitForSeconds(refreshRate);

        //If the number isn't high enough display nothing
        if (HM.KillStreak <= 2) { textMesh.text = ""; }
        
        //Otherwise set text to the string "Kill Streak: " and then add the Int value of HM.KillSteak converted to String
        else textMesh.text = "Kill Streak: " + HM.KillStreak.ToString();

        //Restart the loop
        StartCoroutine(RefreshText());
    }
}