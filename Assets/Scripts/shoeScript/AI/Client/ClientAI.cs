using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;
using UnityEngine.AI;

public class ClientAI : MonoBehaviour
{
    [SerializeField]
    List<GameObject>

        SpawnPoints = new List<GameObject>(),
        ClientsList = new List<GameObject>();


    public List<GameObject> _birinciYol = new List<GameObject>();
    public List<GameObject> _ikinciYol = new List<GameObject>();
    public List<GameObject> _ucuncuYol = new List<GameObject>();
    public List<GameObject> tempStackReyonListe = new List<GameObject>();

    [SerializeField] private float _spawnHizi;

    public List<GameObject>
        SiraPointleri = new List<GameObject>(),
        KasaPointleri = new List<GameObject>();

    private float ramSayac;

    private float _timer;
    void Start()
    {


    }

    void Update()
    {

        _timer += Time.deltaTime;

        if (_timer > _spawnHizi)
        {

            SezlongKontrolEt();

            //YuzmeAlaniKontrolEt();

            _timer = 0;


        }
        else
        {

        }

    }

    private void SpawnFunc()
    {
        int deger = Random.Range(0, ClientsList.Count);
        int nokta = Random.Range(0, SpawnPoints.Count);
        GameObject client = Instantiate(ClientsList[deger], SpawnPoints[0].transform.position, Quaternion.identity);
        client.GetComponent<ClientHareket>()._gidecegiYol = 0;
        //client.transform.parent = _clientParent.transform;

    }

    private void SezlongKontrolEt()
    {



        for (int i = 0; i < tempStackReyonListe.Count; i++)
        {


            if (tempStackReyonListe[i].gameObject.transform.childCount > 0)
            {
                //_gidilecekAyakkabilar.Add(_aiHareketKontrol.tempStackReyonListe[i].gameObject);

                if (tempStackReyonListe[i].gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.tag == "Bos")
                {
                    _timer = 0;
                    // Debug.Log(_konumNumber);
                    SpawnFunc();


                    break;
                }
                else
                {

                }
                Debug.Log("GIRDIIIII");




            }
            else
            {

            }

        }




    }




}
