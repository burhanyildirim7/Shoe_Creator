using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;
using UnityEngine.AI;

public class ClientHareket : MonoBehaviour
{

    [SerializeField] private NavMeshAgent _agent;
    private Transform _setPoint;
    public Transform goPoint;
    public List<GameObject> yolPointleri = new List<GameObject>(),
        SiraPointleri = new List<GameObject>(),
        KasaPointleri = new List<GameObject>();
    private int sayac, siraSayac;
    float mesafe;
    public bool magazada,sirada,kasada,paraOdendi,geriDondu;
    [SerializeField] GameObject Kapi;
    Animator KapiAnim;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        KapiAnim = Kapi.transform.GetComponent<Animator>();
        magazada = false;
        geriDondu = false;
        paraOdendi = false;
        sirada = false;
        kasada = false;
        siraSayac = 0;
        GameObject baslnagicSetPointi = new GameObject();
        baslnagicSetPointi.transform.position = transform.position;
        _setPoint = baslnagicSetPointi.transform;
        sayac = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue == true)
        {
            SetDestination(_setPoint);
        }
        if (magazada==false)
        {
            _setPoint = transform.parent.transform.GetChild(sayac).transform;
            mesafe = Vector3.Distance(yolPointleri[sayac].transform.position, transform.position);
            if (mesafe < 0.1f)
            {
                sayac++;
            }
            if (sayac== transform.parent.transform.childCount-1)
            {
                magazada = true;
                KapiAnim.SetBool("open", true);
                mesafe = Vector3.Distance(_setPoint.position, transform.position);

            }
        }
        else
        {
            a++;
                if (a==1)
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
            if (SiraPointleri[siraSayac].transform.GetComponent<siraDoluluk>().doluMu==false)
            {
                if (SiraPointleri[siraSayac + 1].transform.GetComponent<siraDoluluk>().doluMu == false )
                {
                    siraSayac++;
                    if (siraSayac == SiraPointleri.Count-1)
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
        kapiMesafe = Vector3.Distance(Kapi.transform.position,transform.position);
        if (kapiMesafe<0.2f)
        {
            KapiAnim.SetBool("close", false);
            KapiAnim.SetBool("open", true);
        }
    }



        private void SetDestination(Transform point)
    {
        _agent.SetDestination(point.position);
    }
}
