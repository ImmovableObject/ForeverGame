using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public GameObject player;
    private Text stamText;

    // Start is called before the first frame update
    void OnEnable()
    {
        stamText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //string Stam = player.GetComponent<PlayerMovement>().Stamina.ToString();

        //stamText.text = Stam + ("%");
    }
}
