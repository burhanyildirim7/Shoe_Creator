using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoardingController : MonoBehaviour
{

    [SerializeField] private GameObject _onBoardingOku;
    [SerializeField] private GameObject _stuffKonum,
                                        _sezlongKonum;
    [SerializeField] private GameObject _hamMandaDerisi,
        _islemeMakinesiGiris;
    [SerializeField]
    private GameObject
        _islemeCikis,
        _ayakkabiMakinesiGiris;
    [SerializeField]
    private GameObject
        _ayakkabimakinesiCikis,
        _reyon;

    private CameraMovement _cameraMovement;


    void Start()
    {
        _cameraMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
        _onBoardingOku.SetActive(false);

        //StartCoroutine(StartOnBoarding());
    }

    public IEnumerator StartOnBoarding()
    {
        GameController.instance._kameraHareketli = true;

        _cameraMovement.KamerayiYonlendir(_stuffKonum);

        _onBoardingOku.transform.position = new Vector3(_stuffKonum.transform.position.x,2, _stuffKonum.transform.position.z);
        _onBoardingOku.SetActive(true);

        yield return new WaitForSeconds(3f);

        _cameraMovement.KamerayiYonlendir(_sezlongKonum);

        _onBoardingOku.transform.position = new Vector3(_sezlongKonum.transform.position.x,0, _sezlongKonum.transform.position.z);

        yield return new WaitForSeconds(3f);

        _onBoardingOku.SetActive(false);

        _cameraMovement.KamerayiResetle();

        GameController.instance._kameraHareketli = false;

    }
    public IEnumerator HamDeriIsleme()
    {
        GameController.instance._kameraHareketli = true;

        _cameraMovement.KamerayiYonlendir(_hamMandaDerisi);

        _onBoardingOku.transform.position = new Vector3(_hamMandaDerisi.transform.position.x, 0, _hamMandaDerisi.transform.position.z);
        _onBoardingOku.SetActive(true);

        yield return new WaitForSeconds(3f);

        _cameraMovement.KamerayiYonlendir(_islemeMakinesiGiris);

        _onBoardingOku.transform.position = new Vector3(_islemeMakinesiGiris.transform.position.x, 0, _islemeMakinesiGiris.transform.position.z);

        yield return new WaitForSeconds(3f);

        _onBoardingOku.SetActive(false);

        _cameraMovement.KamerayiResetle();

        GameController.instance._kameraHareketli = false;

    }
    public IEnumerator AyakkabiUretimi()
    {
        GameController.instance._kameraHareketli = true;

        _cameraMovement.KamerayiYonlendir(_islemeCikis);

        _onBoardingOku.transform.position = new Vector3(_islemeCikis.transform.position.x, 0, _islemeCikis.transform.position.z);
        _onBoardingOku.SetActive(true);

        yield return new WaitForSeconds(3f);

        _cameraMovement.KamerayiYonlendir(_ayakkabiMakinesiGiris);

        _onBoardingOku.transform.position = new Vector3(_ayakkabiMakinesiGiris.transform.position.x, 0, _ayakkabiMakinesiGiris.transform.position.z);

        yield return new WaitForSeconds(3f);

        _onBoardingOku.SetActive(false);

        _cameraMovement.KamerayiResetle();

        GameController.instance._kameraHareketli = false;

    }
    public IEnumerator reyonaTasi()
    {
        GameController.instance._kameraHareketli = true;

        _cameraMovement.KamerayiYonlendir(_ayakkabimakinesiCikis);

        _onBoardingOku.transform.position = new Vector3(_ayakkabimakinesiCikis.transform.position.x,0, _ayakkabimakinesiCikis.transform.position.z);
        _onBoardingOku.SetActive(true);

        yield return new WaitForSeconds(3f);

        _cameraMovement.KamerayiYonlendir(_reyon);

        _onBoardingOku.transform.position = new Vector3(_reyon.transform.position.x,0, _reyon.transform.position.z);

        yield return new WaitForSeconds(3f);

        _onBoardingOku.SetActive(false);

        _cameraMovement.KamerayiResetle();

        GameController.instance._kameraHareketli = false;

    }







}
