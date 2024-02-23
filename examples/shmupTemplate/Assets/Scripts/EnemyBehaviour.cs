using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	float speed = 2f;
	public bool targeted;

    void Update()
	{
		if (targeted)
			return;
		transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.ToLower().Contains("mush"))
        {
            ScoreScript.Instance.UpdateScore();
            Destroy(collision.collider.gameObject);
            Destroy(this.gameObject);
        }
    }
}