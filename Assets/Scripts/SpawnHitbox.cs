using System.Runtime.CompilerServices;
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
    private Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tdm = GetComponent<TopDownMovement>();
        stats = GetComponent<Stats>();
        anim = GetComponent<Animator>();
        lastAttack = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {

        if ((Time.realtimeSinceStartup - lastAttack) >= stats.attackTimer && stats.currentHealth>0 && Time.timeScale > 0)
        {
            lastAttack = Time.realtimeSinceStartup;
            anim.SetTrigger("Attacking");
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
        RaycastHit2D[] hits;
        if (tdm.lookDirection.x > 0)
        {

            hits = Physics2D.BoxCastAll(transform.position + (Vector3)meleePos, meleeSize, 0, Vector2.zero, 0, attackLayer);
            if(hits != null)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Damage(hits[i]);
                }
            }

        }
        else if (tdm.lookDirection.x < 0)
        {
            hits = Physics2D.BoxCastAll(transform.position - (Vector3)meleePos, meleeSize, 0, Vector2.zero, 0, attackLayer);
            if (hits != null)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Damage(hits[i]);
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)meleePos, meleeSize);
        Gizmos.DrawWireCube(transform.position - (Vector3)meleePos, meleeSize);
    }
}
