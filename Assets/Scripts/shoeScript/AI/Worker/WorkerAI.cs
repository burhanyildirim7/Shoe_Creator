using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;
using UnityEngine.AI;

public class WorkerAI : MonoBehaviour
{   // DEPO - URETİM GOREVLİSİ İÇİN YAZILDI
    [SerializeField] List<GameObject> _ihtiyacNoktalari = new List<GameObject>(),_stacklenebilirObjeler = new List<GameObject>();
    [SerializeField] List<GameObject> _toplamaNoktalari = new List<GameObject>();
    [SerializeField]
    int
        _urunTipi1,
        _urunTipi2,
        _urunTipi3,
        _urunTipi4;

    [SerializeField] private NavMeshAgent _agent;
    public Transform _setPoint;
    [SerializeField] GameObject _spawnPoint;

    private Animator _workerAnim;
    private int _ihtiyacSayac,_onstaysayac;
    private bool _gorevAtandı, _cantaDoluMu;
    private float _cantaSayac;

    // Start is called before the first frame update
    void Start()
    {
        _workerAnim = transform.GetComponent<Animator>(); // run / carryrun / carryidle / pickitem / walking(client için)
        _ihtiyacSayac = 0;
        _onstaysayac = 0;
        _gorevAtandı = false;
        _setPoint = _spawnPoint.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.isContinue == true)//ALLLLLL
        {
            SetDestination(_setPoint);
        }
        _cantaSayac += Time.deltaTime;
        //if (_cantaSayac== transform.GetComponent<WorkerEsyaToplama>()._clientStackAlanlari.Count)
        if (transform.GetComponent<WorkerEsyaToplama>()._clientCantadakilerinSayisiIcinListe.Count==0 && _cantaSayac>1f)
        {
            _cantaDoluMu = false;
        }
        else
        {
            _cantaDoluMu = true;
        }
        Debug.Log("transform.GetComponent<WorkerEsyaToplama>()._clientCantadakilerinSayisiIcinListe.Count:"+ transform.GetComponent<WorkerEsyaToplama>()._clientCantadakilerinSayisiIcinListe.Count);
        Debug.Log("_cantaDoluMu:"+ _cantaDoluMu);
        Debug.Log("_gorevAtandı:"+ _gorevAtandı);


