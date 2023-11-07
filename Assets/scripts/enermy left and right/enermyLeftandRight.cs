using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class enermyLeftandRight : MonoBehaviour
{
    public Transform[] patrolpoints;
    public float moveSpeed;
    public int patrolDestination;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolpoints[0].position) < .2f)
            {
                sr.flipX = true;
                patrolDestination = 1;
            }
        }
        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolpoints[1].position) < .2f)
            {
                sr.flipX = false;
                patrolDestination = 0;
            }
        }
    }

}
