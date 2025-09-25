using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{    
    [SerializeField] GameObject intro1;
    [SerializeField] GameObject intro2;
    [SerializeField] GameObject intro3;
    [SerializeField] GameObject ground1;
    [SerializeField] GameObject ground2;
    [SerializeField] GameObject ground3;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject player;
    public int lv;
    public int lastLv;
    public bool isRunning;
    bool is1Run;
    bool is2Run;
    bool is3Run;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lv == 1 && !isRunning && !is1Run)
        {
            is1Run = true;
            StartCoroutine(LV1());
        }
        if (lv == 2 && !isRunning && !is2Run)
        {
            is2Run = true;
            StartCoroutine(LV2());
        }
        if (lv == 3 && !isRunning && !is3Run)
        {
            is3Run = true;
            StartCoroutine(LV3());
        }
        if(player.GetComponent<PlayerLife>().isDead)
        {
            StopAllCoroutines();
            CancelInvoke();
            lastLv = lv;
        }
    }

    IEnumerator LV1()
    {
        isRunning = true;
        intro1.SetActive(true);
        InvokeRepeating("ShowIt", 0, 0.1f);
        yield return new WaitForSeconds(2f);
        CancelInvoke("ShowIt");
        InvokeRepeating("FadeIt", 0, 0.1f);
        yield return new WaitForSeconds(3f);
        CancelInvoke("FadeIt");        
        GetComponent<LV1>().enabled = true;

    }

    IEnumerator LV2()
    {
        isRunning = true;
        canvas.GetComponent<CanvasManager>().isDone = false;
        intro2.SetActive(true);
        ground2.SetActive(true);
        ground1.SetActive(false);
        InvokeRepeating("ShowIt", 0, 0.1f);
        yield return new WaitForSeconds(2f);
        CancelInvoke("ShowIt");
        InvokeRepeating("FadeIt", 0, 0.1f);
        yield return new WaitForSeconds(3f);
        CancelInvoke("FadeIt");
        GetComponent<LV2>().enabled = true;
    }
    IEnumerator LV3()
    {
        isRunning = true;
        canvas.GetComponent<CanvasManager>().isDone = false;
        intro3.SetActive(true);
        ground3.SetActive(true);
        ground2.SetActive(false);
        InvokeRepeating("ShowIt", 0, 0.1f);
        yield return new WaitForSeconds(2f);
        CancelInvoke("ShowIt");
        InvokeRepeating("FadeIt", 0, 0.1f);
        yield return new WaitForSeconds(3f);
        CancelInvoke("FadeIt");
        GetComponent<LV3>().enabled = true;

    }
    void ShowIt()
    {
        if(lv == 1) intro1.GetComponent<Image>().color = new Color(1, 1, 1, intro1.GetComponent<Image>().color.a + 0.05f);
        if (lv == 2) intro2.GetComponent<Image>().color = new Color(1, 1, 1, intro2.GetComponent<Image>().color.a + 0.05f);
        if (lv == 3) intro3.GetComponent<Image>().color = new Color(1, 1, 1, intro3.GetComponent<Image>().color.a + 0.05f);

    }
    void FadeIt()
    {
        if (lv == 1) intro1.GetComponent<Image>().color = new Color(1, 1, 1, intro1.GetComponent<Image>().color.a - 0.05f);
        if (lv == 2) intro2.GetComponent<Image>().color = new Color(1, 1, 1, intro2.GetComponent<Image>().color.a - 0.05f);
        if (lv == 3) intro3.GetComponent<Image>().color = new Color(1, 1, 1, intro3.GetComponent<Image>().color.a - 0.05f);
    }
}
