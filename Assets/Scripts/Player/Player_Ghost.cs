using UnityEngine;

public class Player_Ghost : MonoBehaviour
{
    GameObject player;
    Animator animator;
    SpriteRenderer sr;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");

        if (player != null)
        {
            float x = player.GetComponent<PlayerMovement>().lastX;
            float y = player.GetComponent<PlayerMovement>().lastY;
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }
    }

    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
