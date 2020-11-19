using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float refreshRate = 0.01f;
    Animator anim;
    private int direction;
    public Vector3 rotateSpeed;
    //Function that runs once when the Object is enabled
    void Awake()
    {
        anim = GetComponent<Animator>();
        //Start checking for changes
        StartCoroutine(Refresh());
        direction = 1;
        //public Vector3 PlayerSpeed(0,0,1;
    }

    void StopTransistion()
    {
        anim.SetBool("Transistioning", false);
    }

        //A Function that is set to loop
        IEnumerator Refresh()
    {
        //Wait for the time to pass in seconds
        yield return new WaitForSeconds(refreshRate);

        float Vert = Input.GetAxisRaw("Rotate");
        //float amtToMoveHori = Input.GetAxisRaw("Horizontal") * PlayerSpeed * Time.deltaTime;

        if (Vert > 0.0f)
        {
            transform.Rotate(-rotateSpeed);
            /*
            Debug.Log("RotateRight");
            anim.SetBool("Transistioning", true);
            ++direction;
            if (direction >8){direction = 1;}
            anim.SetInteger("Direction", direction);
            */
        }
        if(Vert < 0.0f)
        {
            transform.Rotate(rotateSpeed);
            /*
            Debug.Log("RotateLeft");
            anim.SetBool("Transistioning", true);
            --direction;
            if (direction < 1){direction = 8;}
            anim.SetInteger("Direction", direction);
            */
        }
       // else
       // {
//
      //  }

        //Restart the loop
        StartCoroutine(Refresh());
    }
}
