using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public float flashingLength = 0.1f;
    private float flashingCounter;
    public Renderer playerRenderer;
    private bool isRespawning;
    public Transform RespawnPoint1;

    private int currentHealth;
    

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (flashingCounter > 0)
        {
            flashingCounter -= Time.deltaTime;
            if (flashingCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashingCounter = flashingLength;
            }
        }

        if (currentHealth <= 0 && !isRespawning)
        {
            isRespawning = true;
            flashingCounter = flashingLength;
            playerRenderer.enabled = false;
            Respawn();
        }
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isRespawning)
        {
            isRespawning = true;
            flashingCounter = flashingLength;
            playerRenderer.enabled = false;
            Respawn();
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Respawn()
    { 
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.transform.position = RespawnPoint1.position;
        currentHealth = maxHealth;
        isRespawning = false;
        Debug.Log("Respawned");
    }
}
