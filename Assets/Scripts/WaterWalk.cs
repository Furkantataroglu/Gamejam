using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WaterWalk : MonoBehaviour
{
    
    [SerializeField]
    public static bool shield = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shield)
        {
            GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
