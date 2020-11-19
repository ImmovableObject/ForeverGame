using System.Collections;
using UnityEngine;

public class HUDBossHpBar : MonoBehaviour {

    //Add the HUD Manager to Script
    HUDManager HM;
    public GameObject hudManager;

    //Speed that the script will check for changes; Lower number for faster rate
    private float refreshRate = 0.1f;

    //Float to Recalulate Boss Hp to a percent
    float BossPercentHP;

    //What part of the bar is the object
    public int PipNum;

    //The Renderer of the object
    Renderer r;

    //Function that runs once when the Object is enabled
    void Awake ()
    {
        //Set up some shortcuts for the renderer and the HUD Manager
        r = gameObject.GetComponent<Renderer>();
        HM = hudManager.GetComponent<HUDManager>();

        //Start checking for changes
        StartCoroutine(Refresh());
    }

    //A Function that is set to loop
    IEnumerator Refresh()
    {
        //Wait for the time to pass in seconds
        yield return new WaitForSeconds(refreshRate);

        //Check if the object should be on or not
        CheckPercent();

        //Restart the loop
        StartCoroutine("Refresh");
    }

    void CheckPercent()
    {
        //If the boss is not started hide yourself
        if (!HM.BossActive)
        {
            r.enabled = false;
            return;
        }

        //Take the Maximum Boss HP amount and convert it to a percentage
        BossPercentHP = HM.CurrentBossHP / HM.MaxBossHP * 100;

        //If the BossPercentHP is less then the object; hide it 
        if (BossPercentHP < PipNum)
        {
            r.enabled = false;
            return;
        }
        //Otherwise make sure it's turned on
        if (BossPercentHP >= PipNum)
        {
            r.enabled = true;
        }
    }
}