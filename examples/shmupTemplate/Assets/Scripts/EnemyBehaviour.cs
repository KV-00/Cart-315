using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
float speed = 2f;

void Update(){
	transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
}
}