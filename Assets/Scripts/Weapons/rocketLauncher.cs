using UnityEngine;

public class rocketLauncher : MonoBehaviour
{
    private float nextTimeToFire;

    [SerializeField] private float range, fireRate, fireForce, rocketAppInSec;

    public Camera cam;
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameObject rocket;
    [SerializeField] private Rigidbody shootRocket;
    [SerializeField] private Transform shootPoint;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, range))
        {
            rocket.SetActive(false);
            Invoke("RocketAppear", rocketAppInSec);

            audio.Play();

            Rigidbody shootRocketRb = Instantiate(shootRocket, shootPoint.position, Quaternion.LookRotation(hit.normal)) as Rigidbody;
            shootRocketRb.AddForce(shootPoint.forward * fireForce * Time.deltaTime);
        }
    }

    private void RocketAppear()
    {
        rocket.SetActive(true);
    }
}