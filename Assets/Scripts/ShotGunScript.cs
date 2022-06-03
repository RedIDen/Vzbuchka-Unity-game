using System.Collections;
using UnityEngine;

public class ShotGunScript : WeaponScript
{
    private readonly System.Random random = new System.Random();
    private float timeAfterShot = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.weight = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAfterShot > 0)
        {
            this.timeAfterShot -= Time.deltaTime;
        }
    }


    public override bool Shoot()
    {
        if (this.timeAfterShot <= 0)
        {
            SpawnBullet(transform.parent.localScale.x > 0 ? 0 : 180);

            this.timeAfterShot = this.timeBetweenShots;
            return true;
        }

        return false;
    }

    void SpawnBullet(float angle)
    {
        Instantiate(effect, effectPoint.position, Quaternion.Euler(0, 90 + angle, 0));
        Instantiate(bullet, shootPoint.position, Quaternion.Euler(0, angle, this.random.Next(-3, 3)));
        Instantiate(bullet, shootPoint.position, Quaternion.Euler(0, angle, this.random.Next(-5, 5)));
        Instantiate(bullet, shootPoint.position, Quaternion.Euler(0, angle, this.random.Next(-10, 10)));
    }
}
