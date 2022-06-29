using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using DG.Tweening;
public class KamyonTetikleme : MonoBehaviour
{
    [SerializeField] int _kamyonNo;
    [SerializeField] Text _kareAlanBedel,_buyText;
    [SerializeField] GameObject _kamyonObj,_tasinanObj,_hareketNoktasi,_yukIndırmeColliderObj,_StacklemeBaslangici,_fullObjesi,_paraObjesi;
    [SerializeField] List<GameObject> _stackNoktalari=new List<GameObject>();
    [SerializeField] int _bedelTextDegeri;
    private Animator _kamyonAnim;//runforward-runreverse
    public List<int> _sayacStackAlaniList=new List<int>();
    //yuk indirme icin--------------
    private float _transferTimer,_paraAktarimTimer;
    private int _transferSayac;
    private bool _transfereBasla,_gitti;
    public bool _doluluk,_paraAktar;
    //------------------------------
    void Start()
    {
        _kamyonAnim = _kamyonObj.GetComponent<Animator>();
        _transferTimer = 0;
        _transferSayac = 0;
        _paraAktarimTimer = 0;
        _doluluk = false;
        _paraAktar = false;

        if (PlayerPrefs.GetInt("KamyonKareAlanTextDegeri" + _kamyonNo + "ilkSefer") == 0)
        {
            PlayerPrefs.SetInt("KamyonKareAlanTextDegeri" + _kamyonNo + "ilkSefer", 1);
            PlayerPrefs.SetInt("KamyonKareAlanTextDegeri" + _kamyonNo, _bedelTextDegeri);
            _kareAlanBedel.text = "$" + PlayerPrefs.GetInt("KamyonKareAlanTextDegeri" + _kamyonNo);
        }
        else
        {
            _kareAlanBedel.text = "$" + PlayerPrefs.GetInt("KamyonKareAlanTextDegeri" + _kamyonNo);
        }

        _gitti = false;
         _paraAktar = true;
    }

    void FixedUpdate()
    {
        _sayacStackAlaniList.Clear();
        for (int k = 0; k < _stackNoktalari.Count; k++)
        {
            if (_stackNoktalari[k].transform.childCount == 1)
            {
                _sayacStackAlaniList.Add(1);

           
            }
            else
            {

            }
        }
        if (_sayacStackAlaniList.Count < 48)
        {
            _fullObjesi.gameObject.SetActive(false);
            _doluluk = false;
        }
        else
        {

            _fullObjesi.gameObject.SetActive(true);
            _doluluk = true;
            _kareAlanBedel.text = "...";
            _buyText.text = "Wait";
        }

        if (_transfereBasla && _doluluk==false)
        {
            _transferTimer += Time.deltaTime;
            if (_transferTimer > 0.5f && _transferSayac<10)
            {
                _transferTimer = 0;
                _transferSayac++;
                _kamyonYukIndirme();
            }
            else
            {
            }
            if (_transferSayac==10)
            {
                _transfereBasla = false;
                _transferSayac = 0;
                _kareAlanBedel.text = _bedelTextDegeri.ToString();
                _buyText.text = "BUY";
                PlayerPrefs.SetInt("KamyonKareAlanTextDegeri" + _kamyonNo, _bedelTextDegeri);
                _kamyonAnim.SetBool("runforward", false);
                _gitti = false;
                _paraAktar = true;
            }
        }

        if (_kareAlanBedel.text=="$0" && _doluluk == false)
        {
            
            _gitti = true;
            _hareketNoktasi.SetActive(true);
            _kamyonAnim.SetBool("runforward", true); 
            _kareAlanBedel.text = "...";
            _buyText.text = "Wait";
        }

       

    }
    //TRIGERLAR------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _yukIndırmeColliderObj && _gitti)
        {
            _kamyonAnim.SetBool("runforward", false);
            _transfereBasla = true;
        }
        _paraAktarimTimer = 0;
        if (other.gameObject.tag == "money")
        {
            PlayerPrefs.SetInt("KamyonKareAlanTextDegeri" + _kamyonNo, PlayerPrefs.GetInt("KamyonKareAlanTextDegeri" + _kamyonNo) - 10);
            if (PlayerPrefs.GetInt("KamyonKareAlanTextDegeri" + _kamyonNo) <= 0)
            {
                _paraAktar = false;
                PlayerPrefs.SetInt("KamyonKareAlanTextDegeri" + _kamyonNo, 0);
            }
            _kareAlanBedel.text = "$" + PlayerPrefs.GetInt("KamyonKareAlanTextDegeri" + _kamyonNo);
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        _paraAktarimTimer += Time.deltaTime;
        if (other.tag == "Player" && _doluluk == false&&_paraAktarimTimer>0.2f&& _paraAktar)
        {
            _paraAktarimTimer = 0;
            paraOde(other.gameObject);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //_paraAktar = false;
        }
    }
    //--------------------------------------------------
    private void paraOde(GameObject playerObj)
    {
        GameObject _tempPara = Instantiate(_paraObjesi, playerObj.transform);
        _tempPara.transform.DOJump(transform.position, 2f, 1, 1f).OnComplete(() => Destroy(_tempPara));


    }
    private void _kamyonYukIndirme()
    {
        for (int k = 0; k < _stackNoktalari.Count; k++)
        {
            if (_stackNoktalari[k].transform.childCount==0)
            {
                GameObject _tempTasinanObj = Instantiate(_tasinanObj, _StacklemeBaslangici.transform);
                _tempTasinanObj.transform.parent = _stackNoktalari[k].transform;
                _tempTasinanObj.transform.eulerAngles = new Vector3(0, -135, 0);
                _tempTasinanObj.transform.localScale =Vector3.zero;
                _tempTasinanObj.transform.DOScale(new Vector3(1,1,1),0.5f);
                _tempTasinanObj.transform.DOJump(_stackNoktalari[k].transform.position, 1f, 1, 1f);
                break;
            }
            else
            {

            }
        }
        
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("KamyonKareAlanTextDegeri" + _kamyonNo, _bedelTextDegeri);
    }

}
