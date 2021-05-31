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
    public GameObject koltuk1;
    public GameObject oda;
    public GameObject chair1;
    public GameObject chair4;
    public GameObject chair3;
    public GameObject coffetable;
    public GameObject book;
    public GameObject yatak2;
    public GameObject koltuk;
    public GameObject koltuk2;
    public GameObject koltuk3;
    public GameObject table;
    public GameObject mutfakdolabi;
    public GameObject mutfakdolabi1;
    public GameObject yatak3;
    public GameObject yatak1;
    public GameObject buzdolabi;
    public GameObject buzdolabi1;
    public GameObject coffetable2;
    public GameObject bitki;
    public GameObject vazo;


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

        if (Input.GetKey("right"))
        {
            getTarget.transform.Rotate(Vector3.back * velocidade * Time.deltaTime);

        }

        if (Input.GetKey("left"))
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
            if (getTarget.tag == "koltuk1")
            {
                koltuk1 = getTarget;
                name = koltuk1.ToString();
               

            }
            if (getTarget.tag == "chair1")
            {
                chair1 = getTarget;
                name = chair1.ToString();


            }
            if (getTarget.tag == "chair4")
            {
                chair4 = getTarget;
                name = chair4.ToString();


            }
            if (getTarget.tag == "chair3")
            {
                chair3 = getTarget;
                name = chair3.ToString();


            }
            if (getTarget.tag == "coffetable")
            {
                coffetable = getTarget;
                name = coffetable.ToString();


            }
            if (getTarget.tag == "books")
            {
                book = getTarget;
                name = book.ToString();


            }
            if (getTarget.tag == "yatak2")
            {
                yatak2 = getTarget;
                name = yatak2.ToString();


            }
            if (getTarget.tag == "koltuk")
            {
                koltuk = getTarget;
                name = koltuk.ToString();


            }
            if (getTarget.tag == "koltuk2")
            {
                koltuk2 = getTarget;
                name = koltuk2.ToString();


            }
            if (getTarget.tag == "koltuk3")
            {
                koltuk3 = getTarget;
                name = koltuk3.ToString();


            }
            if (getTarget.tag == "table")
            {
                table = getTarget;
                name = table.ToString();


            }
            if (getTarget.tag == "mutfakdolabý")
            {
                mutfakdolabi = getTarget;
                name = mutfakdolabi.ToString();


            }
            if (getTarget.tag == "mutfakdolabý1")
            {
                mutfakdolabi1 = getTarget;
                name = mutfakdolabi1.ToString();


            }
            if (getTarget.tag == "yatak3")
            {
                yatak3 = getTarget;
                name = yatak3.ToString();


            }
            if (getTarget.tag == "yatak1")
            {
                yatak1 = getTarget;
                name = yatak1.ToString();


            }
            if (getTarget.tag == "buzdolabý")
            {
                buzdolabi = getTarget;
                name = buzdolabi.ToString();


            }
            if (getTarget.tag == "buzdolabý1")
            {
                buzdolabi1 = getTarget;
                name = buzdolabi1.ToString();


            }
            if (getTarget.tag == "coffetable2")
            {
                coffetable2 = getTarget;
                name = coffetable2.ToString();


            }
            if (getTarget.tag == "bitki")
            {
                bitki = getTarget;
                name = bitki.ToString();


            }
            if (getTarget.tag == "vazo")
            {
                vazo = getTarget;
                name = vazo.ToString();


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
        if (GameObject.FindWithTag("koltuk1") != null)
        {
            yeniobje = koltuk1;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("oda") != null)
        {
            yeniobje = oda;
            StartCoroutine(odaEkle());
        }
        if (GameObject.FindWithTag("chair1") != null)
        {
            yeniobje = chair1;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("chair4") != null)
        {
            yeniobje = chair4;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("chair3") != null)
        {
            yeniobje = chair3;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("coffetable") != null)
        {
            yeniobje = coffetable;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("books") != null)
        {
            yeniobje = book;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("yatak2") != null)
        {
            yeniobje = yatak2;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("koltuk") != null)
        {
            yeniobje = koltuk;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("koltuk2") != null)
        {
            yeniobje = koltuk2;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("koltuk3") != null)
        {
            yeniobje = koltuk3;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("table") != null)
        {
            yeniobje = table;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("mutfakdolabý") != null)
        {
            yeniobje = mutfakdolabi;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("mutfakdolabý1") != null)
        {
            yeniobje = mutfakdolabi1;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("yatak3") != null)
        {
            yeniobje = yatak3;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("yatak1") != null)
        {
            yeniobje = yatak1;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("buzdolabý") != null)
        {
            yeniobje = buzdolabi;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("buzdolabý1") != null)
        {
            yeniobje = buzdolabi1;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("coffetable2") != null)
        {
            yeniobje = coffetable2;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("bitki") != null)
        {
            yeniobje = bitki;
            StartCoroutine(veriEkle());
        }
        if (GameObject.FindWithTag("vazo") != null)
        {
            yeniobje = vazo;
            StartCoroutine(veriEkle());
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
    public void _kitaplik()
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
    public void _koltuk1()
    {
        tag = "koltuk1";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("koltuk1"));
       
        if (index != null)
        {
            
            yeniobje = Instantiate(koltuk1, transform);
            StartCoroutine(veriCek());
        }
    }

    public void _chair1()
    {
        tag = "chair1";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("chair1"));

        if (index != null)
        {

            yeniobje = Instantiate(chair1, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _chair4()
    {
        tag = "chair4";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("chair4"));

        if (index != null)
        {

            yeniobje = Instantiate(chair4, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _chair3()
    {
        tag = "chair3";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("chair3"));

        if (index != null)
        {

            yeniobje = Instantiate(chair3, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _coffetable()
    {
        tag = "coffetable";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("coffetable"));

        if (index != null)
        {

            yeniobje = Instantiate(coffetable, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _book()
    {
        tag = "books";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("books"));

        if (index != null)
        {

            yeniobje = Instantiate(book, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _yatak2()
    {
        tag = "yatak2";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("yatak2"));

        if (index != null)
        {

            yeniobje = Instantiate(yatak2, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _koltuk()
    {
        tag = "koltuk";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("koltuk"));

        if (index != null)
        {

            yeniobje = Instantiate(koltuk, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _koltuk2()
    {
        tag = "koltuk2";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("koltuk2"));

        if (index != null)
        {

            yeniobje = Instantiate(koltuk2, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _koltuk3()
    {
        tag = "koltuk3";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("koltuk3"));

        if (index != null)
        {

            yeniobje = Instantiate(koltuk3, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _table()
    {
        tag = "table";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("table"));

        if (index != null)
        {

            yeniobje = Instantiate(table, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _mutfakdolabý()
    {
        tag = "mutfakdolabý";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("mutfakdolabý"));

        if (index != null)
        {

            yeniobje = Instantiate(mutfakdolabi, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _mutfakdolabý1()
    {
        tag = "mutfakdolabý1";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("mutfakdolabý1"));

        if (index != null)
        {

            yeniobje = Instantiate(mutfakdolabi1, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _yatak3()
    {
        tag = "yatak3";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("yatak3"));

        if (index != null)
        {

            yeniobje = Instantiate(yatak3, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _yatak1()
    {
        tag = "yatak1";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("yatak1"));

        if (index != null)
        {

            yeniobje = Instantiate(yatak1, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _buzdolabý()
    {
        tag = "buzdolabý";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("buzdolabý"));

        if (index != null)
        {

            yeniobje = Instantiate(buzdolabi, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _buzdolabý1()
    {
        tag = "buzdolabý1";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("buzdolabý1"));

        if (index != null)
        {

            yeniobje = Instantiate(buzdolabi1, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _coffetable2()
    {
        tag = "coffetable2";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("coffetable2"));

        if (index != null)
        {

            yeniobje = Instantiate(coffetable2, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _bitki()
    {
        tag = "bitki";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("bitki"));

        if (index != null)
        {

            yeniobje = Instantiate(bitki, transform);
            StartCoroutine(veriCek());
        }
    }
    public void _vazo()
    {
        tag = "vazo";
        StartCoroutine(tagCekme());
        string index = Array.Find(tagDizi, e => e.Contains("vazo"));

        if (index != null)
        {

            yeniobje = Instantiate(vazo, transform);
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
       // form.AddField("tasarim", tasarim.text);
        form.AddField("tag", tag);

        WWW data = new WWW("http://localhost/unity_DB/userRegister.php", form);

        yield return data;

       // Debug.Log( "deneme " +data.text);
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
    }


    IEnumerator odaOlustur()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "nesneCekme");
        form.AddField("kullaniciAdi", kullaniciAdi.text);
        //form.AddField("tasarim", tasarim.text);
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
      //  form.AddField("tasarim", tasarim.text);
      
        WWW data = new WWW("http://localhost/unity_DB/userRegister.php", form);

        yield return data;
        tagDizi = data.text.Split(';');

    }
    IEnumerator odaEkle()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "odaEkle");
        form.AddField("kullaniciAdi", kullaniciAdi.text);
        form.AddField("tasarim", tasarim.text);
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
        form.AddField("tasarim", tasarim.text);
        scale = yeniobje.transform.localPosition;
        X = scale.x;
        Y = scale.y;
        Z = scale.z;
        Debug.Log(scale);
        nesneTag = yeniobje.tag;
        konumX = X.ToString();
        konumY = Y.ToString();
        konumZ = Z.ToString();
        if (konumY != "0" )
        {
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


}