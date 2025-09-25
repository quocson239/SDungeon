using UnityEngine;

public class LV3 : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject E31;
    [SerializeField] GameObject E32;
    [SerializeField] GameObject E33;
    public float timer = 45;
    float spawnTime = 2f;
    bool hardcore1;
    bool hardcore2;
    float desTime = 2f;
    void Start()
    {
        InvokeRepeating("SpawnE31", 1f, spawnTime);
        //InvokeRepeating("SpawnE31", 2f, spawnTime);
        //InvokeRepeating("SpawnE31", 3f, spawnTime);
        InvokeRepeating("CountDown", 1f, 1f);
    }

    void Update()
    {
        if (!hardcore1 && timer <= 30)
        {
            hardcore1 = true;
            CancelInvoke("SpawnE31");
            spawnTime = 1.5f;
            InvokeRepeating("SpawnE32", 1f, spawnTime);
            desTime = 1.5f;
        }

        if (!hardcore2 && timer <= 15)
        {
            hardcore2 = true;
            CancelInvoke("SpawnE32");
            spawnTime = 1f;
            InvokeRepeating("SpawnE33", 1f, spawnTime);
            desTime = 1.5f;
        }

        if (timer <= 0)
        {
            CancelInvoke("SpawnE33");
            CancelInvoke("CountDown");
            this.enabled = false;
        }
        if (player.GetComponent<PlayerLife>().isDead)
        {            
            CancelInvoke();
        }

    }



    void SpawnE31()
    {
        GameObject e = Instantiate(E31, new Vector3(Random.Range(1f, 3f) < 2 ? 8 : -8, player.transform.position.y), Quaternion.identity);
        Destroy(e, desTime);
    }

    void SpawnE32()
    {
        GameObject e = Instantiate(E32, new Vector3(Random.Range(1f, 3f) < 2 ? 7 : -7, player.transform.position.y), Quaternion.identity);
        Destroy(e, desTime);
    }
    void SpawnE33()
    {
        GameObject e = Instantiate(E33, new Vector3(Random.Range(1f, 3f) < 2 ? 6 : -6, player.transform.position.y), Quaternion.identity);
        Destroy(e, desTime);
    }

    void CountDown()
    {
        timer -= 1;
    }
}
