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
    [SerializeField] GameObject _degisekObje1,_degisecekObje2;
    [SerializeField] List<GameObject> _girisSirasi = new List<GameObject>(), _cikisSirasi = new List<GameObject>();

    private bool _presBasmaEfectControl, _spreyEfectControl;

    // Start is called before the first frame update
    void Start()
    {
        _presAnimCalis = false;
        _presBasmaEfectControl = false;
        _spreyEfectControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue == true)
        {
            if (_presAnimCalis && _presBasmaEfectControl==false)
            {
                _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = true;
                presBasma();
                
            }
            else
            {
                _MakineAnimasyonScripti.GetComponent<MakineAnimasyonlari>()._animCalisma = false;
            }
            if (transform.childCount == 0 && transform.localPosition == _baslangicNoktasi.transform.localPosition)
            {
               
                for (int i = _girisSirasi.Count-1; i >= 0; i--)
                {
                  
                    if (_girisSirasi[i].transform.childCount == 1)
                    {
                     
                        GameObject tempObj = _girisSirasi[i].transform.GetChild(0).gameObject;
                        tempObj.transform.parent = transform;
                        tempObj.transform.DOJump(transform.position, 1f, 1, 1f).OnComplete(() => ortayaGit());
                        
                                             
                        break;
                    }

                }
            }





        }
       
    }

    // TRIGER KONTROL YERİ--------------------

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="MandaHam"|| other.tag == "YilanHam"|| other.tag == "TimsahHam")
        {
            
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
            Destroy(transform.GetChild(0).gameObject);
            Instantiate(_degisekObje1,transform);
            if (_ayakkabiUretimMakinesi)
            {
                transform.DOLocalMove(_spreyNoktasi.transform.localPosition, 0.5f).OnComplete(() => boyamaNoktasi());

            }
            else
            {
                transform.DOLocalMove(_finishNoktasi.transform.localPosition, 1f).OnComplete(() => finishPozisyonu());

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
        transform.DOLocalMove(_ortaNoktasi.transform.localPosition, 1f).OnComplete(() => _presAnimCalis = true); 

    }
    private void boyamaNoktasi()
    {

        _renkPuskurtmeEfect.SetActive(true);
        transform.DOLocalMove(_renkPuskurtmeEfect.transform.localPosition, 2f).OnComplete(() => bekleme());

    }
    private IEnumerator bekleme()
    {
        yield return (new WaitForSeconds(2f));

        finishPozisyonu();

    }
    private void finishPozisyonu()
    {

        for (int i = 0; i <_cikisSirasi.Count; i++)
        {
            if (_cikisSirasi[i].transform.childCount == 0)
            {
                GameObject tempObj = transform.GetChild(0).gameObject;
                tempObj.transform.parent=_cikisSirasi[i].transform;
                tempObj.transform.DOJump(tempObj.transform.parent.transform.position,3f,1,1f);
                transform.DOLocalMove(_baslangicNoktasi.transform.localPosition, 0.01f);
                break;
            }
        }
        

    }

}
