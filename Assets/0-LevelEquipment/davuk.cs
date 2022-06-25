using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class davuk : MonoBehaviour
{
    [SerializeField] bool _06Anim,_01Anim;
    // Start is called before the first frame update
    void Start()
    {
        _06Anim = false;
        _01Anim = false;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_01Anim)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            _01Anim = false;
        }
        else if (_06Anim)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            _06Anim = false;
        }
    }
}
