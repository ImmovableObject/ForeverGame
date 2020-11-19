using System.Collections;
using UnityEngine;

namespace Mirror.Examples.Pong
{
    public class PlayerMovement : NetworkBehaviour
    {
        //Set The Movment Speed
        public float TiredSpeed;
        public float WalkSpeed;
        public float DashSpeed;
        public float PlayerSpeed;

        public bool Moving;
        public bool Dashing;
        public bool Tired;
        public float Stamina;
        public GameObject playerSprite;

        public int Level;

        public int Direction;

        public bool damaged;

        public Sprite[] PlayerSprites;

        //Speed that the script will check for changes; Lower number for faster rate
        public float recoverRate = 0.1f;
        public float waitToRecoverRate = 5f;

        //The Renderer of the object
        SpriteRenderer sr;

        //Function that runs once when the Object is enabled
        void OnEnable()
        {
            if (isLocalPlayer)
            {
                //Set up some shortcuts for the renderer and the HUD Manager
                StartCoroutine(Recover());
            }
        }

        IEnumerator Recover()
        {
            //Wait for the time to pass in seconds

            yield return new WaitForSeconds(recoverRate);
            if (!Dashing)
            {
                Stamina = Stamina + 1;
            }
            if (Input.GetAxisRaw("Dash") > 0.0f && Moving)
            {
                Stamina = Stamina - 2;
            }

            if (Stamina > 100) { Stamina = 100; }
            if (Stamina < 0)
            {
                Stamina = 0;
                Tired = true;
                StartCoroutine(WaitToRecover());
            }
            else
            {
                StartCoroutine(Recover());
            }
        }

        IEnumerator WaitToRecover()
        {
            //Wait for the time to pass in seconds

            yield return new WaitForSeconds(waitToRecoverRate);
            Tired = false;

            StartCoroutine(Recover());
        }


        //Change sprite based on Lastirection
        void CheckDirection()
        {
            sr = playerSprite.GetComponent<SpriteRenderer>();

            switch (Direction)
            {
                case 1:
                    sr.sprite = PlayerSprites[0];
                    return;
                case 2:
                    sr.sprite = PlayerSprites[1];
                    return;
                case 3:
                    sr.sprite = PlayerSprites[2];
                    return;
                case 4:
                    sr.sprite = PlayerSprites[3];
                    return;
            }
        }

        void CheckDash()
        {
            if (Tired)
            {
                Dashing = false;
                PlayerSpeed = TiredSpeed;
            }
            else
                Dashing = false;
            PlayerSpeed = WalkSpeed;

            if (Input.GetAxisRaw("Dash") > 0.0f && !Tired)
            {
                Dashing = true;
                PlayerSpeed = DashSpeed;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer)
            {
                CheckDirection();
                CheckDash();

                // Amount to move
                float horizontalAxis = Input.GetAxisRaw("Horizontal") * PlayerSpeed * Time.deltaTime;
                float verticalAxis = Input.GetAxisRaw("Vertical") * PlayerSpeed * Time.deltaTime;

                if (PlayerSpeed > 0)
                {
                    Moving = true;
                }
                if (horizontalAxis == 0.0f && verticalAxis == 0.0f)
                {
                    PlayerSpeed = 0;
                    Moving = false;
                }

                if (horizontalAxis < 0.0f)
                {
                    Direction = 2;
                }
                if (horizontalAxis > 0.0f)
                {
                    Direction = 3;
                }

                if (verticalAxis < 0.0f)
                {
                    Direction = 1;
                }
                if (verticalAxis > 0.0f)
                {
                    Direction = 4;
                }

                transform.Translate(Vector3.up * verticalAxis);
                transform.Translate(Vector3.right * horizontalAxis);

                GetComponent<Animator>().SetBool("Moving", Moving);
                GetComponent<Animator>().SetBool("Dashing", Dashing);
                GetComponent<Animator>().SetInteger("Direction", Direction);
            }
        }
    }
}