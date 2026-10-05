using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Stats : MonoBehaviour
{
    [Range(1,1000)] public float maxHealth;
    public float currentHealth;
    [Range(100, 10000)] public float maxMana;
    public float currentMana;
    public int score;

    public float xp;
    [Range(100, 10000)] public float maxXp;

    [Header("Movement")]

    public float moveSpeed;

    [Header("Spear")]

    public float damage;
    public Vector2 meleeSize;
    public Vector2 meleePos;

    [Header("Field")]
    public bool hasField;
    public float fieldDamage;
    public float fieldInterval;

    public Vector2 fieldSize;
    public Vector2 fieldSize2;
    public Vector2 fieldSize3;

    [Header("Miscellaneaous")]

    public float attackTimer;

    public bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)meleePos, meleeSize);
        Gizmos.DrawWireCube(transform.position - (Vector3)meleePos, meleeSize);
        Gizmos.DrawWireCube(transform.position, fieldSize);
        Gizmos.DrawWireCube(transform.position, fieldSize2);
        Gizmos.DrawWireCube(transform.position, fieldSize3);
    }
}
