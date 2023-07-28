using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floor : MonoBehaviour
{
    bool status = false;
    public float speed = 3;


    // Update is called once per frame
    void Update()
    {
        if (status == true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            if (transform.position.x <= -3)
            { 
                transform.position = new Vector3(-3,transform.position.y, transform.position.z);
            }

        }

        if(status == false) 
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            if (transform.position.x >= 0)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            }
        }
    }

    public void Open(bool st)
    {
        if (st == true) 
        {
            status = true;
        }

        if (st == false)
        {
            status = false;
        }
    }
}
