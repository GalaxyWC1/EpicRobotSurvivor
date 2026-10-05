using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Stats))]
public class SpawnHitbox : MonoBehaviour
{
    
    public LayerMask attackLayer;

    private TopDownMovement tdm;
    private Stats stats;

    private float lastAttack;
    private float lastField;
    private Animator anim;
    [SerializeField] private GameObject fieldObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tdm = GetComponent<TopDownMovement>();
        stats = GetComponent<Stats>();
        anim = GetComponent<Animator>();
        lastAttack = Time.realtimeSinceStartup;
        lastField = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.realtimeSinceStartup - lastField) >= stats.fieldInterval && stats.currentHealth > 0 && Time.timeScale > 0 && stats.hasField == true)
        {
            lastField = Time.realtimeSinceStartup;
            GameObject newField = Instantiate(fieldObject);
            newField.GetComponent<fieldProjectile>().stats = stats;
            newField.transform.position = transform.position;
            newField.transform.parent = transform;
        }
        if ((Time.realtimeSinceStartup - lastAttack) >= stats.attackTimer && stats.currentHealth > 0 && Time.timeScale > 0)
        {
            lastAttack = Time.realtimeSinceStartup;
            anim.SetTrigger("Attacking");
        }
    }

    private void Damage(RaycastHit2D hit)
    {
        //Debug.Log("hit");
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

            hits = Physics2D.BoxCastAll(transform.position + (Vector3)stats.meleePos, stats.meleeSize, 0, Vector2.zero, 0, attackLayer);
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
            hits = Physics2D.BoxCastAll(transform.position - (Vector3)stats.meleePos, stats.meleeSize, 0, Vector2.zero, 0, attackLayer);
            if (hits != null)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    Damage(hits[i]);
                }
            }
        }

    }
}
