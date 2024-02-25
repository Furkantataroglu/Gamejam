using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanges : MonoBehaviour
{
    public static ColorChanges Intante;
    public ColorChanges()
    { }
    
    public float speedMultiplier = 2f;
    public float jumpForceMultiplier = 2f;
   
    #region Materials
    public Material YellowM;
    public Material RedM;
    public Material OrengeM;
    public Material GreenM;
    public Material BlueM;
    public Material DefaultM;
    #endregion
    public int color = 6;
    private bool ability1Active = false;
    private bool ability2Active = false;
    private bool ability3Active = false;
    private float originalMoveSpeed;
    private float originaljumpForce;

    private void Awake()
    {
        Intante = this;
    }
    // Start is called before the first frame update
    void Start()
    {
          PlayerInput playerInput = GetComponent<PlayerInput>(); // PlayerInput componentini al
          originaljumpForce = playerInput.jumpForce;
          originalMoveSpeed = playerInput.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ability1Active = !ability1Active;
            ability2Active = false;
            if (ability1Active)
            {
                // Enable Ability 1
                IncreaseSpeed(GetComponent<PlayerInput>()); // PlayerInput componentini al);          
                Debug.Log("Ability 1");
            }
            else
            {
                // Disable Ability 1
                DecreaseSpeed(GetComponent<PlayerInput>());
                Debug.Log("Default State");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ability2Active = !ability2Active;
            ability1Active = false;
            if (ability2Active)
            {
                // Enable Ability 2
                IncreaseJumpForce();
               
                Debug.Log("Ability 2");
            }
            else
            {
                // Disable Ability 2
                DecreaseJumpForce();
                Debug.Log("Default State");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ability3Active = !ability3Active;
            if (ability3Active)
            {
                // Enable Ability 3
                WaterWalk.shield = true;
                Debug.Log("Ability 3");
            }
            else
            {
                // Disable Ability 3
                WaterWalk.shield = false;
                Debug.Log("Default State");
            }
        }
    }
     private void IncreaseSpeed(PlayerInput playerInput)
    {
        playerInput.jumpForce = originaljumpForce;
        if (playerInput != null)
        {
            playerInput.moveSpeed *= speedMultiplier; // Hızı çarpanla çarp
            Debug.Log("New Speed: " + playerInput.moveSpeed); // Yeni hızı konsola yazdır
        }
    }
    private void DecreaseSpeed(PlayerInput playerInput)
    {
      

        if (playerInput != null)
        {
            playerInput.moveSpeed /= speedMultiplier; // Hızı çarpanla çarp
            Debug.Log("New Speed: " + playerInput.moveSpeed); // Yeni hızı konsola yazdır
        }
    }
     private void IncreaseJumpForce()
    {
        
        PlayerInput playerInput = GetComponent<PlayerInput>(); // PlayerInput componentini al
        playerInput.moveSpeed = originalMoveSpeed;

        if (playerInput != null)
        {
            playerInput.jumpForce *= jumpForceMultiplier; // Zıplama kuvvetini çarpanla çarp
            Debug.Log("New Jump Force: " + playerInput.jumpForce); // Yeni zıplama kuvvetini konsola yazdır
        }
    }
    private void DecreaseJumpForce()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>(); // PlayerInput componentini al

        if (playerInput != null)
        {
            playerInput.jumpForce /= jumpForceMultiplier; // Zıplama kuvvetini çarpanla çarp
            Debug.Log("New Jump Force: " + playerInput.jumpForce); // Yeni zıplama kuvvetini konsola yazdır
        }
    }

}
