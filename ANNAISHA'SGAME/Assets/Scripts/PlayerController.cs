using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;
    public Vector3 playerMoveDirection;
    public float playerMaxHealth;
    public float playerHealth;

    private bool isImmune;
    [SerializeField] private float immunityDuration;
    [SerializeField] private float immunityTimer;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

     void Start()
    {
        playerHealth = playerMaxHealth;
        UIController.Instance.UpdateHealthSlider();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoveDirection = new Vector3(inputX, inputY).normalized;

        animator.SetFloat("moveX", inputX);
        animator.SetFloat("moveY", inputY);

        if (playerMoveDirection == Vector3.zero)
        {
            animator.SetBool("moving", false);
        }
        else
        {
            animator.SetBool("moving", true);
        }

        if (immunityTimer > 0)
        {
            immunityTimer -= Time.deltaTime;
        } else
        {
            isImmune = false;
        }
    }

         void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(playerMoveDirection.x *
                moveSpeed, playerMoveDirection.y * moveSpeed);
        }

    public void TakeDamage(float damage)
    {
        if (!isImmune)
        {
            isImmune = true;
            immunityTimer = immunityDuration;
            playerHealth -= damage;
            UIController.Instance.UpdateHealthSlider();
            if (playerHealth <= 0)
            {
                gameObject.SetActive(false);
                GameManager.Instance.GameOver();
            }
        }
    }
    
}

