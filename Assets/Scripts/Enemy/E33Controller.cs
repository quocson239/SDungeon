using UnityEngine;

public class E33Controller : MonoBehaviour
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
        GameObject b1 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 60 * transform.localScale.x));
        b1.GetComponent<Rigidbody2D>().AddForce(-b1.transform.up * 10f, ForceMode2D.Impulse);
        GameObject b2 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90 * transform.localScale.x));
        b2.GetComponent<Rigidbody2D>().AddForce(-b2.transform.up * 10f, ForceMode2D.Impulse);
        GameObject b3 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 120 * transform.localScale.x));
        b3.GetComponent<Rigidbody2D>().AddForce(-b3.transform.up * 10f, ForceMode2D.Impulse);
    }
}
