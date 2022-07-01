using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReyonKontrol : MonoBehaviour
{
    [SerializeField] public string _reyonAdi;
    [SerializeField] bool _expandMi;
    [SerializeField] Text _reyonBedelText;
    [SerializeField] public int _reyonAcilisBedeli;
    [SerializeField] GameObject _acilacakObje, _kapanacakObj,_kapanacakObj2, _paraMObjesi;
    private float _reyonSayac1, _reyonSayac2;


    void Start()
    {
        if (PlayerPrefs.GetInt("ReyonAcildi"+_reyonAdi)==1)
        {

            _acilacakObje.SetActive(true);
            _kapanacakObj.SetActive(false);
            if (_expandMi)
            {
                _kapanacakObj2.SetActive(false);
            }

        }
        else
        {
            _acilacakObje.SetActive(false);
            _kapanacakObj.SetActive(true);
            if (_expandMi)
            {
                _kapanacakObj2.SetActive(true);
            }
        }
        if (PlayerPrefs.GetInt("ReyonIlki" + _reyonAdi) == 0)
        {
            PlayerPrefs.SetInt("ReyonIlki" + _reyonAdi,1);
            PlayerPrefs.SetInt(_reyonAdi, _reyonAcilisBedeli);
            _reyonBedelText.text = "$" + PlayerPrefs.GetInt(_reyonAdi);
        }
        else
        {
            _reyonBedelText.text = "$" + PlayerPrefs.GetInt(_reyonAdi);
        }
    }

    void Update()
    {
        if (_reyonBedelText.text == "$0")
        {
            _acilacakObje.SetActive(true);
            _kapanacakObj.SetActive(false);
            if (_expandMi)
            {
                _kapanacakObj2.SetActive(false);
            }
            PlayerPrefs.SetInt("ReyonAcildi" + _reyonAdi, 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BedelOdemeMoney")
        {
            BedelOdeUlen();
            Destroy(other.gameObject);
        }

    }
    private void OnTriggerStay(Collider other)
    {

    }

    private void paraOde(GameObject playerObj)
    {
            GameObject _tempPara = Instantiate(_paraMObjesi, playerObj.transform.position,new Quaternion(-45,0,0,1));
            _tempPara.transform.DOJump(transform.position, 2f, 1,1f).OnComplete(() => Destroy(_tempPara));
            
    }
    public void BedelOdeUlen()
    {
        PlayerPrefs.SetInt(_reyonAdi, PlayerPrefs.GetInt(_reyonAdi) - 10);
        // _bedelText.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).OnComplete(() => _bedelText.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));
        _reyonBedelText.text ="$" + PlayerPrefs.GetInt(_reyonAdi).ToString();
        //_objeAcmaScript.ObjeAcmaKontrolEt();
        ;
    }


}
