using System.Collections;
using UnityEngine;

public class HUDUIHide : MonoBehaviour
{
    HUDManager HM;
    public GameObject hudManager;
    private float refreshRate = 0.1f;
    Renderer r;
    public bool BossItem;

    //Function that runs once when the Object is enabled
    void Awake()
    {
        r = GetComponent<Renderer>();
        HM = hudManager.GetComponent<HUDManager>();
        StartCoroutine(Refresh());
    }

    //A Function that is set to loop
    IEnumerator Refresh()
    {
        //Wait for time to pass in seconds
        yield return new WaitForSeconds(refreshRate);
        CheckActive();
    }

    void CheckActive(){
        //If the boss is not active and the element is a BossItem, turn off renderer
        if (BossItem && !HM.BossActive){r.enabled = false;}
        
        //If there is an active menu turn off renderer. If there isn;t turn it on.
        if (HM.ActiveMenu >= 1){r.enabled = false;}
		if(HM.ActiveMenu <= 0){r.enabled = true;}
        
        //Restart the loop
        StartCoroutine(Refresh());
    }
}