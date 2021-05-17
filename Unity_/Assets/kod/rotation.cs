using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    int velocidade = 30;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * velocidade * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * velocidade * Time.deltaTime);

        }

    }
}