using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Text;
using UnityEngine.Networking;
using TMPro; //TextMeshPro İçin

public class oyun : MonoBehaviour
{
    public GameObject ground;
  
    public InputField gen;
    public InputField en;
    Vector3 scale;
    string nesneTag, konumX, konumY, konumZ;
    float X, Y, Z;

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
    public void kayit()
    {
        StartCoroutine(veriEkle());
    }

    IEnumerator veriEkle()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "nesneEkle");
        scale = GameObject.FindGameObjectWithTag("kitaplik").transform.position;
        X = scale.x;
        Y = scale.y;
        Z = scale.z;
        Debug.Log(scale);
        nesneTag = "kitaplik";
        konumX = X.ToString();
        konumY = Y.ToString();
        konumZ = Z.ToString();
       
        form.AddField("nesneTag", nesneTag);
        form.AddField("konumX", konumX);
        form.AddField("konumY", konumY);
        form.AddField("konumZ", konumZ);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unity_DB/userRegister.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Sorgu Sonucu:" + www.downloadHandler.text);
             
            }
        }

    }

    
}