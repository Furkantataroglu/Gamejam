using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPowers : MonoBehaviour
{
    public ColorChanges cc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cc.ColorPow==1)
        {
            //hýzlý
        }
        else if (cc.ColorPow == 2)
        {
            //zýplama
        }
        else if (cc.ColorPow == 3)
        {
            //fýrlatma
        }
        else if (cc.ColorPow == 4)
        {
            //empty
        }
        else if (cc.ColorPow == 5)
        {
            //empty
        }
    }
}
