using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tongue : MonoBehaviour
{
    Shooting shooting;
    
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.S.points += 100;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            shooting.mouthFull = true;
        }
    }
}
