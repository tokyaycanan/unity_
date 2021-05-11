using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro; //TextMeshPro İçin
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;//UI objeleri için

public class KayitOl : MonoBehaviour
{
    public TMP_InputField kullaniciAdi_k, sifre_k, sifret_k;
    PanelKontrol pK_Script;


    // Start is called before the first frame update
    void Start()
    {
        pK_Script = GetComponent<PanelKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void uyeligiOlustur_B()
    {
        if (kullaniciAdi_k.text.Equals("") || sifre_k.text.Equals("") || sifret_k.text.Equals(""))
        {
            StartCoroutine(pK_Script.hataPanel("Boş BIRAKMAYINIZ!"));

        }
        else
        {
            if (sifre_k.text.Equals(sifret_k.text))
            {
               Debug.Log("Veritabanı Bağlantısı");
                    StartCoroutine(kayitOl());
            }
            else
            {
                StartCoroutine(pK_Script.hataPanel("Şifreler Eşleşmiyor!"));
            }
        }
    }


    IEnumerator kayitOl()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "kayitOlma");
        form.AddField("kullaniciAdi", kullaniciAdi_k.text); //selim
        form.AddField("sifre", sifre_k.text);

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
