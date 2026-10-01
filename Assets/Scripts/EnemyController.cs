using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(Stats))]
public class EnemyController : MonoBehaviour
{
    public GameObject Target;
    public LayerMask attackLayer;
    private Rigidbody2D rb2d;
    private float currentSpeed = 5f;
    private Vector2 movement;

    private Stats stats;

    public Vector2 meleeSize;
    public Vector2 meleePos;
    private float lastAttack;
    public Image HealthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        lastAttack = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = stats.currentHealth / stats.maxHealth;

        if(stats.currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        if ((Time.realtimeSinceStartup - lastAttack) >= stats.attackTimer)
        {
            lastAttack = Time.realtimeSinceStartup;
            RaycastHit2D hit = Physics2D.BoxCast(transform.position + (Vector3)meleePos, meleeSize, 0, Vector2.zero, 0, attackLayer);
            if (hit)
            { 
                Stats enemyStats = hit.collider.gameObject.GetComponent<Stats>();
                enemyStats.currentHealth -= stats.damage;
            }
        }

        movement = (Target.transform.position - transform.position);

        rb2d.linearVelocity = movement.normalized * stats.moveSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)meleePos, meleeSize);
    }
}
