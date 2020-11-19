using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportBox : MonoBehaviour
{
    public bool Entrance;
    public bool Cardrive;
    public GameObject Interior;
    public GameObject Exit;
    public GameObject Player;
    public GameObject Truck;
    public GameObject BlueCap;

    void OnEnable()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(CoolOff());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (Cardrive)
        {
            Truck.GetComponent<Animator>().SetBool("Drive", true);
            Destroy(gameObject);
            return;
        }

        if (Entrance)
        {
            Interior.SetActive(true);
            Player.transform.parent = Interior.transform;
            gameObject.SetActive(false);
        }
        else
        {
            Interior.SetActive(false);
            Player.transform.parent = null;
            Exit.SetActive(true);
            BlueCap.SetActive(true);
        }
    }

    IEnumerator CoolOff()
    {
        //Wait for the time to pass in seconds
        yield return new WaitForSeconds(0.1f);
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
