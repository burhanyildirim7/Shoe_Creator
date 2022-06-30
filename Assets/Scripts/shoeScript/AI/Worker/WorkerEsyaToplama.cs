using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class WorkerEsyaToplama : MonoBehaviour
{

    [SerializeField] public List<GameObject> _clientStackAlanlari = new List<GameObject>(), _stacklenebilirObjeler = new List<GameObject>();
    public List<GameObject> _clientCantadakilerinSayisiIcinListe = new List<GameObject>();
    private List<GameObject>
        _hamManda = new List<GameObject>(),
        _islenmisManda = new List<GameObject>(),
        _hamPamuk = new List<GameObject>(),
        _islenmisPamuk = new List<GameObject>(),
        _hamYilan = new List<GameObject>(),
        _islenmisYilan = new List<GameObject>(),
        _hamTimsah = new List<GameObject>(),
        _islenmisTimsah = new List<GameObject>(),
        _ayakkabi1 = new List<GameObject>(),
        _ayakkabi2 = new List<GameObject>(),
        _ayakkabi3 = new List<GameObject>(),
        _ayakkabi4 = new List<GameObject>(),
        _ayakkabi5 = new List<GameObject>(),
        _ayakkabi6 = new List<GameObject>();

    private int _stacklenebilirObjeSirasi;

    private float _cantaDuzenlemeSayaci, _cantaDuzenlemeSayaci2, _cantaDuzenlemeSayaci3, _playerStackNoktasiAraligi;

    private GameObject _gonderilecekKonum;


    // Start is called before the first frame update
    void Start()
    {
        _stacklenebilirObjeSirasi = 0;
        _playerStackNoktasiAraligi = 0;
        _cantaDuzenlemeSayaci = 0;
        _cantaDuzenlemeSayaci2 = 0;

        _clientCantadakilerinSayisiIcinListe.Clear();
        for (int i = 0; i < _clientStackAlanlari.Count; i++)
        {
            if (_clientStackAlanlari[i].transform.childCount == 1)
            {
                _clientCantadakilerinSayisiIcinListe.Add(_clientStackAlanlari[i].gameObject);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerStay(Collider other)
    {
        _cantaDuzenlemeSayaci2 += Time.deltaTime;
        if (other.tag == "toplanabilirler" && _cantaDuzenlemeSayaci2 > 0.1f)
        {
            _cantaDuzenlemeSayaci2 = 0;


            for (int i = 0; i < _clientStackAlanlari.Count; i++)
            {
                if (_clientStackAlanlari[i].transform.childCount == 0)
                {
                    other.tag = "toplanamazlar";
                    other.transform.parent = _clientStackAlanlari[i].transform;
                    other.transform.DOJump(other.transform.parent.transform.position, 1f, 1, 0.2f).OnComplete(() => StackDuzelt(other.gameObject));
                    ListeBelirleme(other.gameObject);
                    MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
                    break;
                }
            }
        }

        _cantaDuzenlemeSayaci += Time.deltaTime;
        if (other.tag == "GirisAlani" && _cantaDuzenlemeSayaci > 0.1f)
        {
            _cantaDuzenlemeSayaci = 0;
            int _objeTuru = other.GetComponent<MakineGirisStackAlanlariKontrol>()._stacklenecekObjeNumarasi;

            for (int i = 2; i < other.gameObject.transform.parent.transform.childCount; i++)
            {
                if (other.gameObject.transform.parent.transform.GetChild(i).childCount == 0)
                {
                    _gonderilecekKonum = other.gameObject.transform.parent.transform.GetChild(i).gameObject;
                    ListedenCikartma(_objeTuru, _gonderilecekKonum);
                    break;
                }
                else
                {
                }
            }
        }
    }

    //********
    private void StackDuzelt(GameObject StackObj)
    {
        StackObj.transform.localPosition = Vector3.zero;
        StackObj.transform.eulerAngles = Vector3.zero;
        StackObj.transform.localScale = new Vector3(1, 1, 1);
        PlayerStackDuzenleme();

    }
    private void PlayerStackDuzenleme()
    {
        for (int i = 1; i < _clientStackAlanlari.Count; i++)
        {
            _clientStackAlanlari[0].transform.GetChild(0).transform.DOLocalRotate(Vector3.zero, 0.01f);
            _clientStackAlanlari[i].transform.GetChild(0).transform.DOLocalRotate(Vector3.zero, 0.01f);
            _clientStackAlanlari[0].transform.GetChild(0).transform.DOLocalMove(Vector3.zero, 0.01f);
            _clientStackAlanlari[i].transform.GetChild(0).transform.DOLocalMove(Vector3.zero, 0.01f);

            if (_clientStackAlanlari[i].transform.childCount == 1)
            {
                for (int k = 0; k < _stacklenebilirObjeler.Count; k++)
                {
                    if (_clientStackAlanlari[i - 1].transform.GetChild(0).GetChild(0).gameObject.name == _stacklenebilirObjeler[k].transform.GetChild(0).gameObject.name)
                    {
                        if (k > 7)
                        {
                            _playerStackNoktasiAraligi = 0.9f;
                        }
                        else if (k >= 0 && k <= 7)
                        {
                            _playerStackNoktasiAraligi = 0.2f;
                        }
                        else
                        {
                        }
                        break;
                    }
                }

                _clientStackAlanlari[i].transform.localPosition = new Vector3(0, _clientStackAlanlari[i - 1].transform.localPosition.y + _playerStackNoktasiAraligi, 0);

            }
        }

        _clientCantadakilerinSayisiIcinListe.Clear();
        for (int i = 0; i < _clientStackAlanlari.Count; i++)
        {
            if (_clientStackAlanlari[i].transform.childCount == 1)
            {
                _clientCantadakilerinSayisiIcinListe.Add(_clientStackAlanlari[i].gameObject);

            }
        }


    }

    private void CantadakiBosluklariKapatma()
    {
        for (int i = 1; i < _clientStackAlanlari.Count; i++)
        {
            if (_clientStackAlanlari[i].transform.childCount == 1)
            {
                if (_clientStackAlanlari[i - 1].transform.childCount == 0)
                {
                    for (int k = 0; k < _clientStackAlanlari.Count; k++)
                    {
                        if (_clientStackAlanlari[k].transform.childCount == 0)
                        {
                            _clientStackAlanlari[i].transform.GetChild(0).transform.parent = _clientStackAlanlari[k].transform;
                            _clientStackAlanlari[k].transform.GetChild(0).transform.localPosition = Vector3.zero;
                            _clientStackAlanlari[k].transform.GetChild(0).transform.eulerAngles = Vector3.zero;
                            break;
                        }
                    }
                }
                else
                {

                }

            }

        }

    }

    private void ListeBelirleme(GameObject _gelenObje)
    {
        for (int i = 0; i < _stacklenebilirObjeler.Count; i++)
        {
            if (_gelenObje.transform.GetChild(0).gameObject.name == _stacklenebilirObjeler[i].transform.GetChild(0).gameObject.name)
            {

                _stacklenebilirObjeSirasi = i + 1;
                break;
            }
            else
            {
                _stacklenebilirObjeSirasi = -1;
            }
        }
        switch (_stacklenebilirObjeSirasi)
        {
            case 1:
                _hamManda.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 2:

                _islenmisManda.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 3:

                _hamPamuk.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 4:

                _islenmisPamuk.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 5:

                _hamYilan.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 6:

                _islenmisYilan.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 7:

                _hamTimsah.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 8:

                _islenmisTimsah.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 9:

                _ayakkabi1.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 10:

                _ayakkabi2.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 11:

                _ayakkabi3.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 12:

                _ayakkabi4.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 13:

                _ayakkabi5.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
            case 14:

                _ayakkabi6.Add(_gelenObje);
                _clientCantadakilerinSayisiIcinListe.Add(_gelenObje);
                break;
        }

    }
    private void ListedenCikartma(int _objTurNo, GameObject _teslimatNoktasi)
    {
        _stacklenebilirObjeSirasi = _objTurNo;
        switch (_stacklenebilirObjeSirasi)
        {
            case 1:
                if (_hamManda.Count > 0)
                {
                    _hamManda[_hamManda.Count - 1].transform.parent = null;
                    _hamManda[_hamManda.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _hamManda[_hamManda.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _hamManda[_hamManda.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _hamManda.RemoveAt(_hamManda.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 2:
                if (_islenmisManda.Count > 0)
                {
                    _islenmisManda[_islenmisManda.Count - 1].transform.parent = null;
                    _islenmisManda[_islenmisManda.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _islenmisManda[_islenmisManda.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _islenmisManda[_islenmisManda.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _islenmisManda.RemoveAt(_islenmisManda.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }
                break;
            case 3:
                if (_hamPamuk.Count > 0)
                {
                    _hamPamuk[_hamPamuk.Count - 1].transform.parent = null;
                    _hamPamuk[_hamPamuk.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _hamPamuk[_hamPamuk.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _hamPamuk[_hamPamuk.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _hamPamuk.RemoveAt(_hamPamuk.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }
                break;
            case 4:
                if (_islenmisPamuk.Count > 0)
                {
                    _islenmisPamuk[_islenmisPamuk.Count - 1].transform.parent = null;
                    _islenmisPamuk[_islenmisPamuk.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _islenmisPamuk[_islenmisPamuk.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _islenmisPamuk[_islenmisPamuk.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _islenmisPamuk.RemoveAt(_islenmisPamuk.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 5:
                if (_hamYilan.Count > 0)
                {
                    _hamYilan[_hamYilan.Count - 1].transform.parent = null;
                    _hamYilan[_hamYilan.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _hamYilan[_hamYilan.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _hamYilan[_hamYilan.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _hamYilan.RemoveAt(_hamYilan.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 6:
                if (_islenmisYilan.Count > 0)
                {
                    _islenmisYilan[_islenmisYilan.Count - 1].transform.parent = null;
                    _islenmisYilan[_islenmisYilan.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _islenmisYilan[_islenmisYilan.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _islenmisYilan[_islenmisYilan.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _islenmisYilan.RemoveAt(_islenmisYilan.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 7:
                if (_hamTimsah.Count > 0)
                {
                    _hamTimsah[_hamTimsah.Count - 1].transform.parent = null;
                    _hamTimsah[_hamTimsah.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _hamTimsah[_hamTimsah.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _hamTimsah[_hamTimsah.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _hamTimsah.RemoveAt(_hamTimsah.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 8:
                if (_islenmisTimsah.Count > 0)
                {
                    _islenmisTimsah[_islenmisTimsah.Count - 1].transform.parent = null;
                    _islenmisTimsah[_islenmisTimsah.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _islenmisTimsah[_islenmisTimsah.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _islenmisTimsah[_islenmisTimsah.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _islenmisTimsah.RemoveAt(_islenmisTimsah.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 9:
                if (_ayakkabi1.Count > 0)
                {
                    _ayakkabi1[_ayakkabi1.Count - 1].transform.parent = null;
                    _ayakkabi1[_ayakkabi1.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _ayakkabi1[_ayakkabi1.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _ayakkabi1[_ayakkabi1.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _ayakkabi1.RemoveAt(_ayakkabi1.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 10:
                if (_ayakkabi2.Count > 0)
                {
                    _ayakkabi2[_ayakkabi2.Count - 1].transform.parent = null;
                    _ayakkabi2[_ayakkabi2.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _ayakkabi2[_ayakkabi2.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _ayakkabi2[_ayakkabi2.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _ayakkabi2.RemoveAt(_ayakkabi2.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 11:
                if (_ayakkabi3.Count > 0)
                {
                    _ayakkabi3[_ayakkabi3.Count - 1].transform.parent = null;
                    _ayakkabi3[_ayakkabi3.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _ayakkabi3[_ayakkabi3.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _ayakkabi3[_ayakkabi3.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _ayakkabi3.RemoveAt(_ayakkabi3.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 12:
                if (_ayakkabi4.Count > 0)
                {
                    _ayakkabi4[_ayakkabi4.Count - 1].transform.parent = null;
                    _ayakkabi4[_ayakkabi4.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _ayakkabi4[_ayakkabi4.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _ayakkabi4[_ayakkabi4.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _ayakkabi4.RemoveAt(_ayakkabi4.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 13:
                if (_ayakkabi5.Count > 0)
                {
                    _ayakkabi5[_ayakkabi5.Count - 1].transform.parent = null;
                    _ayakkabi5[_ayakkabi5.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _ayakkabi5[_ayakkabi5.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _ayakkabi5[_ayakkabi5.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _ayakkabi5.RemoveAt(_ayakkabi5.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
            case 14:
                if (_ayakkabi6.Count > 0)
                {
                    _ayakkabi6[_ayakkabi6.Count - 1].transform.parent = null;
                    _ayakkabi6[_ayakkabi6.Count - 1].transform.DOJump(_teslimatNoktasi.transform.position, 3f, 1, 0.5f);
                    _ayakkabi6[_ayakkabi6.Count - 1].transform.DORotate(Vector3.zero, 0.5f);
                    _ayakkabi6[_ayakkabi6.Count - 1].transform.parent = _teslimatNoktasi.transform;
                    _ayakkabi6.RemoveAt(_ayakkabi6.Count - 1);
                    _clientCantadakilerinSayisiIcinListe.RemoveAt(_clientCantadakilerinSayisiIcinListe.Count - 1);
                    CantadakiBosluklariKapatma();
                }

                break;
        }

    }
    public int WorkerAIDoluCantaHedefBulma()
    {
        int a=0;

        if (_hamManda.Count > 0)
        {
            a = 1;
        }
        if (_islenmisManda.Count > 0)
        {
            a = 2;
        }
        if (_hamPamuk.Count > 0)
        {
            a = 3;
        }
        if (_islenmisPamuk.Count > 0)
        {
            a = 4;
        }
        else if(_hamYilan.Count > 0)
        {
            a = 5;

        }
        else if (_islenmisYilan.Count > 0)
        {
            a = 6;
        }
        else if (_hamTimsah.Count > 0)
        {
            a = 7;
        }
        else if (_islenmisTimsah.Count > 0)
        {
            a = 8;
        }
        else if (_ayakkabi1.Count > 0)
        {
            a = 9;
        }
        else if (_ayakkabi2.Count > 0)
        {
            a = 10;
        }
        else if (_ayakkabi3.Count > 0)
        {
            a = 11;
        }
        else if (_ayakkabi4.Count > 0)
        {
            a = 12;
        }
        else if (_ayakkabi5.Count > 0)
        {
            a = 13;
        }
        else if (_ayakkabi6.Count > 0)
        {
            a = 14;
        }
        else
        {
            a = -1;
        }
            return a;
    }

}
