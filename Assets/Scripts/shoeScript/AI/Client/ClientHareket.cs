using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;
using UnityEngine.AI;

public class ClientHareket : MonoBehaviour
{

    [SerializeField] private NavMeshAgent _agent;
    private Transform _point;

    [SerializeField] private GameObject _stackNoktasi;

    public bool magazada, sirada, kasada, paraOdendi, geriDondu;
    [SerializeField] GameObject Kapi;

    public bool _kasayaGit;


    [SerializeField] private List<GameObject> _gidilecekAyakkabilar = new List<GameObject>();

    public int _gidecegiYol;

    private ClientAI _aiHareketKontrol;

    private int _gidilecekAyakkabiNumber;

    public GameObject _alinacakAyakkabiObjesi;

    private int _kasaNumber;

    private bool _reyonaGeldi;

    private bool _donuyor;

    private bool _kasaAriyor;

    private void Awake()
    {
        _aiHareketKontrol = GameObject.FindGameObjectWithTag("ClientAI").GetComponent<ClientAI>();
    }
    // Start is called before the first frame update
    void Start()
    {

        magazada = false;
        geriDondu = false;
        paraOdendi = false;
        sirada = false;
        kasada = false;

        _point = _aiHareketKontrol._birinciYol[0].transform;

        /*
        if (_gidecegiYol == 0)
        {
            _point = _aiHareketKontrol._birinciYol[0].transform;
        }
        else if (_gidecegiYol == 1)
        {
            _point = _aiHareketKontrol._ikinciYol[0].transform;
        }
        else if (_gidecegiYol == 2)
        {
            _point = _aiHareketKontrol._ucuncuYol[0].transform;
        }
        else
        {

        }
        */


        AyakkabiYeriEkle();
        AyakkabiDoldur();

    }



    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue == true)
        {
            if (_agent.enabled == true)
            {
                SetDestination(_point);
            }
            else
            {

            }

            if (_kasayaGit == true)
            {

                _point = _aiHareketKontrol.SiraPointleri[0].transform;
                _kasayaGit = false;
            }
            else
            {

            }

            if (_kasaAriyor)
            {
                KasaBul();
            }
            else
            {

            }
        }
        /*
       if (magazada == false)
       {
           _setPoint = transform.parent.transform.GetChild(sayac).transform;
           mesafe = Vector3.Distance(yolPointleri[sayac].transform.position, transform.position);
           if (mesafe < 0.1f)
           {
               sayac++;
           }
           if (sayac == transform.parent.transform.childCount - 1)
           {
               magazada = true;
               KapiAnim.SetBool("open", true);
               mesafe = Vector3.Distance(_setPoint.position, transform.position);

           }
       }
       else
       {
           a++;
           if (a == 1)
           {
               KapiAnim.SetBool("open", false);
               KapiAnim.SetBool("close", true);
           }
           _setPoint = goPoint;
           mesafe = Vector3.Distance(_setPoint.position, transform.position);
           if (mesafe < 0.1f)
           {
               sirada = true;
               //burada reyondaki ayakkabıyı alacak.
           }
       }
       if (sirada)
       {
           _setPoint = SiraPointleri[siraSayac].transform;
           mesafe = Vector3.Distance(_setPoint.position, transform.position);
           if (SiraPointleri[siraSayac].transform.GetComponent<siraDoluluk>().doluMu == false)
           {
               if (SiraPointleri[siraSayac + 1].transform.GetComponent<siraDoluluk>().doluMu == false)
               {
                   siraSayac++;
                   if (siraSayac == SiraPointleri.Count - 1)
                   {
                       kasada = true;
                       sirada = false;
                   }
               }
               else
               {
                   _setPoint = SiraPointleri[sayac].transform;
               }

           }
       }
       if (kasada)
       {
           if (KasaPointleri[0].transform.GetComponent<siraDoluluk>().doluMu == true)
           {
               if (KasaPointleri[1].transform.GetComponent<siraDoluluk>().doluMu == false)
               {

                   _setPoint = KasaPointleri[1].transform;
                   mesafe = Vector3.Distance(_setPoint.position, transform.position);
                   if (mesafe < 0.1)
                   {
                       //kasaya ayakkabıyı bırakacak
                       //parayı bırakacak
                       //posetini alacak
                   }

                   if (true)
                   {
                       paraOdendi = true;
                       kasada = false;
                   }
               }


           }
           else
           {
               _setPoint = KasaPointleri[0].transform;
               mesafe = Vector3.Distance(_setPoint.position, transform.position);
               if (mesafe < 0.1)
               {
                   //kasaya ayakkabıyı bırakacak
                   //parayı bırakacak
                   //posetini alacak
               }
               if (true)
               {
                   paraOdendi = true;
                   kasada = false;
               }

           }
       }
       if (paraOdendi)
       {
           _setPoint = yolPointleri[sayac].transform;
           mesafe = Vector3.Distance(yolPointleri[sayac].transform.position, transform.position);
           if (mesafe < 0.1f)
           {
               sayac--;
           }
           if (sayac == 0)
           {
               magazada = true;

               mesafe = Vector3.Distance(_setPoint.position, transform.position);

           }

       }
       float kapiMesafe = 0;
       kapiMesafe = Vector3.Distance(Kapi.transform.position, transform.position);
       if (kapiMesafe < 0.2f)
       {
           KapiAnim.SetBool("close", false);
           KapiAnim.SetBool("open", true);
       }
        */
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == _aiHareketKontrol._birinciYol[0])
        {
            if (_donuyor)
            {
                _point = _aiHareketKontrol._birinciYol[5].transform;
            }
            else
            {
                _point = _aiHareketKontrol._birinciYol[1].transform;
            }

        }
        else if (other.gameObject == _aiHareketKontrol._birinciYol[1])
        {
            if (_donuyor)
            {
                _point = _aiHareketKontrol._birinciYol[0].transform;
            }
            else
            {
                _point = _aiHareketKontrol._birinciYol[2].transform;
            }

        }
        else if (other.gameObject == _aiHareketKontrol._birinciYol[2])
        {
            if (_donuyor)
            {
                _point = _aiHareketKontrol._birinciYol[1].transform;
            }
            else
            {
                _point = _aiHareketKontrol._birinciYol[3].transform;
            }

        }
        else if (other.gameObject == _aiHareketKontrol._birinciYol[3])
        {
            if (_donuyor)
            {
                _point = _aiHareketKontrol._birinciYol[2].transform;
            }
            else
            {
                _point = _aiHareketKontrol._birinciYol[4].transform;
            }

        }
        else if (other.gameObject == _aiHareketKontrol._birinciYol[4])
        {
            if (_donuyor)
            {
                _point = _aiHareketKontrol._birinciYol[3].transform;
            }
            else
            {
                _point = _gidilecekAyakkabilar[_gidilecekAyakkabiNumber].transform.parent.transform.parent.transform.GetChild(0).gameObject.transform;
            }

        }
        else if (other.gameObject == _gidilecekAyakkabilar[_gidilecekAyakkabiNumber].transform.parent.transform.parent.transform.GetChild(0).gameObject)
        {
            _kasaAriyor = true;
            KasaBul();


        }
        else if (other.gameObject == _aiHareketKontrol.SiraPointleri[0])
        {
            _point = _aiHareketKontrol.KasaPointleri[_kasaNumber].transform;
        }
        else if (other.gameObject == _aiHareketKontrol.KasaPointleri[_kasaNumber])
        {
            StartCoroutine(Kasadayiz());
        }
        else if (other.gameObject == _aiHareketKontrol._birinciYol[5])
        {
            Destroy(gameObject);
        }
        else
        {

        }


    }

    private IEnumerator Kasadayiz()
    {
        gameObject.transform.DORotate(new Vector3(0, 45, 0), 1f);

        yield return new WaitForSeconds(2f);


        _alinacakAyakkabiObjesi.transform.DOJump(_aiHareketKontrol.KasaPointleri[_kasaNumber].GetComponent<KasaScript>()._gidilecekKasaKonumlari[0].transform.position, 3f, 1, 0.5f);// ELINDEN KASANIN SAGINA GIDIYOR

        //yield return new WaitForSeconds(1f);

        //_alinacakAyakkabiObjesi.transform.DOJump(_aiHareketKontrol.KasaPointleri[_kasaNumber].GetComponent<KasaScript>()._gidilecekKasaKonumlari[1].transform.position, 3f, 1, 0.5f);

        yield return new WaitForSeconds(0.5f);

        Kolile();

        yield return new WaitForSeconds(0.5f);

        _alinacakAyakkabiObjesi.transform.DOJump(_aiHareketKontrol.KasaPointleri[_kasaNumber].GetComponent<KasaScript>()._gidilecekKasaKonumlari[2].transform.position, 3f, 1, 0.5f);//KASANIN SAGINDAN SOLUNA GECIYOR

        yield return new WaitForSeconds(1f);

        _alinacakAyakkabiObjesi.transform.DOLocalJump(Vector3.zero, 3f, 1, 0.5f);//KOLI SEKLINDE ELINE GELIYOR
        _alinacakAyakkabiObjesi.transform.DORotate(new Vector3(0, 45, 0), 0.5f);

        yield return new WaitForSeconds(1f);

        _point = _aiHareketKontrol._birinciYol[4].transform;
        _aiHareketKontrol.KasaPointleri[_kasaNumber].gameObject.GetComponent<siraDoluluk>().doluMu = false;
        _donuyor = true;
    }

    private void Kolile()
    {
        _alinacakAyakkabiObjesi.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        _alinacakAyakkabiObjesi.gameObject.transform.GetChild(2).gameObject.SetActive(true);

    }

    private void AyakkabiYeriEkle()
    {
        for (int i = 0; i < _aiHareketKontrol.tempStackReyonListe.Count; i++)
        {
            if (_aiHareketKontrol.tempStackReyonListe[i].gameObject.transform.childCount > 0)
            {
                //_gidilecekAyakkabilar.Add(_aiHareketKontrol.tempStackReyonListe[i].gameObject);

                if (_aiHareketKontrol.tempStackReyonListe[i].gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.tag == "Bos")
                {
                    _gidilecekAyakkabilar.Add(_aiHareketKontrol.tempStackReyonListe[i].gameObject.transform.GetChild(0).gameObject);
                }
                else
                {

                }





            }
            else
            {

            }

        }
    }

    private void KasaBul()// IFE GIRDIGINDE AYAKKABI ALIYOR
    {
        for (int i = 0; i < _aiHareketKontrol.KasaPointleri.Count; i++)
        {


            if (_aiHareketKontrol.KasaPointleri[i].gameObject.activeSelf)
            {
                //_gidilecekAyakkabilar.Add(_aiHareketKontrol.tempStackReyonListe[i].gameObject);
                if (_kasaAriyor)
                {
                    if (_aiHareketKontrol.KasaPointleri[i].gameObject.GetComponent<siraDoluluk>().doluMu == false)
                    {
                        _aiHareketKontrol.KasaPointleri[i].gameObject.GetComponent<siraDoluluk>().doluMu = true;
                        _alinacakAyakkabiObjesi.transform.parent.transform.parent.transform.GetChild(0).gameObject.GetComponent<MakineGirisStackAlanlariKontrol>().AyakkabiCek(_alinacakAyakkabiObjesi, _stackNoktasi);//TAM OLARAK BURADA
                        _kasaNumber = i;
                        _kasayaGit = true;
                        _kasaAriyor = false;
                        break;
                    }
                    else
                    {

                    }
                }
                else
                {

                }


            }
            else
            {

            }

        }
    }

    private void AyakkabiDoldur()
    {

        int k = 0;
        k = Random.Range(0, _gidilecekAyakkabilar.Count);


        _gidilecekAyakkabilar[k].gameObject.transform.GetChild(1).gameObject.tag = "Dolu";
        _gidilecekAyakkabiNumber = k;
        _alinacakAyakkabiObjesi = _gidilecekAyakkabilar[k].gameObject;


    }


    private void yerBulma()
    {


    }
    private void SetDestination(Transform point)
    {
        _agent.SetDestination(point.position);
    }
}
