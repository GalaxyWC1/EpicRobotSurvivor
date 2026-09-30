using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Stats))]
public class SpawnHitbox : MonoBehaviour
{
    
    public LayerMask attackLayer;

    public Vector2 meleeSize;
    public Vector2 meleePos;

    private TopDownMovement tdm;
    private Stats stats;

    private float lastAttack;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tdm = GetComponent<TopDownMovement>();
        stats = GetComponent<Stats>();
        lastAttack = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.realtimeSinceStartup - lastAttack) >= stats.attackTimer)
        {
            lastAttack = Time.realtimeSinceStartup;
            PlayerAttack();
        }
    }

    private void Damage(RaycastHit2D hit)
    {
        Debug.Log("hit");
        Stats enemyStats = hit.collider.gameObject.GetComponent<Stats>();
        enemyStats.currentHealth -= stats.damage;
        if(enemyStats.currentHealth <= 0)
        {
            stats.xp += enemyStats.xp;
            stats.score += enemyStats.score;
        }
    }

    public void PlayerAttack()
    {
        if (tdm.lookDirection.x > 0)
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position + (Vector3)meleePos, meleeSize, 0, Vector2.zero, 0, attackLayer);
            if (hit)
            {
                Damage(hit);
            }

        }
        else if (tdm.lookDirection.x < 0)
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position + (Vector3)(Vector2.Scale(meleePos, new Vector2(-1, -1))), meleeSize, 0, Vector2.zero, 0, attackLayer);
            if (hit)
            {
                Damage(hit);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)meleePos, meleeSize);
        Gizmos.DrawWireCube(transform.position + (Vector3)(Vector2.Scale(meleePos, new Vector2(-1, -1))), meleeSize);
    }
}
