using UnityEngine;

public class S1Au : MonoBehaviour
{
    [SerializeField] AudioSource b1;
    [SerializeField] AudioSource b2;
    [SerializeField] GameObject canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.GetComponent<CanvasManager>().timer < 30)
        {
            b1.Stop();
            if (!b2.isPlaying)
            { b2.Play(); }
        }
        else
        {
            b2.Stop();
            if (!b1.isPlaying)
            { b1.Play(); }
        }
    }
}
