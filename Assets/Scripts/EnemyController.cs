using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 1f;

    private bool dead;
    private Vector2 move;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        dead = true;
    }
}
