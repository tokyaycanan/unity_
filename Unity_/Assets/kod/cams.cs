using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class cams : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;

    public InputField gen;
    public InputField en;

    public GameObject getTarget;
    public GameObject kitaplik;
    public GameObject chair;
    public GameObject oda;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;
    int velocidade = 30;
    string name;

    List<string> list = new List<string>();
    string nesneTag, konumX, konumY, konumZ;
    float X, Y, Z;
    Vector3 scale;
    public GameObject yeniobje;
    string tag;

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
            cam1.transform.localPosition = new Vector3((a * -10)+5, 2.2f, b );
            cam1.enabled = true;
            cam1 = cam1;
        }
        else if (x == 2)
        {

            cam2.transform.localPosition = new Vector3((a * -9), 2.2f, b * 12);
            cam2.enabled = true;
            cam1 = cam2;
        }
        else if (x == 3)
        {


            cam3.transform.localPosition = new Vector3((a * 7), 2.2f, 0.67f);
            cam3.enabled = true;

            cam1 = cam3;
        }
        else if (x == 4)
        {

            cam4.transform.localPosition = new Vector3((a * 9), 2.2f, (b*12));
            cam4.enabled = true;

            cam1 = cam4;
        }
 

    }

    public void deactivateall()
    {
        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;
    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.S))
        {
            getTarget.transform.Rotate(Vector3.back * velocidade * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {
            getTarget.transform.Rotate(-Vector3.back * velocidade * Time.deltaTime);

        }

        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            getTarget = ReturnClickedObject(out hitInfo);
            if (getTarget != null)
            {
                //transform.Rotate(new Vector3(0, 90, 0));
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
            Debug.Log("x " + getTarget.transform.localPosition);
            if (getTarget.tag=="kitaplik")
            {

                kitaplik = getTarget;
                name = kitaplik.ToString();
               

            }
            if (getTarget.tag == "chair")
            {
                chair = getTarget;
                name = chair.ToString();
               

            }

           
          /*  Debug.Log("position : " + kitaplik.transform.position);
            if (GameObject.FindWithTag("chair")!=null)
            {
                Debug.Log("position : " + chair.transform.position);
            }
            */
           

        }


    }

    public  void kayit()
    {

        if (GameObject.FindWithTag("kitaplik") != null)
        {
            yeniobje = kitaplik;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("chair") != null)
        {
            yeniobje = chair;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("oda") != null)
        {
            yeniobje = oda;
            StartCoroutine(odaEkle());
        }
    }
    public void odaOlusturD()
    {
        tag = "oda";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("oda"));

        if (index != null)
        {

            yeniobje = Instantiate(oda, transform);
            StartCoroutine(veriCek());
        }
    }
    public void deneme()
    {
        tag = "kitaplik";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("kitaplik"));
        if (index!=null)
        {
            Debug.Log("if içi");
            
            yeniobje = Instantiate(kitaplik, transform);
            StartCoroutine(veriCek());
        }
    }
    public void deneme1()
    {
        tag = "chair";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("chair"));
       
        if (index != null)
        {
            
            yeniobje = Instantiate(chair, transform);
            StartCoroutine(veriCek());
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



    public InputField kullaniciAdi, tasarim;



    public string[] veriler = new string[4];
    public string[] tagDizi = new string[10];
    string nesnetag;



    IEnumerator veriCek()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "nesneCekme");
        form.AddField("kullaniciAdi", kullaniciAdi.text);
        form.AddField("tag", tag);

        WWW data = new WWW("http://localhost/unity_DB/userRegister.php", form);

        yield return data;

        Debug.Log( "deneme " +data.text);
        veriler = data.text.Split(';');
        nesneTag = veriler[0];
        konumX = veriler[1];
        konumY = veriler[2];
        konumZ = veriler[3];

        X = float.Parse(konumX);
        Y = float.Parse(konumY);
        Z = float.Parse(konumZ);

        scale.x = X;
        scale.y = Y;
        scale.z = Z;


        yeniobje.transform.localPosition = new Vector3(X, Y, Z);
        yeniobje.tag = nesneTag;


        Debug.Log(data.text);
      /*  Debug.Log(X.ToString());
        Debug.Log(Y.ToString());
        Debug.Log(Z.ToString());*/

    }


    IEnumerator odaOlustur()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "nesneCekme");
        form.AddField("kullaniciAdi", kullaniciAdi.text);
        form.AddField("tag", tag);

        WWW data = new WWW("http://localhost/unity_DB/userRegister.php", form);

        yield return data;

        veriler = data.text.Split(';');
        nesneTag = veriler[0];
        konumX = veriler[1];
        konumY = veriler[2];

        X = float.Parse(konumX);
        Y = float.Parse(konumY);
       

        scale.x = X;
        scale.y = Y;

        yeniobje.transform.localScale = new Vector3(X, 1.0f, Y);
        yeniobje.tag = nesneTag;



    }
   IEnumerator tagCekme()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "tagCekme");
        form.AddField("kullaniciAdi", kullaniciAdi.text);
       // form.AddField("tag", tag);

        WWW data = new WWW("http://localhost/unity_DB/userRegister.php", form);

        yield return data;
        tagDizi = data.text.Split(';');

    


       Debug.Log(tagDizi[0]);
      


    }
    IEnumerator odaEkle()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "odaEkle");
        form.AddField("kullaniciAdi", kullaniciAdi.text);
        form.AddField("konumX", en.text);
        form.AddField("konumY", gen.text);
        nesneTag = yeniobje.tag;
        form.AddField("nesneTag", nesneTag);

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

    IEnumerator veriEkle()
  {
      WWWForm form = new WWWForm();
      form.AddField("unity", "nesneEkle");
      form.AddField("kullaniciAdi", kullaniciAdi.text);
      scale = yeniobje.transform.localPosition;
      X = scale.x;
      Y = scale.y;
      Z = scale.z;
      Debug.Log(scale);
      nesneTag = yeniobje.tag;
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