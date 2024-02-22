using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private SpriteRenderer sr;
    public float xPos = 0;
    public float yPos = 0;

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            xPos = -1f;
        }

        if(Input.GetKey(KeyCode.D)){
            xPos = +1f;
        }

        if(Input.GetKey(KeyCode.S)){
            yPos = -1f;
        }

        if (Input.GetKey(KeyCode.W)){
            yPos = +1f;
        }

        Vector3 movementDirection = new Vector3(xPos, yPos, transform.position.z).normalized;
        transform.position += movementDirection * speed * Time.deltaTime;

        xPos = 0;
        yPos = 0;

    }
}

