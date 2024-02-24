using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanges : MonoBehaviour
{
    public static ColorChanges Intante;
    public ColorChanges()
    { }

    #region Materials
    public Material YellowM;
    public Material RedM;
    public Material OrengeM;
    public Material GreenM;
    public Material BlueM;
    public Material DefaultM;
    #endregion
    public int color = 6;

    private void Awake()
    {
        Intante = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = DefaultM;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)&&PlayerController.Intante2._groundedPlayer)
        {
            GetComponent<Renderer>().material = YellowM;
            color = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)&& color!=1)
        {
            GetComponent<Renderer>().material = RedM;
            color = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<Renderer>().material = OrengeM;
            color = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GetComponent<Renderer>().material = GreenM;
            color=4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GetComponent<Renderer>().material = BlueM;
            color = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) || color==6)
        {
            GetComponent<Renderer>().material = DefaultM;
            color = 6;
        }

    }
}
