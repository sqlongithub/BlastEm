using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 1f;

    private bool dead;
    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = player.transform.position - transform.position;
        move.Normalize();
    }

    void FixedUpdate()
    {
        if (dead)
            return;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime * 4);
    }

    private void OnTriggerEnter(Collider other)
    {
        dead = true;
    }
}
