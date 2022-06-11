using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class KislaSpawnScript : MonoBehaviour
{

    [Header("Urunlerin Spawn Olacagi Nokta")]
    public Transform _urunSpawnNoktasi;
    [Header("Spawn Olacak Urun Prefabi")]
    public GameObject _urunPrefab;
    [Header("Olusan Urunlerin Dizilecegi Noktalar")]
    public List<Transform> _dizilecekTransforms = new List<Transform>();
    [Header("Urunlerin Olusma Hizi")]
    public float _ambarSpawnHizi;
    [Header("Kontrol Amacli Burayi Elleme")]
    public List<GameObject> _olusanUrunler = new List<GameObject>();
    [Header("Spawn Olacak Urun Parent")]
    public GameObject _urunParent;
    [Header("Uretim Icin Gerekli Urun Sayisi")]
    public int _gerekliUrunSayisi;
    public Text _gerekliUrunSayisiText;
    public Text _gerekliKilicSayisiText;
    [Header("Talim Yapan Gladyator")]
    public GameObject _aciYokRocky;


    private float _timer;
    public int _ambarUrunSayisi;
    private int _bosSpawnNoktasi;

    private void Start()
    {
        _aciYokRocky.SetActive(false);
        _gerekliKilicSayisiText.text = "0";
    }



    public void KislaKilicSayisiGüncelle(int sayi)
    {
        _gerekliKilicSayisiText.text = sayi.ToString();
    }

    void Update()
    {
        _timer += Time.deltaTime;


        if (_gerekliUrunSayisi > 0)
        {
            if (GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>().totalLevelNo > 4 && GameObject.FindGameObjectWithTag("DemirciMerkez").gameObject.transform.GetChild(5).gameObject.transform.childCount > 0)
            {


                _aciYokRocky.SetActive(true);

                if (_olusanUrunler.Count < 45)
                {
                    if (_timer > _ambarSpawnHizi)
                    {

                        if (_olusanUrunler.Count == _ambarUrunSayisi)
                        {
                            GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                            //urun.gameObject.transform.DOMove(_dizilecekTransforms[_olusanUrunler.Count].position, 0.5f);
                            //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                            _olusanUrunler.Add(urun);
                            urun.transform.parent = _urunParent.transform;
                            _ambarUrunSayisi++;
                            _gerekliUrunSayisi--;
                            _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                            _timer = 0;
                        }
                        else
                        {

                            for (int i = 0; i < _olusanUrunler.Count; i++)
                            {


                                if (_olusanUrunler[i] == null)
                                {
                                    GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                                    _olusanUrunler[i] = urun;
                                    _bosSpawnNoktasi = i;

                                    //urun.gameObject.transform.DOMove(_dizilecekTransforms[_bosSpawnNoktasi].position, 0.5f);
                                    //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                                    urun.transform.parent = _urunParent.transform;

                                    _ambarUrunSayisi++;
                                    _gerekliUrunSayisi--;
                                    _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                                    break;
                                }
                                else if (_olusanUrunler[i].transform.parent != _urunParent.transform)
                                {
                                    GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                                    _olusanUrunler[i] = urun;
                                    _bosSpawnNoktasi = i;

                                    //urun.gameObject.transform.DOMove(_dizilecekTransforms[_bosSpawnNoktasi].position, 0.5f);
                                    //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                                    urun.transform.parent = _urunParent.transform;

                                    _ambarUrunSayisi++;
                                    _gerekliUrunSayisi--;
                                    _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                                    break;

                                }
                                else
                                {


                                }

                            }

                            _timer = 0;

                        }
                    }
                }
                else
                {
                    if (_timer > _ambarSpawnHizi)
                    {

                        for (int i = 0; i < _olusanUrunler.Count; i++)
                        {


                            if (_olusanUrunler[i] == null)
                            {
                                GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                                _olusanUrunler[i] = urun;
                                _bosSpawnNoktasi = i;

                                //urun.gameObject.transform.DOMove(_dizilecekTransforms[_bosSpawnNoktasi].position, 0.5f);
                                //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                                urun.transform.parent = _urunParent.transform;

                                _ambarUrunSayisi++;
                                _gerekliUrunSayisi--;
                                _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                                break;
                            }
                            else if (_olusanUrunler[i].transform.parent != _urunParent.transform)
                            {
                                GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                                _olusanUrunler[i] = urun;
                                _bosSpawnNoktasi = i;

                                //urun.gameObject.transform.DOMove(_dizilecekTransforms[_bosSpawnNoktasi].position, 0.5f);
                                //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                                urun.transform.parent = _urunParent.transform;

                                _ambarUrunSayisi++;
                                _gerekliUrunSayisi--;
                                _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                                break;

                            }
                            else
                            {


                            }

                        }

                        _timer = 0;
                    }
                }
            }
            else if (GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>().totalLevelNo == 4)
            {

                if (_olusanUrunler.Count < 45)
                {
                    if (_timer > _ambarSpawnHizi)
                    {

                        if (_olusanUrunler.Count == _ambarUrunSayisi)
                        {
                            GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                            //urun.gameObject.transform.DOMove(_dizilecekTransforms[_olusanUrunler.Count].position, 0.5f);
                            //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                            _olusanUrunler.Add(urun);
                            urun.transform.parent = _urunParent.transform;
                            _ambarUrunSayisi++;
                            _gerekliUrunSayisi--;
                            _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                            _timer = 0;
                        }
                        else
                        {

                            for (int i = 0; i < _olusanUrunler.Count; i++)
                            {


                                if (_olusanUrunler[i] == null)
                                {
                                    GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                                    _olusanUrunler[i] = urun;
                                    _bosSpawnNoktasi = i;

                                    //urun.gameObject.transform.DOMove(_dizilecekTransforms[_bosSpawnNoktasi].position, 0.5f);
                                    //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                                    urun.transform.parent = _urunParent.transform;

                                    _ambarUrunSayisi++;
                                    _gerekliUrunSayisi--;
                                    _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                                    break;
                                }
                                else if (_olusanUrunler[i].transform.parent != _urunParent.transform)
                                {
                                    GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                                    _olusanUrunler[i] = urun;
                                    _bosSpawnNoktasi = i;

                                    //urun.gameObject.transform.DOMove(_dizilecekTransforms[_bosSpawnNoktasi].position, 0.5f);
                                    //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                                    urun.transform.parent = _urunParent.transform;

                                    _ambarUrunSayisi++;
                                    _gerekliUrunSayisi--;
                                    _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                                    break;

                                }
                                else
                                {


                                }

                            }

                            _timer = 0;

                        }
                    }
                }
                else
                {
                    if (_timer > _ambarSpawnHizi)
                    {

                        for (int i = 0; i < _olusanUrunler.Count; i++)
                        {


                            if (_olusanUrunler[i] == null)
                            {
                                GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                                _olusanUrunler[i] = urun;
                                _bosSpawnNoktasi = i;

                                //urun.gameObject.transform.DOMove(_dizilecekTransforms[_bosSpawnNoktasi].position, 0.5f);
                                //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                                urun.transform.parent = _urunParent.transform;

                                _ambarUrunSayisi++;
                                _gerekliUrunSayisi--;
                                _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                                break;
                            }
                            else if (_olusanUrunler[i].transform.parent != _urunParent.transform)
                            {
                                GameObject urun = Instantiate(_urunPrefab, _urunSpawnNoktasi.position, Quaternion.identity);
                                _olusanUrunler[i] = urun;
                                _bosSpawnNoktasi = i;

                                //urun.gameObject.transform.DOMove(_dizilecekTransforms[_bosSpawnNoktasi].position, 0.5f);
                                //urun.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                                urun.transform.parent = _urunParent.transform;

                                _ambarUrunSayisi++;
                                _gerekliUrunSayisi--;
                                _gerekliUrunSayisiText.text = _gerekliUrunSayisi.ToString();

                                break;

                            }
                            else
                            {


                            }

                        }

                        _timer = 0;
                    }
                }
            }
            else
            {

            }

        }
        else
        {
            _aciYokRocky.SetActive(false);
        }
    }
}
