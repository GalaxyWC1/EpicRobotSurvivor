using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Stats))]
public class TopDownMovement : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float currentSpeed = 5f;
    private Vector2 movement;

    public Vector2 lookDirection;

    private Stats stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
    }

    private void Start()
    {
        UpgradeManager.Instance.HideUpgradeSelection();
    }
    // Update is called once per frame
    void Update()
    {
        if (stats.currentHealth <= 0)
        {
            Time.timeScale = 0;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        rb2d.linearVelocity = movement * stats.moveSpeed;
        if (movement.x > 0)
        {
            lookDirection = new Vector2(1, 0);
        }else if (movement.x < 0)
        {
            lookDirection = new Vector2(-1, 0);
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();
    }
}
