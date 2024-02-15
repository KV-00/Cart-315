using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{   
    private SpriteRenderer sr;
    public float xLoc = 0;
    public float bedSpeed = .05f;
    
    public float score = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && xLoc > -4f){
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 5f);
            xLoc -= bedSpeed;
        }

        if(Input.GetKey(KeyCode.RightArrow) && xLoc < 4f){
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -5f);
            xLoc += bedSpeed;
        }

        this.transform.position = new Vector3(xLoc, transform.position.y, transform.position.z);

    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Sleepy") {
            score += 1;
        }
        else{
            score -= 1;
        }
        Destroy(other.gameObject);
    }
}
