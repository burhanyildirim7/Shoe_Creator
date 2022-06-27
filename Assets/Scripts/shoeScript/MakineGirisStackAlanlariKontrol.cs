using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakineGirisStackAlanlariKontrol : MonoBehaviour
{
    [SerializeField] string _makineAdi;
    [SerializeField] List<GameObject> _girisSirasi1 = new List<GameObject>(), _stackObjesi=new List<GameObject>();
    
    void Start()
    {
        

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
            if (PlayerPrefs.GetInt(_makineAdi + i) >= 0)
            {
                Instantiate(_stackObjesi[PlayerPrefs.GetInt(_makineAdi + i)], _girisSirasi1[i].transform);
            }
            else
            {
            }
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
