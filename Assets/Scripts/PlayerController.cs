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
        move = Vector2.ClampMagnitude(move, 1);
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 0.5f, maxScreenBounds.x - 0.5f), 
                                        Mathf.Clamp(transform.position.y, minScreenBounds.y + 0.5f, maxScreenBounds.y - 0.5f), 0);
    }

    void FixedUpdate()
    {
        if (dead)
            return;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        dead = true;
        deathText.SetActive(true);
    }
}
