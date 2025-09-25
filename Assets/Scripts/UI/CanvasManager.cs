using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject GM;
    [SerializeField] GameObject player;
    [SerializeField] Image[] hp;
    [SerializeField] GameObject vic1Panel;
    [SerializeField] GameObject vic2Panel;
    [SerializeField] GameObject vic3Panel;
    [SerializeField] GameObject GOPanel;
    [SerializeField] GameObject PausePanel;

    [SerializeField] TextMeshProUGUI timerText;    
    float playerHP;
    public float timer;
    int lv;
    float count;
    public bool isDone;
    void Start()
    {
        
    }
    
    void Update()
    {    
        lv = GM.GetComponent<GM>().lv;
        UpdateHP();
        if (lv == 1 && !isDone) UpdateTimer1();
        if (lv == 2 && !isDone) UpdateTimer2();
        if (lv == 3 && !isDone) UpdateTimer3();
        if (player.GetComponent<PlayerLife>().isDead)
        {
            GOPanel.SetActive(true);
        }
    }


    void UpdateHP()
    {
        if (player != null)
        {
            playerHP = player.GetComponent<PlayerLife>().hp;
        }

        for (int i = 0; i < hp.Length; i++)
        {
            hp[i].enabled = (i < playerHP);
        }
    }

    void UpdateTimer1()
    {
        timer = GM.GetComponent<LV1>().timer;
        UT();
    }


    void UpdateTimer2()
    {
        timer = GM.GetComponent<LV2>().timer;
        UT();
    }

    void UpdateTimer3()
    {
        timer = GM.GetComponent<LV3>().timer;
        UT();
    }

    void UT()
    {
        if (timer > 0)
        {
            count = Time.time;
        }
        if (timer >= 0)
        {
            timerText.text = timer.ToString();
        }
        if (timer == 0)
        {
            if (Time.time >= count + 3f)
            {
                if (lv == 1) vic1Panel.SetActive(true);
                if (lv == 2) vic2Panel.SetActive(true);
                if (lv == 3) vic3Panel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }


    public void ButtonNext()
    {
        isDone = true;
        GM.GetComponent<GM>().lv++;
        timer = 45;
        if (lv == 1) vic1Panel.SetActive(false);
        if (lv == 2) vic2Panel.SetActive(false);
        if (lv == 3) vic3Panel.SetActive(false);
        player.GetComponent<PlayerLife>().hp += 1;
        Time.timeScale = 1f;        
        GM.GetComponent<GM>().isRunning = false;

    }

    public void ButtonTA()
    {
        if (player.GetComponent<PlayerMovement>().isMobile)
        {
            GOPanel.SetActive(false);
            SceneManager.LoadScene("S1MOBILE");
            GM.GetComponent<GM>().lv = GM.GetComponent<GM>().lastLv;
        }
        else
        {
            GOPanel.SetActive(false);
            SceneManager.LoadScene("S1");
            GM.GetComponent<GM>().lv = GM.GetComponent<GM>().lastLv;
        }
    }

    public void ButtonQ()
    {
        if(player.GetComponent<PlayerMovement>().isMobile)
        {
            Application.Quit();
        }    
        else
        {
            SceneManager.LoadScene("Menu");
            GM.GetComponent<GM>().lv = 0;
        }
        
    }

    public void ShowPause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ButtonCO()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void NextSceneS2()
    {
        SceneManager.LoadScene("S2");
    }
}
