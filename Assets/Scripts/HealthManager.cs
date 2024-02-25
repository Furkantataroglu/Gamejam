using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private GameObject player;
    public Transform respawn1;
    public int maxHealth;
    public Renderer playerRenderer;
    public int currentHealth;
    public float flashingCounter;
     public float flashingLength = 0.3f;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
       Debug.Log(player.transform.position);
       if(currentHealth<=0){
        if (flashingCounter <=0 )
            {
                PlayerInput playerInput = GetComponent<PlayerInput>();
        player.transform.position = respawn1.transform.position; 
                Respawn();
            }
            flashingCounter -= Time.deltaTime;
           
       }

     
    }

    public void HurtPlayer(int damage)
    {
        flashingCounter = flashingLength;
        currentHealth -= damage;
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
 
        flashingCounter=flashingLength;
          
        currentHealth = maxHealth; 
        
    }

}
