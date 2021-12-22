using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShoot : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed = 30f;
    public float fireRate = 4;
    public float arcRange = 1;

    private Vector3 destination;
    private float timeToFire;
    public AudioSource castSound;
    public AudioSource castSound2;

    private bool canPlay = true;
    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjectile();
        }
    }*/

    public void ShootProjectile()
    {
        if(Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                destination = hit.point;
            else
                destination = ray.GetPoint(1000);

            InstantiateProjectile();
        }
    }

    void InstantiateProjectile()
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        if(canPlay)
        {
            canPlay = !canPlay;
            castSound.Play();
        }
        else
        {
            canPlay = !canPlay;
            castSound2.Play();
        }

        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }

    private IEnumerator waitForAwhile()
    {
        yield return new WaitForSeconds(0.5f);
        canPlay = true;
    }
}
