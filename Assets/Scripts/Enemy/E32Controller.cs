using UnityEngine;

public class E32Controller : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioSource shootSound;
    float ang1 = 30f;
    float ang2 = 0f;
    float ang3 = -30f;
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
        GameObject b1 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, (70 + 30) + (transform.localScale.x == -1 ? 180 : 0)));
        b1.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(ang1 * Mathf.Deg2Rad), Mathf.Sin(ang1 * Mathf.Deg2Rad)) * transform.localScale.x * 10f, ForceMode2D.Impulse);
        GameObject b2 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, (70) + (transform.localScale.x == -1 ? 180 : 0) * transform.localScale.x));
        b2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(ang2 * Mathf.Deg2Rad), Mathf.Sin(ang2 * Mathf.Deg2Rad)) * transform.localScale.x * 10f, ForceMode2D.Impulse);
        GameObject b3 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, (70 - 30) + (transform.localScale.x == -1 ? 180 : 0) * transform.localScale.x));
        b3.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(ang3 * Mathf.Deg2Rad), Mathf.Sin(ang3 * Mathf.Deg2Rad)) * transform.localScale.x * 10f, ForceMode2D.Impulse);
    }
}
