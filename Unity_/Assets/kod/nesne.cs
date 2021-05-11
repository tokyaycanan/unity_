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
    public InputField kullaniciAdi, tasarim;
  

    public GameObject ground;
    List<string> list = new List<string>();
    string nesnetag;
    Vector3 scale;
    string nesneTag, konumX, konumY, konumZ;
    float X, Y, Z;


    public void deneme()
    {
        Instantiate(ground, transform.position, transform.rotation);
        nesnetag = ground.ToString();
        list.Add(nesnetag);
        Debug.Log(list[0]);

    }

    public void kayit()
    {
        StartCoroutine(veriEkle());
    }

    IEnumerator veriEkle()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "nesneEkle");
        form.AddField("kullaniciAdi", kullaniciAdi.text);
        form.AddField("tasarim", tasarim.text);
        for (int i = 0; i < list.Count; i++)
        {
            scale = GameObject.FindGameObjectWithTag(list[i]).transform.position;
            X = scale.x;
            Y = scale.y;
            Z = scale.z;
            Debug.Log(scale);
            nesneTag = list[i];
            konumX = X.ToString();
            konumY = Y.ToString();
            konumZ = Z.ToString();
        }
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
