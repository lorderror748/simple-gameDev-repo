using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;   // bullet speed
    public float lifetime = 5f; // safety: destroy if it never hits anything

    private void Start()
    {
        // Destroy after a few seconds in case it never collides
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet forward (in its local "right" direction)
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // You can add filtering here (e.g. only destroy if enemy/wall)
        Destroy(gameObject);
    }
}