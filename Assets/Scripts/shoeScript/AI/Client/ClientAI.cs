using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;
using UnityEngine.AI;

public class ClientAI : MonoBehaviour
{
    [SerializeField] List<GameObject>

        SpawnPoints = new List<GameObject>(),
        ClientsList= new List<GameObject>();

    [SerializeField]public List<GameObject> tempStackReyonListe = new List<GameObject>();

    private float ramSayac;
    void Start()
    {


    }


    private void RastgeleReyonSecim()
    {
        //tempListe
        
        int k = Random.Range(0,tempStackReyonListe.Count);
        int m= Random.Range(0, ClientsList.Count);
        int n= Random.Range(0, SpawnPoints.Count);
        GameObject newClient = Instantiate(ClientsList[m],SpawnPoints[n].transform.position,Quaternion.identity);
        newClient.transform.parent=SpawnPoints[n].transform;
        //newClient.GetComponent<ClientHareket>().yolPointleri.Clear();
        newClient.GetComponent<ClientHareket>().goPoint = tempStackReyonListe[k].transform;
        for (int i = 0; i < SpawnPoints[n].transform.childCount; i++)
        {

            //newClient.GetComponent<ClientHareket>().yolPointleri[i] = SpawnPoints[n].transform.GetChild(i).gameObject;
            newClient.SetActive(true);
        }
        
    }



}
