using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KamyonDOMoveHareketNoktasi : MonoBehaviour
{
    [SerializeField] GameObject _kamyonObjs,_yukIndirmekCollideri;
    private int _sayac,_sayac2;
    private bool _ilkseferlik;
    private Animator _kamyonAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _sayac = 0;
        _sayac2 = 0;
        _ilkseferlik = true;
        _kamyonAnimator = _kamyonObjs.transform.parent.gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        
     

            /*_sayac++;
            if (_sayac==2)
            {
               // _kamyonAnimator.SetBool("runreverse", false);
                _ilkseferlik = false;
                _sayac = 0;
                _yukIndirmekCollideri.transform.localScale = _yukIndirmekCollideri.transform.localScale * 2;
            }
            else if (_sayac==1)
            {

                _kamyonAnimator.SetBool("runforward", false);
               // _kamyonAnimator.SetBool("runreverse", true);
                if (_ilkseferlik==false)
                {
                    _yukIndirmekCollideri.transform.localScale = _yukIndirmekCollideri.transform.localScale * 0.5f;
                }

            }*/

       
    }

}
