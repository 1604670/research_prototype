using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpDown : Enemy {

    [Header("Follow Player")]
    public float followSpeed = 0.02f;
    private GameObject player;
    bool chasing = false, goback = false;
    public float chaseStartDistance = 5.0f ,maxChaseDistance = 10f;
    

    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void movement()
    {
        float distFromPlayer = Vector2.Distance(center, player.transform.position);
        float distFromCenter = Vector2.Distance(center, transform.position);

        if (distFromPlayer < chaseStartDistance)
            chasing = true;

        if (chasing)
        {
            transform.position += (player.transform.position - transform.position).normalized * followSpeed;
            if (distFromPlayer > maxChaseDistance)
            {
                chasing = false;
                goback = true;
            }

        }
        else if (goback)
        {
            transform.position += (center - transform.position).normalized * followSpeed;
            if (distFromCenter<0.01f)
            {
                chasing = false;
                goback = false;
            }
        }
        else
        {
            base.movement();
        }

    }



}
