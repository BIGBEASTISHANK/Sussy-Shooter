using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] private float destroyInSec;
    [SerializeField] private float shootDamage;

    private void Update()
    {
        if (destroyInSec != 0 && destroyInSec > 0)
        {
            Destroy(this.gameObject, destroyInSec);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.name == "Player")
        {
            health health = other.transform.GetComponentInChildren<health>();

            if (health != null)
            {
                health.TakeDamage(shootDamage);
            }
        }
    }
}