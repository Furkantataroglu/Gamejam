using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanges : MonoBehaviour
{
    #region Materials
    public Material YellowM;
    public Material RedM;
    public Material OrengeM;
    public Material GreenM;
    public Material BlueM;
    public Material DefaultM;
    #endregion

    public int ColorPow = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = DefaultM;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<Renderer>().material = YellowM;
            ColorPow = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<Renderer>().material = RedM;
            ColorPow = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<Renderer>().material = OrengeM;
            ColorPow = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GetComponent<Renderer>().material = GreenM;
            ColorPow = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GetComponent<Renderer>().material = BlueM;
            ColorPow = 5;
        }

    }
}
