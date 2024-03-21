using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private SpriteRenderer sr;
    public float xPos = 0;
    public float yPos = 0;

    public float speed = 5f;

    Rigidbody2D rb;

    [SerializeField]
    private Animator fireAnim;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fireAnim.SetFloat("yAxis", yPos);

        xPos = Input.GetAxis("Horizontal");
        yPos = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        rb.velocity += new Vector2(xPos, yPos) * speed * Time.fixedDeltaTime;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
    }
}

