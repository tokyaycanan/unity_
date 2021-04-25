using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nesne : MonoBehaviour
{


    public GameObject ground;

    public void deneme()
    {
        Instantiate(ground, transform.position, transform.rotation);
    }





}
