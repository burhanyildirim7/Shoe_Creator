using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabela : MonoBehaviour
{
    private float _tabela;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _tabela += Time.deltaTime;

        if (_tabela>0.2f)
        {
            if (transform.parent.transform.GetChild(1).gameObject.activeSelf==true)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
            }


        }
    }
}
