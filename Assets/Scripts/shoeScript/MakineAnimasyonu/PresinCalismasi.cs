using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PresinCalismasi : MonoBehaviour
{
    [SerializeField] bool _islemeMakinesi, _ayakkabiUretimMakinesi,_ikiliIhtiyacVar;
    [SerializeField] bool _presAnimCalis;
    [SerializeField] GameObject _MakineAnimasyonScripti,_presAparati, _presUcu, _presBacaklari, _presBasmaEfect, _renkPuskurtmeEfect;
    [SerializeField] Vector3 _presUcuAltNoktasi, _presUcuUstNoktasi, _presBacaklariMaxScale, _presBacaklariMinScale;
    [SerializeField] GameObject _baslangicNoktasi,_ortaNoktasi,_finishNoktasi,_spreyNoktasi;
    [SerializeField] GameObject _degisekObje1,_uyariUnlemObj;
    [SerializeField] List<GameObject> _girisSirasi = new List<GameObject>(), _girisSirasi2 = new List<GameObject>(), _cikisSirasi = new List<GameObject>();

    private bool _presBasmaEfectControl, _cikisStackAlan;
    private GameObject tempSpreyEfectObj;
    // Start is called before the first frame update
    void Start()
    {
        _presAnimCalis = false;
        _presBasmaEfectControl = false;
        _cikisStackAlan = false;
        _uyariUnlemObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue == true)
        {
            if (_presAnimCalis && _presBasmaEfectControl==false)
            {
                presBasma();
                
            }
            else
            {
            }
            for (int i = 0; i < _cikisSirasi.Count; i++)
            {
                if (_cikisSirasi[i].transform.childCount==0)
                {
                       _cikisStackAlan = true;
                    _uyariUnlemObj.SetActive(false);
                   _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = true;
                    break;
                }
                else
                {
                    _cikisStackAlan = false;
                    _uyariUnlemObj.SetActive(true);
                    _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = false;
                }
            }
            //No1
            if (transform.childCount == 0 && transform.localPosition == _baslangicNoktasi.transform.localPosition && _cikisStackAlan)
            {
                _uyariUnlemObj.SetActive(false);

                if (_ikiliIhtiyacVar)//No2
                {
                    for (int i = _girisSirasi.Count - 1; i >= 0; i--)
                    {
                        if (_girisSirasi[i].transform.childCount == 1)//No3
                        {
                            for (int k = _girisSirasi2.Count - 1; k >= 0; k--)
                            {
                                if (_girisSirasi2[k].transform.childCount == 1)//No4
                                {
                                    GameObject tempObj = _girisSirasi[i].transform.GetChild(0).gameObject;
                                    tempObj.transform.parent = transform;
                                    tempObj.transform.DOJump(transform.position, 1f, 1, 1f);
                                    GameObject tempObj2 = _girisSirasi2[k].transform.GetChild(0).gameObject;
                                    tempObj2.transform.parent = transform;
                                    tempObj2.transform.DOJump(new Vector3(transform.position.x, transform.position.y+0.2f, transform.position.z), 1f, 1, 1f).OnComplete(() => ortayaGit());
                                    break;
                                }
                                else
                                {
                                    _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = false;
                                }
                            }
                            break;
                        }
                        if (i == 0)//No5
                        {
                            _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = false;
                        }
                    }
                }
                else//No2
                {
                    for (int i = _girisSirasi.Count - 1; i >= 0; i--)
                    {

                        if (_girisSirasi[i].transform.childCount == 1)//No6
                        {

                            GameObject tempObj = _girisSirasi[i].transform.GetChild(0).gameObject;
                            tempObj.transform.parent = transform;
                            tempObj.transform.DOJump(transform.position, 1f, 1, 1f).OnComplete(() => ortayaGit());
                            break;
                        }
                        if (i == 0)//No7
                        {
                            _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = false;
                        }
                    }
                }
            }
            //No1
            else //cıkıs stack alani doluysa!
            {
                
                


            }
        }
       
    }

    // TRIGER KONTROL YERİ--------------------

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==_spreyNoktasi)
        {
            _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = false;
            tempSpreyEfectObj = Instantiate(_renkPuskurtmeEfect, _renkPuskurtmeEfect.transform.parent);
            tempSpreyEfectObj.SetActive(true);
        }
        else if (true)
        {

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject== _presUcu)
        {
            _presAnimCalis = false;
            if (_ikiliIhtiyacVar)
            {
                Destroy(transform.GetChild(1).gameObject);
                Destroy(transform.GetChild(0).gameObject);
            }
            else
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            Instantiate(_degisekObje1,transform).transform.tag="toplanamazlar";
            if (_ayakkabiUretimMakinesi)
            {
                transform.DOLocalMove(_spreyNoktasi.transform.localPosition, 1f).OnComplete(() => boyamaNoktasi());

            }
            else
            {
                transform.DOLocalMove(_finishNoktasi.transform.localPosition, 1f).OnComplete(() => finishPozisyonu());
                if (PlayerPrefs.GetInt("AyakkabiUretimi") < 1)
                {
                    StartCoroutine(GameObject.FindGameObjectWithTag("OnBoardingController").GetComponent<OnBoardingController>().AyakkabiUretimi());
                    PlayerPrefs.SetInt("AyakkabiUretimi", 1);
                }
                else
                {
                }
            }
        }
    }
    //----------------------------------------


    // FONSİYONLAR----------------------------
    private void presBasma()
    {
        _presBasmaEfectControl = true;
        _presAnimCalis = false;
        _presBacaklari.transform.DOScale(_presBacaklariMaxScale, 0.25f);
        _presUcu.transform.DOLocalMove(_presUcuAltNoktasi, 0.25f).OnComplete(() => presCekme());

    }
    private void presCekme()
    {
        GameObject tempObj = Instantiate(_presBasmaEfect, _presBasmaEfect.transform.parent);
        tempObj.SetActive(true);
        _presBacaklari.transform.DOScale(_presBacaklariMinScale, 1f);
        _presUcu.transform.DOLocalMove(_presUcuUstNoktasi, 1f).OnComplete(() => _presBasmaEfectControl = false);

    }
    private void ortayaGit()
    {
      _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = true;
        transform.DOLocalMove(_ortaNoktasi.transform.localPosition, 1f).OnComplete(() => _presAnimCalis = true); 

    }
    private void boyamaNoktasi()
    {
        transform.DOLocalMove(_spreyNoktasi.transform.localPosition, 1f).OnComplete(() => bekleme());
    }
    private void bekleme()
    {
        Destroy(tempSpreyEfectObj);
        if (PlayerPrefs.GetInt("reyonaTasi") < 1)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("OnBoardingController").GetComponent<OnBoardingController>().reyonaTasi());
            PlayerPrefs.SetInt("reyonaTasi", 1);
        }
        else
        {
        }
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = true;
        transform.DOLocalMove(_finishNoktasi.transform.localPosition, 1f).OnComplete(() => finishPozisyonu());

    }
    private void finishPozisyonu()
    {
        
        for (int i = 0; i <_cikisSirasi.Count; i++)
        {
            if (_cikisSirasi[i].transform.childCount == 0)
            {
                GameObject tempObj = transform.GetChild(0).gameObject;
                tempObj.transform.parent=_cikisSirasi[i].transform;
                tempObj.transform.DOJump(tempObj.transform.parent.transform.position,3f,1,1f).OnComplete(()=> tempObj.transform.tag = "toplanabilirler");
                
                transform.DOLocalMove(_baslangicNoktasi.transform.localPosition, 0.01f);
                break;
            }
        }
        

    }

}
