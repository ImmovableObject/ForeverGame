using System.Collections;
using UnityEngine;

public class HUDSuperPowerMeter : MonoBehaviour {

    HUDManager HM;
    public GameObject hudManager;
    private float refreshRate = 0.1f;
    
    //Function that runs once when the Object is enabled
    void Awake()
    {
        //Set a shortcuts for the hudManager
        HM = hudManager.GetComponent<HUDManager>();

        //Start checking for changes
        StartCoroutine(Refresh());
    }
    
    //A Function that is set to loop
    IEnumerator Refresh()
    {
        //Wait for time to pass in seconds
        yield return new WaitForSeconds(refreshRate);

        //If the player has a super meter turn on the renderer. Otherwise turn it off.
        if (HM.SuperPowerEquipped >= 1) {GetComponent<Renderer>().enabled = true;}
        else {GetComponent<Renderer>().enabled = false; }

        //Restart the loop
        StartCoroutine(Refresh());
    } 
}