using UnityEngine;

public class DestroyBullet : MonoBehaviour
{



    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
