using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReyonAcmaKontrol : MonoBehaviour
{

    [SerializeField] List<GameObject> Reyonlar = new List<GameObject>(), _acilacakAlanlar = new List<GameObject>();
    private int _deger, _acilanSayisi, _aradeger, expandDeger, _expandAraDeger;
    private float _timer;

    public List<GameObject> _stackNoktalari = new List<GameObject>();

    void Start()
    {
        _acilanSayisi = PlayerPrefs.GetInt("acilanSayisi");
        _deger = 3 + _acilanSayisi;
        Reyonlar[0].SetActive(true);
        Reyonlar[1].SetActive(true);
        Reyonlar[2].SetActive(true);
        for (int i = _deger; i < Reyonlar.Count; i++)
        {
            Reyonlar[i].SetActive(false);
        }
        for (int i = 2; i < _deger; i++)
        {
            Reyonlar[i].SetActive(true);
        }

        StackNoktasiBul();

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 0.2f)
        {

            _aradeger = 0;
            _acilanSayisi = 0;

            for (int i = 0; i < _acilacakAlanlar.Count; i++)
            {
                if (_acilacakAlanlar[i].activeSelf == true)
                {
                    _aradeger++;
                    if (_aradeger == 3)
                    {
                        _acilanSayisi += 3;
                        _aradeger = 0;
                    }

                }

            }
            PlayerPrefs.SetInt("acilanSayisi", _acilanSayisi);
            yeniAlanAc();
        }
    }

    private void StackNoktasiBul()
    {
        for (int i = 0; i < _acilacakAlanlar.Count; i++)
        {
            for (int k = 2; k < _acilacakAlanlar[i].gameObject.transform.GetChild(0).gameObject.transform.childCount; k++)
            {
                _stackNoktalari.Add(_acilacakAlanlar[i].gameObject.transform.GetChild(0).GetChild(k).gameObject);
            }
        }
    }

    private void yeniAlanAc()
    {
        _deger = 3 + _acilanSayisi;
        for (int i = 2; i < _deger; i++)
        {
            Reyonlar[i].SetActive(true);
        }
    }
}
