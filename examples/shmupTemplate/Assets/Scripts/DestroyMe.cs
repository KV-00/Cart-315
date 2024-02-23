using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField] float killTime = 30;

    private void Start()
    {
        Destroy(this.gameObject, killTime);
    }
}
