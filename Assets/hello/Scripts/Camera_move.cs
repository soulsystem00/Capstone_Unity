using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class Camera_move : MonoBehaviour
{
    public float Speed=0.25f;
    public Vector2 nowPos, prePos;
    public Vector3 movePos;
    public Vector2 maxPos;
    public float move_sensitivity;
    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        move_sensitivity = 0.5f;
        Speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.position.x + " " + touch.position.y);
            if(touch.position.y >= 300)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    prePos = touch.position - touch.deltaPosition;
                    //this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    Debug.Log(prePos);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    nowPos = touch.position - touch.deltaPosition;
                    movePos = (Vector3)(prePos - nowPos) * Speed / Convert.ToSingle(gm.Gm_speed);
                    if (-move_sensitivity < movePos.x && movePos.x < move_sensitivity)
                        this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    else
                        this.GetComponent<Rigidbody2D>().velocity = new Vector3(movePos.x, 0, 0);

                    prePos = touch.position - touch.deltaPosition;
                }
                /*            else if(touch.phase == TouchPhase.Ended) 너무 뻑뻑함 
                            {
                                this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                            }*/
            }

        }
    }
}

