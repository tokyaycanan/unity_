using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cams : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera cam5;

    public InputField gen;
    public InputField en;
    // Start is called before the first frame update
    public void switchcam(int x)
    {
        float c;
        float b = float.Parse(en.text);
        float a = float.Parse(gen.text);
        if (a > b)
        {
            c = a;
            a = b;
            b = c;

        }
        deactivateall();
        if (x == 1)
        {
            cam1.transform.localPosition = new Vector3((a*10)/-2, 2.2f, b*(-3));
            cam1.enabled = true;
        }
        else if (x == 2)
        {

            cam2.transform.localPosition = new Vector3((a * 10) /-2, 2.2f, b*(6.4f));
            cam2.enabled = true;
        }
        else if (x == 3)
        {


            cam3.transform.localPosition = new Vector3((a * -10), 2.2f, 10);
            cam3.enabled = true;
        }
        else if (x == 4)
        {

            cam4.enabled = true;
        }
        else
        {

            cam5.enabled = true;
        }

    }

    public void deactivateall()
    {
        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;
        cam5.enabled = false;
    }
}
