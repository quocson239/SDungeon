using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player Setting")]
    public Vector2 move;
    float speed = 3f;
    public float lastX;
    public float lastY;
    public bool isRun;
    public bool isDash;
    float timeDash;
    float dashCD = 1f;
    public bool isImmute;
    
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] GameObject dashPrefab;
    [SerializeField] Image dashImage;



    [Header("Mobile")]
    public bool isMobile;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Animate();

        if (!isDash && !GetComponent<PlayerLife>().isDead)
        {
            Move();
        }        

        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= timeDash + dashCD && !GetComponent<PlayerLife>().isDead)
        {
            StartCoroutine(Dash());
        }

        if(dashImage!= null) dashImage.fillAmount = timeDash + dashCD - Time.time / dashCD;

    }

    private void FixedUpdate()
    {
        

    }

    void Move()
    {
        if(!isMobile) move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if ((move.x == 0 && move.y == 0))
        {
            isRun = false;
        }
        else
        {
            isRun = true;
            lastX = move.x;
            lastY = move.y;
        }

        transform.position += (Vector3)move.normalized * speed * Time.deltaTime;
    }

    IEnumerator Dash()
    {
        isDash = true;
        isImmute = true;
        timeDash = Time.time;
        animator.SetTrigger("Dash");
        rb.AddForce(new Vector2 (lastX, lastY).normalized * 5f, ForceMode2D.Impulse);
        InvokeRepeating("SpawnDash", 0, 0.1f);
        yield return new WaitForSeconds(0.5f);
        CancelInvoke("SpawnDash");
        rb.linearVelocity = Vector2.zero;
        isDash = false;
        isImmute = false;
    }

    void SpawnDash()
    {
        GameObject d = Instantiate(dashPrefab, transform.position - new Vector3(lastX,lastY,0) * 0.25f, Quaternion.identity);
        Destroy(d,0.2f);
    }

    void Animate()
    {
        animator.SetFloat("X", lastX);
        animator.SetFloat("Y", lastY);
        animator.SetBool("isRun", isRun);
    }

    public void IconDashTrigger()
    {
        if (Time.time >= timeDash + dashCD && !GetComponent<PlayerLife>().isDead)
        {
            StartCoroutine(Dash());
        }
    }    

}
