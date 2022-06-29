using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BedelOdemeScrit : MonoBehaviour
{
    [SerializeField] Text _bedelAlaniTexti;
    [SerializeField] string _bedelTextiPlayerPrefAdi;
    [SerializeField] int _bedelDegeri;
    [SerializeField] GameObject _paraObj;
    private float _paraIcinTimer;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi+"ilkSefer")==0)
        {
            PlayerPrefs.SetInt(_bedelTextiPlayerPrefAdi+"ilkSefer",1);
            PlayerPrefs.SetInt(_bedelTextiPlayerPrefAdi, _bedelDegeri);
            PlayerPrefs.SetInt(_bedelTextiPlayerPrefAdi+"2", _bedelDegeri);
            _bedelAlaniTexti.text = "$" + PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi);
        }
        else
        {
            _bedelAlaniTexti.text = "$"+PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi);
        }

    }
    private void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //_paraIcinTimer = 0;
        if (other.gameObject.tag=="money")
        {
            PlayerPrefs.SetInt(_bedelTextiPlayerPrefAdi, PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi)-10);
            if (PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi)<=0)
            {
                PlayerPrefs.SetInt(_bedelTextiPlayerPrefAdi, 0);
            }
            _bedelAlaniTexti.text = "$" + PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        _paraIcinTimer += Time.deltaTime;
        if (other.gameObject.tag=="Player"&& PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi + "2")>0)
        {
            if (_paraIcinTimer > 0.2f)
            {
                PlayerPrefs.SetInt(_bedelTextiPlayerPrefAdi + "2", PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi + "2") - 10);
                _paraIcinTimer = 0;
                paraOde(other.gameObject);
                Debug.Log("DEEEEGEGERERER:" + PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi + "2"));

            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
      
    }
    private void paraOde(GameObject playerObj)
    {
        GameObject _tempPara = Instantiate(_paraObj,playerObj.transform.GetChild(2).transform);

        _tempPara.transform.DOJump(transform.position, 2f, 1, 1f).OnComplete(()=>Destroy(_tempPara)) ;

    }


}
