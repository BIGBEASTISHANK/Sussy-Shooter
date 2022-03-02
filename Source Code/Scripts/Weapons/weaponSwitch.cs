using UnityEngine;

public class weaponSwitch : MonoBehaviour
{
    [SerializeField] private GameObject handGun, rocketLauncher, handGunImg, rocketLauncherImg;

    private void Update()
    {
        var gun1 = Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1) || Input.GetAxis("Mouse ScrollWheel") > 0;
        var gun2 = Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2) || Input.GetAxis("Mouse ScrollWheel") < 0;

        if (gun1)
        {
            HandGun();
        }
        else if (gun2)
        {
            RocketLauncher();
        }
    }

    private void HandGun()
    {
        rocketLauncher.SetActive(false);
        rocketLauncherImg.SetActive(false);

        handGun.SetActive(true);
        handGunImg.SetActive(true);
    }

    private void RocketLauncher()
    {
        handGun.SetActive(false);
        handGunImg.SetActive(false);

        rocketLauncher.SetActive(true);
        rocketLauncherImg.SetActive(true);
    }
}