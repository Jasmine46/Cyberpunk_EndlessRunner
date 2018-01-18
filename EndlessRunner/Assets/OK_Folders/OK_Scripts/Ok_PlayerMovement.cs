using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ok_PlayerMovement : MonoBehaviour
{

    #region Variables
    // Setting Gameobject variables
    public Rigidbody2D rb_PlayerRigid;
    private GameObject mGO_Player;

    // Variables controlling speed of player
    public float fl_JumpSpeed;


    // Variables Controlling the direction
    private float fl_GravityDirection;
    public bool bl_GravitySwitch = false;

    // Variables involved in swipe controls
    private Vector2 V2_FirstTouchPos;
    private Vector2 V2_LastTouchPos;
    private float fl_dragDist; // Min distance for swipe register

    #endregion


    // Use this for initialization
    void Start()
    {
        rb_PlayerRigid = gameObject.GetComponent<Rigidbody2D>();
        mGO_Player = gameObject;

        fl_dragDist = Screen.height * 15 / 100; // Distance is 15% of screen height
    }

    private void Update()
    {
        Gravity();
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)//Check for first touch
            {
                V2_FirstTouchPos = touch.position;
                V2_LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) //Update last position based on if it has been moved. 
            {
                V2_LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) // Check if finger has been removed
            {
                V2_LastTouchPos = touch.position;

                // Check if more than 15% of the screen space has been moved.

                if (Mathf.Abs(V2_LastTouchPos.x - V2_FirstTouchPos.x) > fl_dragDist || Mathf.Abs(V2_LastTouchPos.y - V2_FirstTouchPos.y) > fl_dragDist)
                {
                    // Check if the drag is veritcal or horizontal
                    if (Mathf.Abs(V2_LastTouchPos.x - V2_FirstTouchPos.x) > Mathf.Abs(V2_LastTouchPos.y - V2_FirstTouchPos.y))
                    {
                        // If the horizontal movement is greater
                        if (V2_LastTouchPos.x > V2_FirstTouchPos.x)
                        {
                            Debug.Log("Right Swipe");
                            
                        }
                        else
                        {
                            Debug.Log("Left Swipe");
                            
                        }

                    }
                    else
                    {
                        if (V2_LastTouchPos.y > V2_FirstTouchPos.y)
                        {
                            Debug.Log("Up Swipe");
                            if(bl_GravitySwitch == false)
                            {
                                SwitchGravity();
                            }

                        }
                        else
                        {
                            Debug.Log("Down Swipe");
                            if (bl_GravitySwitch == true)
                            {
                                SwitchGravity();
                            }
                        }

                    }

                }
                else
                {
                    rb_PlayerRigid.velocity = transform.up * fl_JumpSpeed;
                    Debug.Log("Tap");
                }

            }

        }

    }

    void Gravity()
    {
        if (bl_GravitySwitch == true)
        {
            rb_PlayerRigid.gravityScale = -1f;
        }


        else if (bl_GravitySwitch == false)
        {
            rb_PlayerRigid.gravityScale = 1f;
        }

    }

    void SwitchGravity()
    {


        if (bl_GravitySwitch)
        {
            bl_GravitySwitch = false;
            mGO_Player.transform.Rotate(180, 0, 0);
        }

        else
        {
            bl_GravitySwitch = true;
            mGO_Player.transform.Rotate(180, 0, 0);
        }

    }
}
