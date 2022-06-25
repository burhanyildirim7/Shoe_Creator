using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakineAnimasyonlari : MonoBehaviour
{
    [SerializeField] GameObject _ustBant, _altBant,_lamba,_koruk1,_koruk2,_korukefekt1,_korukefekt2;
    [SerializeField] List<GameObject> _carkListesi = new List<GameObject>();
    [SerializeField] float _bandHizi, _donusHizi,_korukHizi;
    [SerializeField] bool pamukMakinesiMi;
    float _timer;
    bool _korukYonu;


    [SerializeField] public bool _animCalisma;

    // Start is called before the first frame update
    void Start()
    {
        _bandHizi = 0;
        _donusHizi = 1f;
        _korukHizi=0.01f;
        //_animCalisma = false;
        _korukYonu = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.isContinue == true)
        {
            if (_animCalisma == true)
            {
                _timer += Time.deltaTime;
                if (_timer > 0.01f)
                {
                    _timer = 0;
                    MaterialOffsetleme();

                }
            }
            else
            {

            }

        }

    }

    private void MaterialOffsetleme()
    {
        _bandHizi+=0.01f;
        _ustBant.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(_bandHizi, 0);
        _altBant.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(_bandHizi, 0);

       


        for (int i = 0; i < _carkListesi.Count; i++)
        {
            _carkListesi[i].transform.eulerAngles=new Vector3(_carkListesi[i].transform.eulerAngles.x, _carkListesi[i].transform.eulerAngles.y, _carkListesi[i].transform.eulerAngles.z + _donusHizi);
        }
        if (pamukMakinesiMi)
        {
            if (_korukYonu == false)
            {
                _korukHizi += 0.05f;
                _koruk1.transform.localScale = new Vector3(1, _korukHizi, 1);
                _koruk2.transform.localScale = new Vector3(1, 1.3f - _korukHizi, 1);
                if (_korukHizi > 1)
                {
                    _korukYonu = true;
                    GameObject tempObj = Instantiate(_korukefekt1, _korukefekt1.transform.parent);
                    tempObj.SetActive(true);
                }
                else
                {

                }
            }
            else
            {
                _korukHizi -= 0.05f;
                _koruk1.transform.localScale = new Vector3(1, _korukHizi, 1);
                _koruk2.transform.localScale = new Vector3(1, 1.3f - _korukHizi, 1);
                _lamba.transform.eulerAngles = new Vector3(_lamba.transform.eulerAngles.x, _lamba.transform.eulerAngles.y, _lamba.transform.eulerAngles.z + _donusHizi * 5);
                if (_korukHizi < 0.3f)
                {
                    _korukYonu = false;
                    GameObject tempObj = Instantiate(_korukefekt2, _korukefekt2.transform.parent);
                    tempObj.SetActive(true);
                }
                else
                {

                }
            }


        }



    }    

}
