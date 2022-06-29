using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MakineGirisStackAlanlariKontrol : MonoBehaviour
{
    [SerializeField] string _makineAdi;
    [SerializeField] Text _adetText;
    [SerializeField] bool _adetYazilacak;
    [SerializeField] List<GameObject> _girisSirasi1 = new List<GameObject>(), _stackObjesi=new List<GameObject>();
    [SerializeField] public int _stacklenecekObjeNumarasi;
    private List<int> _adetSayacList = new List<int>();
    private float _adetSayacTimer;
    void Start()
    {
        _adetSayacTimer = 0;

        if (PlayerPrefs.GetInt(_makineAdi + "ilkseferstackkontrtolu")==0)
        {
            PlayerPrefs.SetInt(_makineAdi + "ilkseferstackkontrtolu", 1);
            for (int m = 0; m < _girisSirasi1.Count; m++)
            {
                PlayerPrefs.SetInt(_makineAdi + m, -1);
            }
        }
        for (int i = 0; i < _girisSirasi1.Count; i++)
        {
            _girisSirasi1[i].transform.GetChild(0).transform.DOLocalRotate(Vector3.zero,0.01f);
            if (PlayerPrefs.GetInt(_makineAdi + i) >= 0)
            {
                GameObject _GeciciObje=
                Instantiate(_stackObjesi[PlayerPrefs.GetInt(_makineAdi + i)], _girisSirasi1[i].transform);
                if (PlayerPrefs.GetInt(_makineAdi + i)>7)
                {
                    _GeciciObje.transform.GetChild(0).gameObject.SetActive(false);
                    _GeciciObje.transform.GetChild(1).gameObject.SetActive(true);
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
    private void FixedUpdate()
    {
        _adetSayacList.Clear();
        for (int i = 0; i < _girisSirasi1.Count; i++)
        {
            _girisSirasi1[i].transform.GetChild(0).transform.DOLocalRotate(Vector3.zero, 0.01f);
            if (_girisSirasi1[i].gameObject.transform.childCount==1)
            {
                _adetSayacList.Add(1);
            }
            else
            {

            }

        }
        if (_adetYazilacak)
        {
            _adetText.text = _adetSayacList.Count + "/10";
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        ListeDuzenleme();
    }

    private void OnTriggerExit(Collider other)
    {
        ListeDuzenleme();
    }

    private void ListeDuzenleme()
    {
        for (int i = 0; i < _girisSirasi1.Count; i++)
        {
            if (_girisSirasi1[i].transform.childCount==1)
            {
                for (int k = 0; k < _stackObjesi.Count; k++)
                {
                    if (_girisSirasi1[i].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.name == _stackObjesi[k].transform.GetChild(0).gameObject.name)
                    {
                        PlayerPrefs.SetInt(_makineAdi+i,k);
                        break;
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                PlayerPrefs.SetInt(_makineAdi + i, -1);
            }
        }
    }
}
