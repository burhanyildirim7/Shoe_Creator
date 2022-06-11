using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SirtCantasiScript : MonoBehaviour
{
    [Header("Objeler Toplandiğinda Parent Atanacak Obje")]
    public GameObject _sirtCantasiObject;
    [Header("Objelerin Yerlesecegi Transform Listesi")]
    public List<Transform> _yerlesmeNoktalari = new List<Transform>();
    [Header("Cantada Bulunan Objelerin Tamami")]
    public List<GameObject> _cantadakiObjeler = new List<GameObject>();
    [Header("Cantada Bulunan Saman Objeleri")]
    public List<GameObject> _cantadakiSamanObjeleri = new List<GameObject>();
    public List<GameObject> _cantadakiAltinObjeleri = new List<GameObject>();
    public List<GameObject> _cantadakiEtObjeleri = new List<GameObject>();
    public List<GameObject> _cantadakiDemirObjeleri = new List<GameObject>();
    [Header("Textler")]
    [SerializeField] private Text _samanSayisiText;
    [SerializeField] private Text _altinSayisiText;
    [SerializeField] private Text _etSayisiText;
    [SerializeField] private Text _demirSayisiText;


    private int _cantadakiObjeSayisi;

    public static bool _kasapVar;
    public static bool _kilicVar;
    public static bool _ilkTarlaAktif;

    void Start()
    {
        _cantadakiObjeSayisi = 0;
        _samanSayisiText.text = _cantadakiSamanObjeleri.Count.ToString();
        _altinSayisiText.text = _cantadakiAltinObjeleri.Count.ToString();
        _etSayisiText.text = _cantadakiEtObjeleri.Count.ToString();
        _demirSayisiText.text = _cantadakiDemirObjeleri.Count.ToString();
        _kilicVar = false;
        _ilkTarlaAktif = false;

    }

    private void FixedUpdate()
    {
        CantayiDüzenle();
        CantayiHizala();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SamanBalyasi")
        {
            if (_cantadakiObjeler.Count < _yerlesmeNoktalari.Count)
            {
                other.gameObject.transform.parent = _sirtCantasiObject.transform;
                _cantadakiObjeler.Add(other.gameObject);
                _cantadakiSamanObjeleri.Add(other.gameObject);
                other.gameObject.tag = "ToplanmisSamanBalyasi";

                _samanSayisiText.text = _cantadakiSamanObjeleri.Count.ToString();

                int sira = _cantadakiObjeSayisi;
                other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.5f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f));
                other.gameObject.transform.DOLocalRotate(Vector3.zero, 1);
                _cantadakiObjeSayisi++;

                MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

                if (GameObject.FindGameObjectWithTag("Ambar") != null)
                {
                    AmbarSpawnScript _ambarSpawnScript = GameObject.FindGameObjectWithTag("Ambar").GetComponent<AmbarSpawnScript>();

                    if (_ambarSpawnScript._ambarUrunSayisi > 0)
                    {
                        _ambarSpawnScript._ambarUrunSayisi--;
                    }
                    else
                    {

                    }
                }
                else
                {

                }



            }
            else
            {

            }


            //Debug.Log("Saman Balyasi Alindi");
        }
        else if (other.gameObject.tag == "Altin")
        {
            if (_cantadakiObjeler.Count < _yerlesmeNoktalari.Count)
            {
                other.gameObject.transform.parent = _sirtCantasiObject.transform;
                _cantadakiObjeler.Add(other.gameObject);
                _cantadakiAltinObjeleri.Add(other.gameObject);
                other.gameObject.tag = "ToplanmisAltin";

                _altinSayisiText.text = _cantadakiAltinObjeleri.Count.ToString();

                int sira = _cantadakiObjeSayisi;
                other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.5f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f));
                other.gameObject.transform.DOLocalRotate(Vector3.zero, 1);
                _cantadakiObjeSayisi++;

                MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

                if (GameObject.FindGameObjectWithTag("AltinMadeni") != null)
                {
                    AltinMadeniSpawnScript _altinMadeniSpawnScript = GameObject.FindGameObjectWithTag("AltinMadeni").GetComponent<AltinMadeniSpawnScript>();

                    if (_altinMadeniSpawnScript._ambarUrunSayisi > 0)
                    {
                        _altinMadeniSpawnScript._ambarUrunSayisi--;
                    }
                    else
                    {

                    }
                }
                else
                {

                }



            }
            else
            {

            }
        }
        else if (other.gameObject.tag == "Et")
        {
            if (_cantadakiObjeler.Count < _yerlesmeNoktalari.Count)
            {
                other.gameObject.transform.parent = _sirtCantasiObject.transform;
                _cantadakiObjeler.Add(other.gameObject);
                _cantadakiEtObjeleri.Add(other.gameObject);
                other.gameObject.tag = "ToplanmisEt";

                _etSayisiText.text = _cantadakiEtObjeleri.Count.ToString();

                int sira = _cantadakiObjeSayisi;
                other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.5f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f));
                other.gameObject.transform.DOLocalRotate(Vector3.zero, 1);
                _cantadakiObjeSayisi++;

                MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

                if (GameObject.FindGameObjectWithTag("Kasap") != null)
                {
                    KasapSpawnScript _kasapSpawnScript = GameObject.FindGameObjectWithTag("Kasap").GetComponent<KasapSpawnScript>();

                    if (_kasapSpawnScript._ambarUrunSayisi > 0)
                    {
                        _kasapSpawnScript._ambarUrunSayisi--;
                    }
                    else
                    {

                    }
                }
                else
                {

                }



            }
            else
            {

            }
        }
        else if (other.gameObject.tag == "Demir")
        {
            if (_cantadakiObjeler.Count < _yerlesmeNoktalari.Count)
            {
                other.gameObject.transform.parent = _sirtCantasiObject.transform;
                _cantadakiObjeler.Add(other.gameObject);
                _cantadakiDemirObjeleri.Add(other.gameObject);
                other.gameObject.tag = "ToplanmisDemir";

                _demirSayisiText.text = _cantadakiDemirObjeleri.Count.ToString();

                int sira = _cantadakiObjeSayisi;
                other.gameObject.transform.DOLocalMove(new Vector3(_yerlesmeNoktalari[sira].localPosition.x, _yerlesmeNoktalari[sira].localPosition.y + 0.5f, _yerlesmeNoktalari[sira].localPosition.z - 0.5f), 0.5f).OnComplete(() => other.gameObject.transform.DOLocalMove(_yerlesmeNoktalari[sira].localPosition, 0.5f));
                other.gameObject.transform.DOLocalRotate(Vector3.zero, 1);
                _cantadakiObjeSayisi++;

                MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

                if (GameObject.FindGameObjectWithTag("DemirMadeni") != null)
                {
                    DemirMadeniSpawnScript _demirMadeniSpawnScript = GameObject.FindGameObjectWithTag("DemirMadeni").GetComponent<DemirMadeniSpawnScript>();

                    if (_demirMadeniSpawnScript._ambarUrunSayisi > 0)
                    {
                        _demirMadeniSpawnScript._ambarUrunSayisi--;
                    }
                    else
                    {

                    }
                }
                else
                {

                }



            }
            else
            {

            }
        }
    }

    public void SamanCek(Transform malKabulNoktasi)
    {
        if (_cantadakiSamanObjeleri.Count > 0)
        {
            int sira = _cantadakiSamanObjeleri.Count - 1;
            _cantadakiSamanObjeleri[_cantadakiSamanObjeleri.Count - 1].gameObject.transform.parent = null;
            _cantadakiSamanObjeleri[_cantadakiSamanObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiSamanObjeleri[_cantadakiSamanObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            _cantadakiSamanObjeleri.RemoveAt(_cantadakiSamanObjeleri.Count - 1);
            _cantadakiObjeSayisi--;
            _samanSayisiText.text = _cantadakiSamanObjeleri.Count.ToString();

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            //CantayiDüzenle();

        }
        else
        {

        }
    }

    public void AltinCek(Transform malKabulNoktasi)
    {
        if (_cantadakiAltinObjeleri.Count > 0)
        {
            int sira = _cantadakiAltinObjeleri.Count - 1;
            _cantadakiAltinObjeleri[_cantadakiAltinObjeleri.Count - 1].gameObject.transform.parent = null;
            _cantadakiAltinObjeleri[_cantadakiAltinObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiAltinObjeleri[_cantadakiAltinObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            _cantadakiAltinObjeleri.RemoveAt(_cantadakiAltinObjeleri.Count - 1);
            _cantadakiObjeSayisi--;
            _altinSayisiText.text = _cantadakiAltinObjeleri.Count.ToString();

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            //CantayiDüzenle();

        }
        else
        {

        }
    }

    public void EtCek(Transform malKabulNoktasi)
    {
        if (_cantadakiEtObjeleri.Count > 0)
        {
            int sira = _cantadakiEtObjeleri.Count - 1;
            _cantadakiEtObjeleri[_cantadakiEtObjeleri.Count - 1].gameObject.transform.parent = null;
            _cantadakiEtObjeleri[_cantadakiEtObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiEtObjeleri[_cantadakiEtObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            _cantadakiEtObjeleri.RemoveAt(_cantadakiEtObjeleri.Count - 1);
            _cantadakiObjeSayisi--;
            _etSayisiText.text = _cantadakiEtObjeleri.Count.ToString();

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            //CantayiDüzenle();

        }
        else
        {

        }
    }

    public void DemirCek(Transform malKabulNoktasi)
    {
        if (_cantadakiDemirObjeleri.Count > 0)
        {
            int sira = _cantadakiDemirObjeleri.Count - 1;
            _cantadakiDemirObjeleri[_cantadakiDemirObjeleri.Count - 1].gameObject.transform.parent = null;
            _cantadakiDemirObjeleri[_cantadakiDemirObjeleri.Count - 1].gameObject.transform.DOMove(malKabulNoktasi.position, 0.5f);
            _cantadakiDemirObjeleri[_cantadakiDemirObjeleri.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            _cantadakiDemirObjeleri.RemoveAt(_cantadakiDemirObjeleri.Count - 1);
            _cantadakiObjeSayisi--;
            _demirSayisiText.text = _cantadakiDemirObjeleri.Count.ToString();

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            //CantayiDüzenle();

        }
        else
        {

        }
    }

    private void CantayiDüzenle()
    {
        for (int i = 0; i < _cantadakiObjeler.Count; i++)
        {
            if (_cantadakiObjeler[i] == null)
            {
                _cantadakiObjeler.RemoveAt(i);
            }
            else
            {

            }
        }



    }

    private void CantayiHizala()
    {
        for (int i = 0; i < _sirtCantasiObject.transform.childCount; i++)
        {
            _sirtCantasiObject.transform.GetChild(i).transform.position = _yerlesmeNoktalari[i].transform.position;
        }



    }

    public void SirtCantasiLevelStart()
    {
        int cantadakiobjesayi = _cantadakiObjeler.Count;
        for (int i = 0; i < cantadakiobjesayi; i++)
        {
            Destroy(_cantadakiObjeler[0].gameObject);
            _cantadakiObjeler.RemoveAt(0);

        }

        int cantadakisamanobjesayi = _cantadakiSamanObjeleri.Count;
        for (int i = 0; i < cantadakisamanobjesayi; i++)
        {
            Destroy(_cantadakiSamanObjeleri[0].gameObject);
            _cantadakiSamanObjeleri.RemoveAt(0);

        }

        int cantadakialtinobjesayi = _cantadakiAltinObjeleri.Count;
        for (int i = 0; i < cantadakialtinobjesayi; i++)
        {
            Destroy(_cantadakiAltinObjeleri[0].gameObject);
            _cantadakiAltinObjeleri.RemoveAt(0);

        }

        int cantadakietobjesayi = _cantadakiEtObjeleri.Count;
        for (int i = 0; i < cantadakietobjesayi; i++)
        {
            Destroy(_cantadakiEtObjeleri[0].gameObject);
            _cantadakiEtObjeleri.RemoveAt(0);

        }

        int cantadakidemirobjesayi = _cantadakiDemirObjeleri.Count;
        for (int i = 0; i < cantadakidemirobjesayi; i++)
        {
            Destroy(_cantadakiDemirObjeleri[0].gameObject);
            _cantadakiDemirObjeleri.RemoveAt(0);

        }

        _cantadakiObjeSayisi = 0;

        _ilkTarlaAktif = false;

        _samanSayisiText.text = _cantadakiSamanObjeleri.Count.ToString();
        _altinSayisiText.text = _cantadakiAltinObjeleri.Count.ToString();
        _etSayisiText.text = _cantadakiEtObjeleri.Count.ToString();
        _demirSayisiText.text = _cantadakiDemirObjeleri.Count.ToString();
    }
}
