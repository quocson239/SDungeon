using System.Collections;
using UnityEngine;
public class PlayerLife : MonoBehaviour
{
    public int hp = 3;
    float x;
    float y;
    public bool isDead;

    Animator animator;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        x = GetComponent<PlayerMovement>().lastX;
        y = GetComponent<PlayerMovement>().lastY;
    }

    IEnumerator Hurt()
    {
        if(hp > 1) hp -= 1;
        else
        {
            hp -= 1;
            isDead = true;
        }
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    void Animate()
    {
        animator.SetBool("Dead", isDead);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EBullet") && !GetComponent<PlayerMovement>().isImmute)
        {
            StartCoroutine(Hurt());
            Destroy(collision.gameObject);
        }
    }

}
