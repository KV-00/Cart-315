using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
public float bulletVelocity;
public GameObject tongue;
public GameObject tongue1;
public GameObject mush;
public GameObject mush1;

public bool mouthFull = false;

void Start () {
	
}

void Update () {
    if (Input.GetMouseButtonDown(0))
        if (mouthFull == false)
        {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();

        GameObject tongue = (GameObject)Instantiate(
                                tongue1,
                                transform.position + (Vector3)(direction * 0.5f),
                                Quaternion.identity);

        tongue.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        }
    if (Input.GetMouseButtonDown(1))
    {
        if (mouthFull == true)
        {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();

        GameObject mush = (GameObject)Instantiate(
                                mush1,
                                transform.position + (Vector3)(direction * 0.5f),
                                Quaternion.identity);

        mush.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        }
     }
    }
}
