using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FarmerScript : MonoBehaviour
{

    [SerializeField] private GameObject _tarlaNoktasi;
    [SerializeField] private GameObject _ambarNoktasi;

    [SerializeField] private GameObject _bugdayDemeti;

    [SerializeField] private Animator _farmerAnimator;

    [SerializeField] private NavMeshAgent _agent;//ALLLLLL

    private Transform _point;//ALLLLLL

    // Start is called before the first frame update
    private void Awake()
    {
        _point = _ambarNoktasi.transform;
    }
    void Start()
    {
        _bugdayDemeti.SetActive(true);
        _farmerAnimator.SetBool("EliBos", false);
        _farmerAnimator.SetBool("EliDolu", true);

        //_agent.SetDestination(_ambarNoktasi.transform.position);

        _point = _ambarNoktasi.transform;//ALLLLLL---START POINTI VERILMESI GEREKIYOR-YOKSA HATA VERIR-POINT BOS KALMAMAMLI NAVMESHIN OZELLIGI
    }

    private void Update()//ALLLLLL--UPDATTE CALISCAK FIXEDUPDATE
    {
        if (GameController.instance.isContinue == true)//ALLLLLL
        {
            SetDestination(_point);
        }
    }

    public void Resetle()
    {
        _bugdayDemeti.SetActive(true);
        _farmerAnimator.SetBool("EliBos", false);
        _farmerAnimator.SetBool("EliDolu", true);

        //_agent.SetDestination(_ambarNoktasi.transform.position);

        _point = _ambarNoktasi.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _ambarNoktasi)
        {
            _bugdayDemeti.SetActive(false);
            _farmerAnimator.SetBool("EliDolu", false);
            _farmerAnimator.SetBool("EliBos", true);
            _point = _tarlaNoktasi.transform;
            //SetDestination(_tarlaNoktasi.transform);
            //_agent.SetDestination(_tarlaNoktasi.transform.position);
            Debug.Log("Ambarda");
        }
        else if (other.gameObject == _tarlaNoktasi)
        {
            _bugdayDemeti.SetActive(true);
            _farmerAnimator.SetBool("EliBos", false);
            _farmerAnimator.SetBool("EliDolu", true);
            _point = _ambarNoktasi.transform;
            //SetDestination(_ambarNoktasi.transform);
            //_agent.SetDestination(_ambarNoktasi.transform.position);

            Debug.Log("Tarlada");
        }
        else
        {

        }
    }


    private void SetDestination(Transform point)//ALLLLLL
    {
        _agent.SetDestination(point.position);
    }
}
