using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Networking;
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
    public GameObject kitaplik;
    public GameObject chair;
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
    public  void deneme()
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


    
   
    string nesnetag;


    

     IEnumerator veriEkle()
  {
      WWWForm form = new WWWForm();
      form.AddField("unity", "nesneEkle");
      form.AddField("kullaniciAdi", kullaniciAdi.text);
      scale = yeniobje.transform.position;
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