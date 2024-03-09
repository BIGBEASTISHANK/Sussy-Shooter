using UnityEngine;

public class handGun : MonoBehaviour
{
    private float nextTimeToFire;

    [SerializeField] private float shootDamage, range, fireRate;

    public AudioSource sound;
    [SerializeField] private GameObject flash, bullet;
    [SerializeField] private Animator gunAnimation;
    [SerializeField] private camera cam;
    [SerializeField] private ParticleSystem muzzelFlash;

    private void Start()
    {
        gunAnimation = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Flash();
                Shoot();
            }

            if (Input.GetButtonUp("Fire1")) gunAnimation.SetBool("Recoil", false);
        }
    }

    private void Shoot()
    {
        gunAnimation.SetBool("Recoil", true);
        muzzelFlash.Play();
        sound.Play();
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, range))
        {
            GameObject bulletGO = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));
            bulletGO.transform.parent = hit.transform;
            Destroy(bulletGO, 0.5f);

            enemy enemy = hit.transform.GetComponentInChildren<enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(shootDamage);
            }
        }
    }

    private void Flash()
    {
        flash.SetActive(true);

        Invoke("FlashOff", 0.4f);
    }

    private void FlashOff()
    {
        flash.SetActive(false);
    }
}