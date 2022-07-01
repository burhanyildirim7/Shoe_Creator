using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BedelOdemeScrit : MonoBehaviour
{
    [SerializeField] Text _bedelAlaniTexti;
    [SerializeField] public string _bedelTextiPlayerPrefAdi;
    [SerializeField] public int _bedelDegeri;
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
        if (other.tag == "BedelOdemeMoney")
        {
            BedelOdeUlen();
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        _paraIcinTimer += Time.deltaTime;

    }
    private void OnTriggerExit(Collider other)
    {
      
    }
    private void paraOde(GameObject playerObj)
    {
        GameObject _tempPara = Instantiate(_paraObj,playerObj.transform.GetChild(2).transform);

        _tempPara.transform.DOJump(transform.position, 2f, 1, 1f).OnComplete(()=>Destroy(_tempPara)) ;

    }
    public void BedelOdeUlen()
    {
        PlayerPrefs.SetInt(_bedelTextiPlayerPrefAdi, PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi)-10);
        _bedelAlaniTexti.text = "$" + PlayerPrefs.GetInt(_bedelTextiPlayerPrefAdi).ToString();
    }


}
