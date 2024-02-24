using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorPowers : MonoBehaviour
{
    private int sayac = 0;
    #region PowVars
    [SerializeField]
    public float Defrun = 5f;
    [SerializeField]
    public float Highrun = 20f;
    [SerializeField]
    public float Defjump = 2f;
    [SerializeField]
    public float Highjump = 4f;
    #endregion

    [SerializeField]
    public int onay;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (ColorChanges.Intante.color == 1)
       {
             PlayerController.Intante2._playerSpeed = Highrun;
            if (sayac == 60)
            {
                sayac = 0;
                ColorChanges.Intante.color = 6;
            }
            else
                sayac++;
       }
       else
       {
             PlayerController.Intante2._playerSpeed = Defrun;
       }
       if (ColorChanges.Intante.color == 2)
       {
            PlayerController.Intante2._jumpHeight = Highjump;
       }
       else
       {
            PlayerController.Intante2._jumpHeight = Defjump;
       }

    }
}
