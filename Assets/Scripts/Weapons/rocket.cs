using UnityEngine;

public class rocket : MonoBehaviour
{
    [SerializeField] private float explosionDesInSec, explosionDamage;

    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform explosionPosition;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        GameObject explosionGO = Instantiate(explosion, explosionPosition.position, explosionPosition.rotation);
        if (collision.transform.tag != "unbreakable")
        {
            if (collision.transform.name == "Enemy")
            {
                enemy enemy = collision.transform.GetComponentInChildren<enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(explosionDamage);
                }
            }
            else Destroy(collision.gameObject);
        }

        Destroy(explosionGO, explosionDesInSec);
    }
}