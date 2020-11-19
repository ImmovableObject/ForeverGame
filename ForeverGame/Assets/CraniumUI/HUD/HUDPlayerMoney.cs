using System.Collections;
using UnityEngine;

public class HUDPlayerMoney : MonoBehaviour
{
    //Add the HUD Manager to Script
    HUDManager HM;
    public GameObject hudManager;

    //Speed that the script will check for changes; Lower number for faster rate
    private float refreshRate = 0.1f;

    //Reference the TextMesh of the object
    TextMesh textMesh;

    //Function that runs once when the Object is enabled
    void Awake()
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

        //Set the string value of textMesh to the Int value of HM.MoneyEarned converted to string
        textMesh.text = HM.MoneyEarned.ToString();

        //Restart the loop
        StartCoroutine(Refresh());
    }
}