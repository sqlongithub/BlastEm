using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 move;
    public Rigidbody2D rb;
    public float speed = 1.0f;
    public GameObject deathText;
    private bool dead;

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        transform.position = new Vector2(Mathf.Clamp(rb.position.x, -10.1f, 10.1f), Mathf.Clamp(rb.position.y, -4.5f, 4.5f));
    }

    void FixedUpdate()
    {
        if (dead)
            return;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);  
    }

    private void OnTriggerEnter(Collider other)
    {
        dead = true;
        deathText.SetActive(true);
    }
}
