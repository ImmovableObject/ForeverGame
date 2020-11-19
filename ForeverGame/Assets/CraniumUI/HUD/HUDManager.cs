using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour {

    //Which menu is currently open; 0 means none.
    public int ActiveMenu;

    //Sets to true if the player is in a boss fight.
    public bool BossActive = false;

    //For Testing purposes
    public bool KeepElementsActive = false;

    //Float used to determine the HP of the Boss. It's a copy of MaxBossHP. This is Used to change the bar in the HUD.
    public float CurrentBossHP = 200;
    //Float used to determine the MaximumHP of the Boss; Default is 200
    public float MaxBossHP = 200;

    //Maximum amount of HP the player can have; Doubled with armor.
    public int MaxHP = 3;
    
    //Current amount of HP the player has.
    public int CurrentHP;

    //If set to true will double MaxHP at start
    public bool ArmorEquipped;

    //The amount of points awarded to the player
    public int CurrentScore;

    //The amount of money earned by the player
    public int MoneyEarned;

    //How mant kills the player achieved in a row without getting hit
    public int KillStreak;

    //What percentage of SuperPower earned though enemy kills
    public int SuperPowerPercentage;

    //If set to 1 the players Superpower is used
    public int SuperPowerActive = 0;

    //Which SuperPower is Equipped
    public int SuperPowerEquipped = 1;

    //All the elements of the Hud are stored in this array
    public GameObject[] HUDElements;


    public void Awake()
    {
        if (KeepElementsActive)
        {
            ActiveAnimationBool(0, "Active", true);
            ActiveAnimationBool(1, "Active", true);
            ActiveAnimationBool(2, "Active", true);
            ActiveAnimationBool(3, "Active", true);
            ActiveAnimationBool(4, "Active", true);
            ActiveAnimationBool(5, "Active", true);
            ActiveAnimationBool(6, "Active", true);
            ActiveAnimationBool(7, "Active", true);
            ActiveAnimationBool(8, "Active", true);
        }
    }


    //Change the active menu to the int passed by i
    public void ChangeMenu(int i)
    {
        ActiveMenu = i;
    }

    //Boss Functions

    //Set MaxBossHP to the value of i and then make a copy of it for use in the HUD.
    public void SetBossHP(int i)
    {
        MaxBossHP = i;
        CurrentBossHP = MaxBossHP;
    }

    //Heal the Boss the value of i
    public void AddBossHP(int i)
    {
        CurrentBossHP = CurrentBossHP + i;

        //Can't go above MaxBossHP
        if (CurrentBossHP >= MaxBossHP)
        {
            CurrentBossHP = MaxBossHP;
        }
    }
    //Hurt the Boss the value of i
    public void SubtractBossHP(int i)
    {
        CurrentBossHP = CurrentBossHP - i;

        //Can't go below 0
        if (CurrentBossHP <= 0)
        {
            CurrentBossHP = 0;
        }
    }
    //Turn the boss on and animate the BossHP HUD element to Scroll up
    public void EnableBoss()
    {
        ActiveAnimationBool(8, "Active", true);
        BossActive = true;
    }
    //Turn the boss off and animate the BossHP HUD element to Scroll down
    public void DisableBoss()
    {
        ActiveAnimationBool(8, "Active", false);
        BossActive = false;
    }

    //The rest of the HUD funtions follow a simular setup

    //Score Funtions
    public void SetScore(int i)
    {
        ActiveAnimationBool(4, "Active", true);
        ActivateAnimationTrigger(5, "Play");
        CurrentScore = i;
    }

    public void AddScore(int i)
    {
        ActiveAnimationBool(4, "Active", true);
        ActivateAnimationTrigger(5, "Play");
        CurrentScore = CurrentScore + i;

        //Can't go above 999999999
        if (CurrentScore >= 999999999)
        {
            CurrentScore = 999999999;
        }
    }
    public void SubtractScore(int i)
    {
        ActiveAnimationBool(4, "Active", true);
        ActivateAnimationTrigger(5, "Play");
        CurrentScore = CurrentScore - i;

        //Can't go below 0
        if (CurrentScore <= 0)
        {
            CurrentScore = 0;
        }
    }

    //Player HP
    public void SetHP(int i)
    {
        ActiveAnimationBool(7, "Active", true);
        CurrentHP = i;
    }
    public void AddHP(int i)
    {
        ActiveAnimationBool(7, "Active", true);

        if (ArmorEquipped)
        {
            MaxHP = 6;
        }
        else {MaxHP = 3;}

        if (CurrentHP < MaxHP)
        {
            CurrentHP = CurrentHP + i;
        }
        //Can't go above MaxHP
        if (MoneyEarned >= MaxHP)
        {
            MoneyEarned = MaxHP;
        }
    }
    public void SubtractHP(int i)
    {
        ActiveAnimationBool(7, "Active", true);

        if (ArmorEquipped)
        {
            MaxHP = 6;
        }
        else { MaxHP = 3; }

        if (CurrentHP > 0)
        {
            CurrentHP = CurrentHP - i;
        }

        //Can't go below 0
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
        }
    }
    public void ToggleArmor()
    {
        if (ArmorEquipped)
        {
            ArmorEquipped = false;
        }
        else ArmorEquipped = true;
    }

    //Money
    public void SetMoney(int i)
    {
        ActivateAnimationTrigger(2,"Play");
        ActiveAnimationBool(1, "Active", true);
        MoneyEarned = i;
    }
    public void AddMoney(int i)
    {
        ActivateAnimationTrigger(2, "Play");
        ActiveAnimationBool(1, "Active", true);
        MoneyEarned = MoneyEarned + i;
        
        //Can't go above 999999999
        if (MoneyEarned >= 999999999)
        {
            MoneyEarned = 999999999;
        }
    }
    public void SubtractMoney(int i)
    {
        ActivateAnimationTrigger(2, "Play");
        ActiveAnimationBool(1, "Active", true);
        MoneyEarned = MoneyEarned - i;;
        //Can't go below 0
        if (MoneyEarned <= 0)
        {
            MoneyEarned = 0;
        }
    }

    //KillStreak
    public void SetKillStreak(int i)
    {
        ActivateAnimationTrigger(6, "Play");
        KillStreak = i;
    }
    public void AddKillStreak(int i)
    {
        ActivateAnimationTrigger(6, "Play");
        KillStreak = KillStreak + i;
        
        //Can't go above 999999999
        if (KillStreak >= 999999999)
        {
            KillStreak = 999999999;
        }
    }
    public void SubtractKillStreak(int i)
    {
        ActivateAnimationTrigger(6, "Play");
        KillStreak = KillStreak - i;
        
        //Can't go below 0
        if (KillStreak <= 0)
        {
            KillStreak = 0;
        }
    }

    //Super Power Meter
    public void SetSuperPower(int i)
    {
        ActiveAnimationBool(0, "Active", true);
        SuperPowerPercentage = i;
    }
    public void AddSuperPower(int i)
    {
        ActiveAnimationBool(0, "Active", true);
        SuperPowerPercentage = SuperPowerPercentage + i;

        //Can't go above 100
        if(SuperPowerPercentage >= 100)
        {
            SuperPowerPercentage = 100;
        }
    }
    public void SubtractSuperPower(int i)
    {
        ActiveAnimationBool(0, "Active", true);
        SuperPowerPercentage = SuperPowerPercentage - i;

        //Can't go below 0
        if (SuperPowerPercentage <= 0)
        {
            SuperPowerPercentage = 0;
        }
    }

    //Activate a Trigger of an animation on the array with the interger value of i; the name of the trigger is the string passed to s
    public void ActivateAnimationTrigger(int i, string s)
    {
        HUDElements[i].GetComponent<Animator>().SetTrigger(s);
    }

    //Activate the animation on an object. i is the array number, s is the string name of the animation and b the bool value.
    public void ActiveAnimationBool(int i, string s, bool b)
    {
        HUDElements[i].GetComponent<Animator>().SetBool(s, b);
        if (HUDElements[i] != HUDElements[8])
        {
         StartCoroutine(Refresh(i, s));
        }
    }

    //Loops through the different HUD elements for changes.
    IEnumerator Refresh(int i, string s)
    {
        if (!KeepElementsActive)
        {
            yield return new WaitForSeconds(3f);
            HUDElements[i].GetComponent<Animator>().SetBool(s, false);
        }
    }

}
