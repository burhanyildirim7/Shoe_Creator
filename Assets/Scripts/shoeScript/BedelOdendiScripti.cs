using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BedelOdendiScripti : MonoBehaviour
{
    private Text _bedelTexti;
    [SerializeField] string _makinePlayerPrefAdi;
    

    // Start is called before the first frame update
    void Start()
    {
        _bedelTexti = transform.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        
        if (PlayerPrefs.GetInt(_makinePlayerPrefAdi) == 1)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue == true)
        {
            if (_bedelTexti.text=="$0" && PlayerPrefs.GetInt(_makinePlayerPrefAdi) ==0)
            {

                PlayerPrefs.SetInt(_makinePlayerPrefAdi, 1);
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {

            }

        }
    }
}
