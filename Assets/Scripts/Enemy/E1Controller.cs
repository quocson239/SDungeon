using UnityEngine;

public class E1Controller : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioSource shootSound;
    private void Awake()
    {
        if (transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
    void Start()
    {
        InvokeRepeating("Shoot", 0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        GameObject b = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90 * transform.localScale.x));
        b.GetComponent<Rigidbody2D>().AddForce(Vector2.right * transform.localScale.x * 10f, ForceMode2D.Impulse);
        shootSound.Play();
    }
}
