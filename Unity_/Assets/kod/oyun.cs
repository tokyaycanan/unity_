﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class oyun : MonoBehaviour
{
    public GameObject ground;
    public InputField gen;
    public InputField en;
    Vector3 scale;

        public void x()
    {
        float b = float.Parse(en.text);
        float a = float.Parse(gen.text);
        Debug.Log("Genişlik : " + gen.text + "En : " + en.text);
        if (a < b)
        {
            scale = new Vector3(a, 1.0f, b);
        }
        else
        {

            scale = new Vector3(b, 1.0f, a);
        }
        ground.transform.localScale = scale;
        Instantiate(ground, transform.position, transform.rotation);

    }

    // Update is called once per frame

}
