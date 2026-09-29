using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Stats : MonoBehaviour
{
    [Range(1,1000)] public float maxHealth;
    [HideInInspector] public float currentHealth;
    [Range(100, 10000)] public float maxMana;
    [HideInInspector] public float currentMana;

    public int xp;

    [Header("Attack")]

    public float damage;
    public float defense;

    [Header("Miscellaneaous")]

    public bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }
}
