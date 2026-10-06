using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class fieldProjectile : MonoBehaviour
{
    public Stats stats;
    public LayerMask attackLayer;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        attackLayer = LayerMask.GetMask("Enemy");
    }

    private void Damage(RaycastHit2D hit)
    {
        Debug.Log("hit");
        Stats enemyStats = hit.collider.gameObject.GetComponent<Stats>();
        enemyStats.currentHealth -= stats.fieldDamage;
        if (enemyStats.currentHealth <= 0)
        {
            stats.xp += enemyStats.xp;
            stats.score += enemyStats.score;
        }
    }

    public void Attack(int phase)
    {
        RaycastHit2D[] hits;
        if (phase == 1)
        {
            hits = Physics2D.BoxCastAll(transform.position, Vector3.Scale(stats.fieldSize, new Vector3(stats.fieldScale, stats.fieldScale, stats.fieldScale)), 0, Vector2.zero, 0, attackLayer);
            if (hits != null)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Damage(hits[i]);
                }
            }
        }
        else if (phase == 2)
        {
            hits = Physics2D.BoxCastAll(transform.position, Vector3.Scale(stats.fieldSize2, new Vector3(stats.fieldScale, stats.fieldScale, stats.fieldScale)), 0, Vector2.zero, 0, attackLayer);
            if (hits != null)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Damage(hits[i]);
                }
            }
        }
        else if (phase == 3)
        {
            hits = Physics2D.BoxCastAll(transform.position, Vector3.Scale(stats.fieldSize3, new Vector3(stats.fieldScale, stats.fieldScale, stats.fieldScale)), 0, Vector2.zero, 0, attackLayer);
            if (hits != null)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Damage(hits[i]);
                }
            }
            Destroy(gameObject);
        }
    }
}
