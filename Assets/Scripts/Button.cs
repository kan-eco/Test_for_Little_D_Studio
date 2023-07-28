using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    GameObject TurnObject;

    bool trigerStatus = false;

    void Update()
    {
        if (trigerStatus == true)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            TurnObject.GetComponent<Floor>().Open(true);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            TurnObject.GetComponent<Floor>().Open(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        trigerStatus = true;
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        trigerStatus = false;
    }
}
