using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    void Update()
    {
        
    }

    private IEnumerator EnemySpawn() {
        float x = Random.Range(-3.5f,3.5f);
        Instantiate(enemy, new Vector3(x, 6, 0), Quaternion.identity);

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(EnemySpawn());
    }
}
