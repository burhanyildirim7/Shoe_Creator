using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;
using UnityEngine.AI;

public class ClientAI : MonoBehaviour
{
    [SerializeField] List<GameObject>
        Alan1Reyonlar = new List<GameObject>(),
        Alan2Reyonlar = new List<GameObject>(),
        Alan3Reyonlar = new List<GameObject>(),
        Alan4Reyonlar = new List<GameObject>(),
        Alan5Reyonlar = new List<GameObject>(),
        Alanlar = new List<GameObject>(),
        MusteriReyonlari = new List<GameObject>(),
        SpawnPoints = new List<GameObject>(),
        ClientsList= new List<GameObject>();


    public List<GameObject> tempListe = new List<GameObject>();

    private float ramSayac;
    void Start()
    {

        /*
        ramSayac = 0;
        if (Alanlar[0].gameObject.activeSelf == true)
        {
            for (int m = 0; m < Alan1Reyonlar.Count; m++)
            {
                MusteriReyonlari.Add(Alan1Reyonlar[m]);
            }

        }
        if (Alanlar[1].gameObject.activeSelf == true)
        {
            for (int m = 0; m < Alan2Reyonlar.Count; m++)
            {
                MusteriReyonlari.Add(Alan1Reyonlar[m]);
            }
        }
        if (Alanlar[2].gameObject.activeSelf == true)
        {
            for (int m = 0; m < Alan3Reyonlar.Count; m++)
            {
                MusteriReyonlari.Add(Alan1Reyonlar[m]);
            }
        }
        if (Alanlar[3].gameObject.activeSelf == true)
        {
            for (int m = 0; m < Alan4Reyonlar.Count; m++)
            {
                MusteriReyonlari.Add(Alan1Reyonlar[m]);
            }
        }
        if (Alanlar[4].gameObject.activeSelf == true)
        {
            for (int m = 0; m < Alan5Reyonlar.Count; m++)
            {
                MusteriReyonlari.Add(Alan1Reyonlar[m]);
            }
        }

        //tempListe.Clear();
        for (int i = 0; i < MusteriReyonlari.Count; i++)
        {
            Debug.Log("asdasodjpaofjpadogja : "+ i);
            Debug.Log("for "+ MusteriReyonlari[i].transform.GetChild(1).GetChild(0).childCount);
            for (int m = 2; m < MusteriReyonlari[i].transform.GetChild(1).GetChild(0).childCount; m++)
            {
                Debug.Log("for for:"+MusteriReyonlari[i].transform.GetChild(1).GetChild(0).GetChild(m).gameObject.name);
                Debug.Log("for for:" + MusteriReyonlari[i].transform.GetChild(1).GetChild(0).GetChild(m).childCount);
                if (MusteriReyonlari[i].transform.GetChild(1).GetChild(0).GetChild(m).transform.childCount > 0 )
                {
                    tempListe.Add(MusteriReyonlari[i].gameObject);
                    // tempListe.Add(MusteriReyonlari[i].transform.GetChild(1).GetChild(0).GetChild(m).gameObject);
                    Debug.Log("for for if");
                }

                else
                {
                    Debug.Log("for for else");
                }

            }


        }*/

    }


    void Update()
    {
        /*

        ramSayac += Time.deltaTime;
       if (ramSayac>0.5f)
        {
            ramSayac = 0;
            MusteriReyonlari.Clear();

                if (Alanlar[0].gameObject.activeSelf == true)
                {
                    for (int m = 0; m < Alan1Reyonlar.Count; m++)
                    {
                        MusteriReyonlari.Add(Alan1Reyonlar[m]);
                    }

                }
                if (Alanlar[1].gameObject.activeSelf == true)
                {
                    for (int m = 0; m < Alan2Reyonlar.Count; m++)
                    {
                        MusteriReyonlari.Add(Alan1Reyonlar[m]);
                    }
                }
                if (Alanlar[2].gameObject.activeSelf == true)
                {
                    for (int m = 0; m < Alan3Reyonlar.Count; m++)
                    {
                        MusteriReyonlari.Add(Alan1Reyonlar[m]);
                    }
                }
                if (Alanlar[3].gameObject.activeSelf == true)
                {
                    for (int m = 0; m < Alan4Reyonlar.Count; m++)
                    {
                        MusteriReyonlari.Add(Alan1Reyonlar[m]);
                    }
                }
                if (Alanlar[4].gameObject.activeSelf == true)
                {
                    for (int m = 0; m < Alan5Reyonlar.Count; m++)
                    {
                        MusteriReyonlari.Add(Alan1Reyonlar[m]);
                    }
                }

            tempListe.Clear();
            for (int i = 0; i < MusteriReyonlari.Count; i++)
            {
                
                for (int m = 2; m < MusteriReyonlari[m].transform.GetChild(1).GetChild(0).childCount; m++)
                {
                    if (MusteriReyonlari[i].transform.GetChild(1).GetChild(0).GetChild(m).childCount == 1)
                    {
                        tempListe.Add(MusteriReyonlari[i].transform.GetChild(1).GetChild(0).GetChild(m).gameObject);
                    }

                    else
                    {

                    }

                }


            }
            if (tempListe.Count > 0)
            {
                RastgeleReyonSecim();
            }
        }*/




    }

    private void RastgeleReyonSecim()
    {
        //tempListe
        
        int k = Random.Range(0,tempListe.Count);
        int m= Random.Range(0, ClientsList.Count);
        int n= Random.Range(0, SpawnPoints.Count);
        GameObject newClient = Instantiate(ClientsList[m],SpawnPoints[n].transform.position,Quaternion.identity);
        newClient.transform.parent=SpawnPoints[n].transform;
        //newClient.GetComponent<ClientHareket>().yolPointleri.Clear();
        newClient.GetComponent<ClientHareket>().goPoint = tempListe[k].transform;
        for (int i = 0; i < SpawnPoints[n].transform.childCount; i++)
        {

            //newClient.GetComponent<ClientHareket>().yolPointleri[i] = SpawnPoints[n].transform.GetChild(i).gameObject;
            newClient.SetActive(true);
        }
        
    }



}