        // IHTIYAC ARAMA VE BULMA-BULDUGU YERE GITME KODU
        if (_gorevAtandı == false)
        {
            if (_cantaDoluMu == false)
            {
                for (int i = 2; i < _ihtiyacNoktalari.Count; i++)
                {
                    if (_ihtiyacNoktalari[i].transform.parent.transform.parent.gameObject.activeSelf && _ihtiyacNoktalari[i].transform.parent.transform.parent.transform.parent.transform.parent.gameObject.activeSelf)
                    {
                        for (int k = 0; k < _ihtiyacNoktalari[i].transform.childCount; k+=2)
                        {
                            if (_ihtiyacNoktalari[i].transform.GetChild(0).transform.GetComponent<MakineGirisStackAlanlariKontrol>()._stacklenecekObjeNumarasi == _urunTipi1)
                            {
                                int _aradeger = 0;
                                for (int m = 0; m < _toplamaNoktalari[_urunTipi1].transform.childCount; m++)
                                {
                                    if (_toplamaNoktalari[_urunTipi1].transform.GetChild(m).childCount == 0)
                                    {
                                        _aradeger++;
                                    }
                                }
                                if (_aradeger == _toplamaNoktalari[_urunTipi1].transform.childCount)
                                {
                                    break;
                                }
                                else
                                {

                                }
                                if (_ihtiyacNoktalari[i].transform.GetChild(k).childCount == 0)
                                {
                                    _ihtiyacSayac++;
                                }
                                else
                                {
                                    break;
                                }

                                if (_ihtiyacSayac == _ihtiyacNoktalari[i].transform.childCount)
                                {
                                    transform.GetComponent<NavMeshAgent>().enabled = true;
                                    _gorevAtandı = true;
                                    _setPoint = _toplamaNoktalari[_urunTipi1].transform;
                                }
                                else
                                {

                                }

                            }
                            else if (_ihtiyacNoktalari[i].transform.GetChild(0).transform.GetComponent<MakineGirisStackAlanlariKontrol>()._stacklenecekObjeNumarasi == _urunTipi2)
                            {
                                int _aradeger = 0;
                                for (int m = 0; m < _toplamaNoktalari[_urunTipi2].transform.childCount; m++)
                                {
                                    if (_toplamaNoktalari[_urunTipi2].transform.GetChild(m).childCount == 0)
                                    {
                                        _aradeger++;
                                    }
                                }
                                if (_aradeger == _toplamaNoktalari[_urunTipi2].transform.childCount)
                                {
                                    break;
                                }
                                else
                                {

                                }
                                if (_ihtiyacNoktalari[i].transform.GetChild(k).childCount == 0)
                                {
                                    _ihtiyacSayac++;
                                }
                                else
                                {
                                    break;
                                }

                                if (_ihtiyacSayac == _ihtiyacNoktalari[i].transform.childCount)
                                {
                                    transform.GetComponent<NavMeshAgent>().enabled = true;
                                    _gorevAtandı = true;
                                    _setPoint = _toplamaNoktalari[_urunTipi2].transform;
                                }
                                else
                                {

                                }

                            }
                            else if (_ihtiyacNoktalari[i].transform.GetChild(0).transform.GetComponent<MakineGirisStackAlanlariKontrol>()._stacklenecekObjeNumarasi == _urunTipi3)
                            {
                                int _aradeger = 0;
                                for (int m = 0; m < _toplamaNoktalari[_urunTipi3].transform.childCount; m++)
                                {
                                    if (_toplamaNoktalari[_urunTipi3].transform.GetChild(m).childCount == 0)
                                    {
                                        _aradeger++;
                                    }
                                }
                                if (_aradeger == _toplamaNoktalari[_urunTipi3].transform.childCount)
                                {
                                    break;
                                }
                                else
                                {

                                }
                                if (_ihtiyacNoktalari[i].transform.GetChild(k).childCount == 0)
                                {
                                    _ihtiyacSayac++;
                                }
                                else
                                {
                                    break;
                                }

                                if (_ihtiyacSayac == _ihtiyacNoktalari[i].transform.childCount)
                                {
                                    transform.GetComponent<NavMeshAgent>().enabled = true;
                                    _gorevAtandı = true;
                                    _setPoint = _toplamaNoktalari[_urunTipi3].transform;
                                }
                                else
                                {

                                }
                            }
                            else if (_ihtiyacNoktalari[i].transform.GetChild(0).transform.GetComponent<MakineGirisStackAlanlariKontrol>()._stacklenecekObjeNumarasi == _urunTipi4)
                            {
                                int _aradeger = 0;
                                for (int m = 0; m < _toplamaNoktalari[_urunTipi4].transform.childCount; m++)
                                {
                                    if (_toplamaNoktalari[_urunTipi4].transform.GetChild(m).childCount == 0)
                                    {
                                        _aradeger++;
                                    }
                                }
                                if (_aradeger == _toplamaNoktalari[_urunTipi4].transform.childCount)
                                {
                                    break;
                                }
                                else
                                {

                                }

                                if (_ihtiyacNoktalari[i].transform.GetChild(k).childCount == 0)
                                {
                                    _ihtiyacSayac++;
                                }
                                else
                                {
                                    break;
                                }

                                if (_ihtiyacSayac == _ihtiyacNoktalari[i].transform.childCount)
                                {
                                    transform.GetComponent<NavMeshAgent>().enabled = true;
                                    _gorevAtandı = true;
                                    _setPoint = _toplamaNoktalari[_urunTipi4].transform;
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
                    
                }
            }
            else
            {
                int _cantadakiUrunTipi = transform.GetComponent<WorkerEsyaToplama>().WorkerAIDoluCantaHedefBulma();

                if (_cantadakiUrunTipi == _urunTipi1)
                {
                    Debug.Log("_cantadakiUrunTipi:"+_cantadakiUrunTipi);
                    for (int i = 0; i < _ihtiyacNoktalari[_cantadakiUrunTipi].transform.childCount; i+=2)
                    {
                        if (_ihtiyacNoktalari[_cantadakiUrunTipi].transform.GetChild(i).childCount == 0)
                        {
                            transform.GetComponent<NavMeshAgent>().enabled = true;
                            _gorevAtandı = true;
                            _setPoint = _ihtiyacNoktalari[_cantadakiUrunTipi].transform;
                        }
                    }
                }
            }

        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StackAlani" && Vector3.Distance(_setPoint.transform.position, transform.position) < 1)
        {

            transform.GetComponent<NavMeshAgent>().enabled = false;

        }
        if (other.tag == "GirisAlani" && Vector3.Distance(_setPoint.transform.position, transform.position) < 1)
        {
            transform.GetComponent<NavMeshAgent>().enabled = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "StackAlani" && Vector3.Distance(_setPoint.transform.position, transform.position) < 1)
        {

            transform.GetComponent<NavMeshAgent>().enabled = true;

        }
        if (other.tag == "GirisAlani" && Vector3.Distance(_setPoint.transform.position, transform.position) < 1)
        {
            transform.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        _onstaysayac += 0;
        if (other.tag == "StackAlani"&& Vector3.Distance(_setPoint.transform.position,transform.position) <1)
        {

            for (int i = 2; i < other.transform.parent.transform.childCount; i++)
            {
                if (other.transform.parent.GetChild(i).childCount==1)
                {
                    other.transform.parent.GetChild(i).transform.DOMove(transform.position,0.2f);

                }
                else
                {

                }
            }

            if (_cantaDoluMu==false)
            {
                _gorevAtandı = false;
            }

        }
        if (other.tag == "GirisAlani" && Vector3.Distance(_setPoint.transform.position, transform.position) < 1)
        {
            if (_cantaDoluMu)
            {
                _gorevAtandı = false;
            }
        }
    }



    private void SetDestination(Transform point)//ALLLLLL
    {
        _agent.SetDestination(point.position);
    }
}
