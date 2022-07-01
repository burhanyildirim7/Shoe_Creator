using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance; // Singleton yapisi icin gerekli ornek

    public GameObject TapToStartPanel, GamePanel, _upgradePanel;
    public Text gamePlayScoreText, tapToStartScoreText;

    //[SerializeField] private GameObject _paraObject;


    // singleton yapisi burada kuruluyor.
    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);
    }

    private void Start()
    {
        StartUI();


    }

    // Oyun ilk acildiginda calisacak olan ui fonksiyonu. 
    public void StartUI()
    {
        ActivateTapToStartScreen();
    }



    /// <summary>
    /// Level numarasini ui kisminda degistirmek icin fonksiyon. Parametre olarak level numarasi aliyor.
    /// </summary>
    /// <param name="levelNo">UI ekranina yazilmak istenen Level numaras?</param>


    // TAPTOSTART TUSUNA BASILDISINDA  --- GIRIS EKRANINDA VE LEVEL BASLARINDA
    public void TapToStartButtonClick()
    {

        GameController.instance.isContinue = true;
        //PlayerController.instance.SetArmForGaming();
        TapToStartPanel.SetActive(false);
        GamePanel.SetActive(true);
        //SetLevelText(LevelController.instance.totalLevelNo);
        SetGamePlayScoreText();


        if (PlayerPrefs.GetInt("HediyeParaVerildi") < 1)
        {
            //_paraObject.SetActive(true);
            StartCoroutine(GameObject.FindGameObjectWithTag("OnBoardingController").GetComponent<OnBoardingController>().StartOnBoarding());
            PlayerPrefs.SetInt("HediyeParaVerildi", 1);
        }
        else
        {
            //_paraObject.SetActive(false);
        }
        /*
        if (PlayerPrefs.GetInt("AcilisSenaryosu") < 1)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("OnBoardingController").GetComponent<OnBoardingController>().StartOnBoarding());
            PlayerPrefs.SetInt("AcilisSenaryosu", 1);
        }
        else
        {

        }
        */

    }

    // RESTART TUSUNA BASILDISINDA  --- LOOSE EKRANINDA
    public void RestartButtonClick()
    {
        GamePanel.SetActive(false);
        //LoosePanel.SetActive(false);
        TapToStartPanel.SetActive(true);
        //LevelController.instance.RestartLevelEvents();
        SetTapToStartScoreText();
    }


    // NEXT LEVEL TUSUNA BASILDIGINDA... WIN EKRANINDAKI BUTON
    public void NextLevelButtonClick()
    {
        SetTapToStartScoreText();
        TapToStartPanel.SetActive(true);
        //WinPanel.SetActive(false);
        GamePanel.SetActive(false);
        //LevelController.instance.NextLevelEvents();
        //StartCoroutine(StartScreenCoinEffect());
    }


    /// <summary>
    /// Bu fonksiyon gameplay ekranindaki score textini gunceller.
    /// </summary>
    public void SetGamePlayScoreText()
    {
        gamePlayScoreText.text = PlayerPrefs.GetInt("Money").ToString();
    }


    /// <summary>
    /// Bu fonksiyon totalScore un yazilmasi gereken textleri gunceller.
    /// </summary>
    public void SetTapToStartScoreText()
    {
        tapToStartScoreText.text = PlayerPrefs.GetInt("Money").ToString();
    }

    /// <summary>
    /// Bu fonksiyon winscreen de ge?erli level scoreunun yazildigi texti gunceller.
    /// </summary>
    public void WinScreenScore()
    {
        //winScreenScoreText.text = GameController.instance.score.ToString();
    }

    /// <summary>
    /// Bu fonksiyon totalElmas sayilarinin yazildigi textleri gunceller.
    /// </summary>
    public void SetTotalElmasText()
    {
        //totalElmasText.text = PlayerPrefs.GetInt("totalElmas").ToString();
    }

    /// <summary>
    /// Bu fonksiyon winscreen ekranini acar.
    /// </summary>
    public void ActivateWinScreen()
    {
        GamePanel.SetActive(false);
        //StartCoroutine(WinScreenDelay());
    }

    /// <summary>
    /// Bu fonksiyon loose secreeni acar. 
    /// </summary>
    public void ActivateLooseScreen()
    {
        GamePanel.SetActive(false);
        //LoosePanel.SetActive(true);
    }


    /// <summary>
    /// Bu fonksiyon gamescreeni acar.
    /// </summary>
    public void ActivateGameScreen()
    {
        GamePanel.SetActive(true);
        TapToStartPanel.SetActive(false);
        SetGamePlayScoreText();
    }

    /// <summary>
    /// Bu fonksiyon taptostartscreen i acar.
    /// </summary>
    public void ActivateTapToStartScreen()
    {
        TapToStartPanel.SetActive(true);
        //WinPanel.SetActive(false);
        //LoosePanel.SetActive(false);
        GamePanel.SetActive(false);
        SetTapToStartScoreText();
        tapToStartScoreText.text = PlayerPrefs.GetInt("Money").ToString();
    }





}
