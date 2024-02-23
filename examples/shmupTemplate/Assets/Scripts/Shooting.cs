using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{


    [SerializeField]
    Transform tongueRef;

    [SerializeField]
    LineRenderer tongueBody;

    [SerializeField]
    Transform tongueEnd;

    [Header("Tongue init")]
    [SerializeField] private float detectionRad = 0.5f;
    [SerializeField] private float tongueReleaseSpeed = 1;

    public float bulletVelocity;
    public GameObject tonguePrefab;
    public GameObject mush;

    public bool mouthFull = false;

    private bool hasTarget;

    Coroutine tongueRoutineRef;

    Animator anim;

    void Start () {
        anim = GetComponent<Animator>();
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (hasTarget && tongueRoutineRef == null)
                Shoot();
            else
                TongueRelease();
        }
    }

    private void Shoot()
    {
        if (mouthFull == false)
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            tongueRef.GetChild(0).gameObject.SetActive(true);
            GameObject tongue = (GameObject)Instantiate(
                                    tongueRef.GetChild(0).gameObject,
                                    transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);

            anim.SetBool("mouth_is_full", false);
            Destroy(tongueRef.GetChild(0).gameObject);
            hasTarget = false;
            tongue.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        }
    }

    private void TongueRelease()
    {
        if (tongueRoutineRef != null)
            return;

        tongueRoutineRef = StartCoroutine(ToungeRoutine());
    }


    IEnumerator ToungeRoutine()
    {
        float timeStep = 0;
        Vector2 start = transform.position;
        Vector2 end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tongueBody.positionCount = 2;
        tongueBody.SetPosition(0, start);
        tongueBody.SetPosition(1, end);

        tongueEnd.gameObject.SetActive(true);
        float dur = Vector3.Distance(end, start) / tongueReleaseSpeed;

        while (timeStep <= 1)
        {
            UpdateTongueBody(start, tongueRef.position);
            start = transform.position;
            timeStep += Time.deltaTime/(dur/2);
            tongueRef.position = Vector3.Lerp(start, end, timeStep);
            tongueEnd.position = tongueRef.position;
            CheckForEnemyAndAdd();
            if (hasTarget)
                break;
            yield return new WaitForEndOfFrame();
        }

        timeStep = 0;
        while (timeStep <= 1)
        {
            start = transform.position;
            UpdateTongueBody(start, tongueRef.position);
            timeStep += Time.deltaTime / (dur/2);
            tongueRef.position = Vector3.Lerp(end, start, timeStep);
            tongueEnd.position = tongueRef.position;

            if (hasTarget)
                tongueRef.GetChild(0).localPosition = Vector3.zero;

            yield return new WaitForEndOfFrame();
        }
        tongueEnd.gameObject.SetActive(false);
        tongueBody.positionCount = 0;
        ConvertToMush();
        tongueRoutineRef = null;
    }

    private void ConvertToMush()
    {
        if (!hasTarget)
            return;

        Destroy(tongueRef.GetChild(0).gameObject);
        var go =Instantiate(mush, tongueRef.position, Quaternion.identity, tongueRef);
        anim.SetBool("mouth_is_full", true);
        go.SetActive(false);
    }

    private void CheckForEnemyAndAdd()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(tongueRef.position, detectionRad);
        foreach(var col in colls)
        {
            if (col.gameObject.tag.Equals("Enemy"))
            {
                col.transform.SetParent(tongueRef);
                col.transform.localPosition = Vector3.zero;
                col.GetComponent<EnemyBehaviour>().targeted = true;
                hasTarget = true;
                break;
            }
        }
    }

    private void UpdateTongueBody(Vector3 start, Vector3 end)
    {
        tongueBody.SetPosition(0, new Vector3(start.x, start.y, 1));
        tongueBody.SetPosition(1, new Vector3(end.x, end.y, 1));
    }
}
