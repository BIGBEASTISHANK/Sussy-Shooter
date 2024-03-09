using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private float nextTimeToFire;
    private bool inSightRange;
    private bool inAttackRange;

    [SerializeField] private float sightRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float bulletForce;
    [SerializeField] private float fireRate;
    [SerializeField] private float health;

    [SerializeField] private Transform shootPoint;
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private TMPro.TMP_Text healthText;
    [SerializeField] private levelComplete lvlcomp;
    public AudioSource audio;

    private void Start()
    {
        healthText.text = health.ToString();
        player = GameObject.Find("Player").transform;
        agent = GetComponentInChildren<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        inSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (inSightRange && !inAttackRange) Chase();
        if (inSightRange && inAttackRange) Attack();
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        RaycastHit hit;

        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward), out hit, attackRange))
        {
            if (hit.transform.name == "Player" && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;

                Rigidbody EnemyBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation) as Rigidbody;
                audio.Play();
                EnemyBullet.AddForce(shootPoint.forward * bulletForce * Time.deltaTime);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        healthText.text = health.ToString();

        if (health <= 0)
        {
            Destroy(gameObject);
            lvlcomp.killedEnemy++;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(shootPoint.transform.position, attackRange);
        Gizmos.DrawWireSphere(shootPoint.transform.position, sightRange);
    }
}