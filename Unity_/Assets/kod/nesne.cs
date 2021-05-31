using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Text;
using UnityEngine.Networking;
using TMPro; //TextMeshPro Ýçin
public class nesne : MonoBehaviour
{
  

    public GameObject ground;

    public GameObject yeniobje;

    public void esyaOlustur()
    {
        yeniobje= Instantiate(ground, transform);
        

    }

   


}
