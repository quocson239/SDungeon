using UnityEngine;

public class LV2 : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject E1;
    [SerializeField] GameObject E2;
    public float timer = 45;
    float spawnTime = 1.5f;
    bool hardcore1;
    bool hardcore2;
    float desTime = 2f;
    void Start()
    {
        InvokeRepeating("SpawnE1", 1f, spawnTime);
        InvokeRepeating("CountDown", 1f, 1f);
    }

    void Update()
    {        
        if (!hardcore1 && timer <= 35)
        {
            hardcore1 = true;
            CancelInvoke("SpawnE1");
            spawnTime = 2f;
            InvokeRepeating("SpawnE2", 1f, spawnTime);
            desTime = 2f;
        }

        if (!hardcore2 && timer <= 15)
        {
            hardcore2 = true;
            CancelInvoke("SpawnE2");
            spawnTime = 1f;
            InvokeRepeating("SpawnE2", 1f, spawnTime);
            desTime = 2f;
        }

        if (timer <= 0)
        {
            CancelInvoke("SpawnE2");
            CancelInvoke("CountDown");
            this.enabled = false;
        }
        if (player.GetComponent<PlayerLife>().isDead)
        {
            CancelInvoke();
        }
    }



    void SpawnE1()
    {
        GameObject e = Instantiate(E1, new Vector3(Random.Range(1f, 3f) < 2 ? 8 : -8, player.transform.position.y), Quaternion.identity);
        Destroy(e, desTime);
    }
    void SpawnE2()
    {
        GameObject e = Instantiate(E2, new Vector3(Random.Range(1f, 3f) < 2 ? 7 : -7, player.transform.position.y), Quaternion.identity);
        Destroy(e, desTime);
    }
    void CountDown()
    {
        timer -= 1;
    }
}
