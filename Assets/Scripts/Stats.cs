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

    [Header("Attack")]

    public float damage;
    public float defense;

    [Header("Miscellaneaous")]

    public float attackTimer;

    public bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }
}
