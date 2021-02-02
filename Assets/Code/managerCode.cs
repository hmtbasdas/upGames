using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class managerCode : MonoBehaviour
{
    public Button[] levelsButton;
    public TextMeshProUGUI[] levelsText;
    public GameObject[] levelsLock;

    public GameObject shopPanel;
    public GameObject settingsPanel;

    public TextMeshProUGUI orjGold;

    //adsMenu adsMenu;
    public bool control = true;
    public GameObject selectedBall;

    public Toggle sToggle;
    public Toggle vToggle;
    public GameObject resetPanel;
    public Button close;
    public AudioSource click;
    public AudioSource purchaseSound;

    public GameObject tickTr;
    public GameObject tickUs;
    public GameObject ConnectionObject;
    public Sprite connT;
    public Sprite connF;
    void Start()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            ConnectionObject.GetComponent<Image>().sprite = connF;
        }
        else
        {
            ConnectionObject.GetComponent<Image>().sprite = connT;
        }
        
        if (!PlayerPrefs.HasKey("lng"))
        {
            PlayerPrefs.SetInt("lng",1);
        }
        Debug.Log("dil : " + PlayerPrefs.GetInt("lng"));
        if (!PlayerPrefs.HasKey("SelectedBall"))
        {
            PlayerPrefs.SetString("SelectedBall", "ball0");
        }

        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }

        for (int i=0;i<=PlayerPrefs.GetInt("Level");i++)
        {
            levelsButton[i].interactable = true;
            levelsText[i].enabled = true;
            levelsLock[i].SetActive(false);
        }
        if (PlayerPrefs.GetInt("lng") == 1)
        {
            if (PlayerPrefs.GetInt("Gold") <= 9)
            {
                orjGold.text = "Gold : 00" + PlayerPrefs.GetInt("Gold").ToString();
            }
            if (PlayerPrefs.GetInt("Gold") <= 99 && PlayerPrefs.GetInt("Gold") >= 10)
            {
                orjGold.text = "Gold : 0" + PlayerPrefs.GetInt("Gold").ToString();
            }
            if (PlayerPrefs.GetInt("Gold") <= 999 && PlayerPrefs.GetInt("Gold") >= 100)
            {
                orjGold.text = "Gold : " + PlayerPrefs.GetInt("Gold").ToString();
            }
        }
        if (PlayerPrefs.GetInt("lng") == 0)
        {
            if (PlayerPrefs.GetInt("Gold") <= 9)
            {
                orjGold.text = "ALtın : 00" + PlayerPrefs.GetInt("Gold").ToString();
            }
            if (PlayerPrefs.GetInt("Gold") <= 99 && PlayerPrefs.GetInt("Gold") >= 10)
            {
                orjGold.text = "Altın : 0" + PlayerPrefs.GetInt("Gold").ToString();
            }
            if (PlayerPrefs.GetInt("Gold") <= 999 && PlayerPrefs.GetInt("Gold") >= 100)
            {
                orjGold.text = "Altın : " + PlayerPrefs.GetInt("Gold").ToString();
            }
        }



        if (!PlayerPrefs.HasKey("sToggle") || !PlayerPrefs.HasKey("vToggle"))
        {
            PlayerPrefs.SetInt("sToggle", 1);
            PlayerPrefs.SetInt("vToggle", 1);
        }

        if (PlayerPrefs.GetInt("lng") == 1)
        {
            GameObject.Find("freeGoldText").GetComponent<TextMeshProUGUI>().text = "Free Gold!";

            GameObject.Find("likeText").GetComponent<TextMeshProUGUI>().text = "Rate Our App";
            GameObject.Find("settingsText").GetComponent<TextMeshProUGUI>().text = "Settings";
            GameObject.Find("shopText").GetComponent<TextMeshProUGUI>().text = "Shop";
        }
        if (PlayerPrefs.GetInt("lng") == 0)
        {
            GameObject.Find("freeGoldText").GetComponent<TextMeshProUGUI>().text = "Bedava Altın!";

            GameObject.Find("likeText").GetComponent<TextMeshProUGUI>().text = "Beğendiniz mi ?";
            GameObject.Find("settingsText").GetComponent<TextMeshProUGUI>().text = "Ayarlar";
            GameObject.Find("shopText").GetComponent<TextMeshProUGUI>().text = "Mağaza";
        }
    }
    public void switchLG(string lng)
    {
        if (lng == "tr")
        {
            PlayerPrefs.SetInt("lng", 0);
            tickTr.SetActive(true);
            tickUs.SetActive(false);
            SceneManager.LoadScene(0);
        }
        if (lng == "us")
        {
            PlayerPrefs.SetInt("lng", 1);
            tickTr.SetActive(false);
            tickUs.SetActive(true);
            SceneManager.LoadScene(0);
        }
    }
    public void goUrl()
    {
        if (PlayerPrefs.GetInt("sToggle") == 1)
        {
            click.Play();
        }
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ScutoidGames.UP!&hl=tr"); //UP! olarak değişecek
    }
    public void paraEkle()
    {
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 20);
        control = true;
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void startLevel(int level)
    {
        if (PlayerPrefs.GetInt("sToggle") == 1)
        {
            click.Play();
        }
        if (PlayerPrefs.GetInt("sToggle") == 1)
        {
            click.Play();
        }
        PlayerPrefs.SetInt("startLevel",level);
    }
    public void settings()
    {
        if (PlayerPrefs.GetInt("lng") == 1)
        {
            tickUs.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lng") == 0)
        {
            tickTr.SetActive(true);
        }

        if (PlayerPrefs.GetInt("sToggle") == 1)
        {
            click.Play();
        }
        settingsPanel.SetActive(true);

        if (settingsPanel.activeSelf)
        {
            if (PlayerPrefs.GetInt("lng") == 1)
            {
                GameObject.Find("titleSettings").GetComponent<TextMeshProUGUI>().text = "Settings";
                GameObject.Find("effect").GetComponent<TextMeshProUGUI>().text = "Sounds";
                GameObject.Find("vibration").GetComponent<TextMeshProUGUI>().text = "Vibration";
                GameObject.Find("lng").GetComponent<TextMeshProUGUI>().text = "Language";
                GameObject.Find("rest").GetComponent<TextMeshProUGUI>().text = "Reset Game!";
            }
            if (PlayerPrefs.GetInt("lng") == 0)
            {
                GameObject.Find("titleSettings").GetComponent<TextMeshProUGUI>().text = "Ayarlar";
                GameObject.Find("effect").GetComponent<TextMeshProUGUI>().text = "Sesler";
                GameObject.Find("vibration").GetComponent<TextMeshProUGUI>().text = "Titresim";
                GameObject.Find("lng").GetComponent<TextMeshProUGUI>().text = "Dil";
                GameObject.Find("rest").GetComponent<TextMeshProUGUI>().text = "Oyunu Sıfırla!";
            }

        }
        if (PlayerPrefs.GetInt("sToggle") == 1)
        {
            sToggle.isOn = true;
        }
        else
        {
            sToggle.isOn = false;
        }

        if (PlayerPrefs.GetInt("vToggle") == 1)
        {
            vToggle.isOn = true;
        }
        else
        {
            vToggle.isOn = false;
        }
    }
    public void shop()
    {
        if (PlayerPrefs.GetInt("sToggle") == 1)
        {
            click.Play();
        }
        shopPanel.SetActive(true);

        if (shopPanel.activeSelf)
        {
            if (PlayerPrefs.GetInt("lng") == 1)
            {
                GameObject.Find("titleShop").GetComponent<TextMeshProUGUI>().text = "SHOP";
                GameObject.Find("freeGoldTextShop").GetComponent<TextMeshProUGUI>().text = "Free Gold!";

                GameObject.Find("ball0T").GetComponent<TextMeshProUGUI>().text = "OWNED";
                for (int i=1;i<=5;i++)
                {
                    if (PlayerPrefs.GetInt("ball" + i.ToString()) == 0)
                    {
                        GameObject.Find("ball" + i.ToString() + "T").GetComponent<TextMeshProUGUI>().text = "20 Gold";
                    }
                }
                for (int i = 6; i <= 7; i++)
                {
                    if (PlayerPrefs.GetInt("ball" + i.ToString()) == 0)
                    {
                        GameObject.Find("ball" + i.ToString() + "T").GetComponent<TextMeshProUGUI>().text = "30 Gold";
                    }
                }
            }
            if (PlayerPrefs.GetInt("lng") == 0)
            {
                GameObject.Find("titleShop").GetComponent<TextMeshProUGUI>().text = "MARKET";
                GameObject.Find("freeGoldTextShop").GetComponent<TextMeshProUGUI>().text = "Bedava Altın!";

                GameObject.Find("ball0T").GetComponent<TextMeshProUGUI>().text = "ALINDI";
                for (int i = 1; i <= 5; i++)
                {
                    if (PlayerPrefs.GetInt("ball" + i.ToString()) == 0)
                    {
                        GameObject.Find("ball" + i.ToString() + "T").GetComponent<TextMeshProUGUI>().text = "20 Altın";
                    }
                }
                for (int i = 6; i <= 7; i++)
                {
                    if (PlayerPrefs.GetInt("ball" + i.ToString()) == 0)
                    {
                        GameObject.Find("ball" + i.ToString() + "T").GetComponent<TextMeshProUGUI>().text = "30 Altın";
                    }
                }
            }
            
        }

        selectedBall.GetComponent<Image>().sprite = GameObject.Find(PlayerPrefs.GetString("SelectedBall")).GetComponent<Image>().sprite;
        PlayerPrefs.SetInt("ball0", 1);
        for (int i = 0; i <= 7; i++)
        {
            if (PlayerPrefs.GetInt("ball" + i.ToString()) == 1)
            {
                if (PlayerPrefs.GetInt("lng") == 1)
                {
                    GameObject.Find("ball" + i.ToString() + "T").GetComponent<TextMeshProUGUI>().text = "Owned";
                }
                if (PlayerPrefs.GetInt("lng") == 0)
                {
                    GameObject.Find("ball" + i.ToString() + "T").GetComponent<TextMeshProUGUI>().text = "Alındı";
                }

                GameObject.Find("ball" + i.ToString() + "B").GetComponent<Button>().interactable = false;
            }
        }
        GameObject.Find(PlayerPrefs.GetString("SelectedBall")).GetComponent<Button>().interactable = false;
    }
    public void closePanel()
    {
        if (PlayerPrefs.GetInt("sToggle") == 1)
        {
            click.Play();
        }
        shopPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void purchase(string name)
    {
        int price = int.Parse(GameObject.Find(name).GetComponent<TextMeshProUGUI>().text.Substring(0,2));
        Debug.Log(price);
        Debug.Log(name.Substring(0, 5));
        if (PlayerPrefs.GetInt("Gold") >= price)
        {
            if (PlayerPrefs.GetInt("sToggle") == 1)
            {
                purchaseSound.Play();
            }
            if (PlayerPrefs.GetInt("lng") == 1)
            {
                GameObject.Find(name).GetComponent<TextMeshProUGUI>().text = "Owned";
            }
            if (PlayerPrefs.GetInt("lng") == 0)
            {
                GameObject.Find(name).GetComponent<TextMeshProUGUI>().text = "Alındı";
            }
            
            GameObject.Find(name.Substring(0, 5) + "B").GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("Gold",PlayerPrefs.GetInt("Gold") - price);
            PlayerPrefs.SetInt(name.Substring(0, 5), 1);
            
            control = true;
        }
    }
    public void switchBall(string ballName)
    {
        
        if (PlayerPrefs.GetInt(ballName) == 1)
        {
            if (PlayerPrefs.GetInt("sToggle") == 1)
            {
                click.Play();
            }
            GameObject.Find(ballName).GetComponent<Button>().interactable = false;
            selectedBall.GetComponent<Image>().sprite = GameObject.Find(ballName).GetComponent<Image>().sprite;
            PlayerPrefs.SetString("SelectedBall",ballName);
            for (int i = 0; i <= 7; i++)
            {
                if ("ball" + i.ToString() != ballName)
                {
                    GameObject.Find("ball" + i.ToString()).GetComponent<Button>().interactable = true;
                }
            }
        }
    }
    public void soundsToggle()
    {
        if (sToggle.isOn)
        {
            PlayerPrefs.SetInt("sToggle", 1);
        }
        else
        {
            PlayerPrefs.SetInt("sToggle", 0);
        }
    }
    public void vibrateToggle()
    {
        if (vToggle.isOn)
        {
            PlayerPrefs.SetInt("vToggle", 1);
        }
        else
        {
            PlayerPrefs.SetInt("vToggle", 0);
        }
    }
    void Update()
    {
        if (control)
        {
            Start();
            control = false;
        }
    }
    public void ResetPanel()
    {
        if (PlayerPrefs.GetInt("sToggle") == 1)
        {
            click.Play();
        }
        resetPanel.SetActive(true);

        if (resetPanel.activeSelf)
        {
            if (PlayerPrefs.GetInt("lng") == 1)
            {
                GameObject.Find("question").GetComponent<TextMeshProUGUI>().text = "Are You Sure ?";
                GameObject.Find("warning").GetComponent<TextMeshProUGUI>().text = "This operation cannot be undone!";
                GameObject.Find("yesText").GetComponent<TextMeshProUGUI>().text = "YES";
                GameObject.Find("noText").GetComponent<TextMeshProUGUI>().text = "NO";
            }
            if (PlayerPrefs.GetInt("lng") == 0)
            {
                GameObject.Find("question").GetComponent<TextMeshProUGUI>().text = "Emin misin ?";
                GameObject.Find("warning").GetComponent<TextMeshProUGUI>().text = "Bu işlem geri alınamaz!";
                GameObject.Find("yesText").GetComponent<TextMeshProUGUI>().text = "EVET";
                GameObject.Find("noText").GetComponent<TextMeshProUGUI>().text = "HAYIR";
            }
        }
        close.interactable = false;
    }
    public void ResetPanelH()
    {
        resetPanel.SetActive(false);
        close.interactable = true;
    }
    public void ResetPanelE()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
