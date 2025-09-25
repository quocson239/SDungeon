using UnityEngine;

public class E31Controller : MonoBehaviour
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
        shootSound.Play();
        GameObject b1 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90 * transform.localScale.x));
        b1.GetComponent<Rigidbody2D>().AddForce(-b1.transform.up * 10f, ForceMode2D.Impulse);
        
    }
}
