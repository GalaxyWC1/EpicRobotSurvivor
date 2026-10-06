using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(Stats))]
public class TopDownMovement : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float currentSpeed = 5f;
    private Vector2 movement;
    private Animator anim;

    public Vector2 lookDirection;

    private Stats stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        anim = GetComponent<Animator>();
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
            SceneManager.LoadScene("Menu");
        }

        if (stats.xp >= stats.maxXp)
        {
            stats.xp -= stats.maxXp;
            UpgradeManager.Instance.RandomizeUpgrades();
            Time.timeScale = 0;
        }

        rb2d.linearVelocity = movement * stats.moveSpeed;
        if (movement.x > 0)
        {
            lookDirection = new Vector2(1, 0);
            anim.SetFloat("Direction", 1);
        }else if (movement.x < 0)
        {
            lookDirection = new Vector2(-1, 0);
            anim.SetFloat("Direction", -1);
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();
    }
}
