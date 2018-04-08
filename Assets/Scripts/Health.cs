﻿using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public int MaxHealth = 100;

    public RectTransform healthBar;

    [SyncVar(hook = "OnChangeHealth")]
    private int _currentHealth;

    public void Start()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Debug.Log("Dead!");
        }
    }

    private void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(
            health,
            healthBar.sizeDelta.y);
    }
}
