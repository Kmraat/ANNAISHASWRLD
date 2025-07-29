using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed;
    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.transform.position.x >
            transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX= false;
        }

        direction = (PlayerController.Instance.transform.position -
            transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, 
            direction.y * moveSpeed );
    }
}
