using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    public GameObject getTarget;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;
    int velocidade = 30;
    string name;

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
            cam1.transform.localPosition = new Vector3((a * 10) / -2, 2.2f, b * (-2));
            cam1.enabled = true;
            cam1 = cam1;
        }
        else if (x == 2)
        {

            cam2.transform.localPosition = new Vector3((a * 10) / -2, 2.2f, b * (5.0f));
            cam2.enabled = true;
            cam1 = cam2;
        }
        else if (x == 3)
        {


            //cam3.transform.localPosition = new Vector3((a * -10), 2.2f, 10);
            cam3.enabled = true;

            cam1 = cam3;
        }
        else if (x == 4)
        {

            cam4.enabled = true;

            cam1 = cam4;
        }
        else
        {

            cam5.enabled = true;

            cam1 = cam5;
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

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            getTarget.transform.Rotate(Vector3.up * velocidade * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {
            getTarget.transform.Rotate(-Vector3.up * velocidade * Time.deltaTime);

        }

        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            getTarget = ReturnClickedObject(out hitInfo);
            if (getTarget != null)
            {
                transform.Rotate(new Vector3(0, 90, 0));
                isMouseDragging = true;
                //Converting world position to screen position.
                positionOfScreen = cam1.WorldToScreenPoint(getTarget.transform.position);
                offsetValue = getTarget.transform.position - cam1.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
            }
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
        }

        //Is mouse Moving
        if (isMouseDragging)
        {
            //tracking mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

            //converting screen position to world position with offset changes.
            Vector3 currentPosition = cam1.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            //It will update target gameobject's current postion.
            getTarget.transform.position = currentPosition;
            name = getTarget.ToString();
            Debug.Log("NAME : " + name);
            Vector3  scale = GameObject.FindGameObjectWithTag("kitaplik").transform.position;
            Vector3 donusum = cam1.ScreenToWorldPoint(scale);
            Debug.Log("position : " +donusum);
        }


    }

    //Method to Return Clicked Object
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = cam1.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

}