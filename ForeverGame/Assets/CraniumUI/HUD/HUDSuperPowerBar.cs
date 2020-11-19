using System.Collections;
using UnityEngine;

public class HUDSuperPowerBar : MonoBehaviour {

    //Add the HUD Manager to Script
    HUDManager HM;
    public GameObject hudManager;

    //Speed that the script will check for changes; Lower number for faster rate
    private float refreshRate = 0.1f;

    //Reference the ParticleSystem of the object
    ParticleSystem ps;

    public float[] FillStages;
    public float StartSize;

    //Function that runs once when the Object is enabled
    void Awake ()
    {
        //Set up some shortcuts for the ParticleSystem and hudManager
        HM = hudManager.GetComponent<HUDManager>();
        ps = GetComponent<ParticleSystem>();

        //Access the main module of ps. This is forgotten after Awake is done executing.
        var psMain = ps.main;

        //Make sure the start size and speed of spawned particles is 0.0f at the start
        psMain.startSize = 0.0f;
        psMain.startSpeed = 0.0f;
       
        //Start checking for changes
        StartCoroutine(Refresh());
    }

    //A Function that is set to loop
    IEnumerator Refresh()
    {
        //Wait for time to pass in seconds
        yield return new WaitForSeconds(refreshRate);

        //Access the main module of ps. This is forgotten after each loop of Refresh
        var psMain = ps.main;

        //Is HM.SuperPowerEquipped is equal to or greater then 1
        if (HM.SuperPowerEquipped >= 1)
        {
            //Run SetStage funtion to determine size and speed
            psMain.startSize = StartSize;
            SetStage();
        }
        //Otherwise make sure the speed and size are 0.0f.
        else
        {
            psMain.startSize = 0.0f;
            psMain.startSpeed = 0.0f;
        }

        //Restart the loop
        StartCoroutine(Refresh());
    }

    //Set the size and speed of particles based the value of HM.SuperPowerPercentage
    void SetStage()
	{	
		var psMain = ps.main;

		switch(HM.SuperPowerPercentage){	
		case 0:
                psMain.startSize = 0.0f;
                psMain.startSpeed = 0.0f;
                return;
		case 5:
                psMain.startSize = StartSize;
                psMain.startSpeed = FillStages[0];
                return;
		case 10:psMain.startSpeed = FillStages[1]; return;
		case 15:psMain.startSpeed = FillStages[2]; return;	
		case 20:psMain.startSpeed = FillStages[3]; return;
		case 25:psMain.startSpeed = FillStages[4]; return;			
		case 30:psMain.startSpeed = FillStages[5]; return;			
		case 35:psMain.startSpeed = FillStages[6]; return;			
		case 40:psMain.startSpeed = FillStages[7]; return;			
		case 45:psMain.startSpeed = FillStages[8]; return;
		case 50:psMain.startSpeed = FillStages[9]; return;			
		case 55:psMain.startSpeed = FillStages[10]; return;
		case 60:psMain.startSpeed = FillStages[11]; return;
		case 65:psMain.startSpeed = FillStages[12]; return;
		case 70:psMain.startSpeed = FillStages[13]; return;
		case 75:psMain.startSpeed = FillStages[14]; return;
		case 80:psMain.startSpeed = FillStages[15]; return;
		case 85:psMain.startSpeed = FillStages[16]; return;
		case 90:psMain.startSpeed = FillStages[17]; return;
		case 95:psMain.startSpeed = FillStages[18]; return;
		case 100:psMain.startSpeed = FillStages[19]; return;
		}
	}
}