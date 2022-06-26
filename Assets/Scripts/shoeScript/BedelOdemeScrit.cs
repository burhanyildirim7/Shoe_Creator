using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedelOdemeScrit : MonoBehaviour
{
    [SerializeField] Text _bedelAlaniTexti;
    [SerializeField] string _bedelTextiPlayerPrefAdi;
   
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi+"ilkSefer")==0)
        {
            PlayerPrefs.SetInt(_bedelTextiPlayerPrefAdi+"ilkSefer",1);
            PlayerPrefs.SetString(_bedelTextiPlayerPrefAdi, _bedelAlaniTexti.text);
        }
        else
        {
            _bedelAlaniTexti.text = PlayerPrefs.GetString(_bedelTextiPlayerPrefAdi);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ontrigerenterda");
        PlayerPrefs.SetString(_bedelTextiPlayerPrefAdi, _bedelAlaniTexti.text);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ontrigerexitda");
        PlayerPrefs.SetString(_bedelTextiPlayerPrefAdi, _bedelAlaniTexti.text);
    }



}
