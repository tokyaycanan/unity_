using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GirisPanel : MonoBehaviour
{
    public TMP_InputField kullaniciAdi, sifre;
    [Header("Deneme Kullanıcı")]
    public string isim = "selim";
    public string pass = "123";

    PanelKontrol pK_Script;
    SahneGecis sahneGecis;

    // Start is called before the first frame update
    void Start()
    {
        pK_Script = GetComponent<PanelKontrol>();
        sahneGecis = GameObject.Find("SahneManager").GetComponent<SahneGecis>();
    }

    public void girisYap_B()
    {
        if (kullaniciAdi.text.Equals("") || sifre.text.Equals(""))
        {
            StartCoroutine(pK_Script.hataPanel("Boş BIRAKMAYINIZ!"));
        }
        else
        {
            //veritabanı

             StartCoroutine(girisYap());
            StartCoroutine(tablo());

        }
    }

     IEnumerator girisYap()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "girisYapma");
        form.AddField("kullaniciAdi", kullaniciAdi.text); //selim
        form.AddField("sifre", sifre.text);



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
                if(www.downloadHandler.text.Contains("Giriş başarılı."))
                {
                    sahneGecis.sahneyiDegistir(1);
                }else
                    StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));
            }
        }
    }

    IEnumerator tablo()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "olusturma");
        form.AddField("kullaniciAdi", kullaniciAdi.text); //selim


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
                StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));
            }
        }
    }

}
