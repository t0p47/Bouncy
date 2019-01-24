using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        float lastCollideTime;

        float h;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            bool crouch = Input.GetKey(KeyCode.LeftControl);
            h = CrossPlatformInputManager.GetAxis("Horizontal");

            //Debug.Log(h);
            if (h == 0)
            {
                //Debug.Log("FreezeX");
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else {
                h = h + 10 * Time.deltaTime;
                //Debug.Log(h);
                //GetComponent<Rigidbody2D>().AddForce(transform.right+transform.up * 150*Time.deltaTime);
                //Debug.Log(transform.right - transform.up);
                //Debug.Log("Unfreeze");

                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            // Pass all parameters to the character control script.

            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;

        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            /*h = CrossPlatformInputManager.GetAxis("Horizontal");
            
            //Debug.Log(h);
            if (h == 0)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            }
            else {
                if (lastCollideYPos > transform.position.y) {
                    h += 0.7f * Time.deltaTime;
                }
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
            // Pass all parameters to the character control script.
            
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;*/
        }

        /*void OnCollisionEnter2D(Collision2D coll) {

            
            //lastCollideYPos = coll.contacts[0].point.y;
        }*/
    }
}
