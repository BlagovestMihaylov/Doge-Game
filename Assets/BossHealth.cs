using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private float health = 500;

    public float currentHealth { get; private set; }
	public GameObject deathEffect;

    public Text text;
	//public bool isInvulnerable = false;

    private void Awake() {
        currentHealth = health;
    }
    private void Update() {
        text.text = "HP: " + currentHealth;
    }
	public void TakeDamage(int damage)
	{

		currentHealth -= damage;


		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
