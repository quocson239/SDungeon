using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S2 : MonoBehaviour
{
    float timer;
    public GameObject text;
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        text.SetActive(Time.time >= timer + 3f);
        
        if(Input.anyKeyDown && Time.time >= timer + 3f)
        {
            SceneManager.LoadScene("Menu");
        }    
    }

    

}
