using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyGrubuKontrolu : MonoBehaviour
{
    public bool paraEklensinMi=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (paraEklensinMi==true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeSelf == false)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                    paraEklensinMi = false;
                    break;
                }

            }

        }
    }




}
