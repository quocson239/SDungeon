using System.Threading;
using UnityEngine;

public class LV1 : MonoBehaviour
{    
    [SerializeField] GameObject player;
    [SerializeField] GameObject E1;
    public float timer = 45;
    float spawnTime = 2f;
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
        if (!hardcore1 && timer <= 30)
        {
            hardcore1 = true;
            CancelInvoke("SpawnE1");
            spawnTime = 1.5f;            
            InvokeRepeating("SpawnE1", 1f, spawnTime);
            desTime = 2f;
        }

        if (!hardcore2 && timer <= 15)
        {
            hardcore2 = true;
            CancelInvoke("SpawnE1");
            spawnTime = 1.5f;
            InvokeRepeating("SpawnE1", 1f, spawnTime);
            desTime = 3f;
        }

        if (timer <= 0)
        {
            CancelInvoke("SpawnE1");
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
        Destroy(e,desTime);
    }

    void CountDown()
    {
        timer -= 1;
    }    

    
}
