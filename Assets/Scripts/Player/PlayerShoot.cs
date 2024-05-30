using TMPro;
using UnityEngine;

public class PlayerShoot : Sounds
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject firePoint;

    [SerializeField] private TMP_Text bulletText;
    
    [SerializeField] public int maxCountBullet;
    [SerializeField] public int bulletCount;
    
    private bool _isReloading = false;

    private void Start()
    {
        bulletCount = maxCountBullet;
        bulletText.text = $"{bulletCount}/{maxCountBullet}";
    }

    public bool Shooting()
    {
        if (bulletCount != 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
                PlaySound(sounds[0]);
            
                bulletCount--;
                bulletText.text = $"{bulletCount}/{maxCountBullet}";
            
                Destroy(bullet, 2);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        return _isReloading;
    }

    public bool Reload()
    {
        if (bulletCount == 0 && maxCountBullet != 0)
        {
            bulletCount = maxCountBullet;
            maxCountBullet -= maxCountBullet;
            PlaySound(sounds[1]);

            _isReloading = true;
            Invoke("Check", 1);
            return true;
        }
        else if (_isReloading == false)
        {
            return false;
        }

        return _isReloading;
    }

    private void Check()
    {
        PlaySound(sounds[2]);
        _isReloading = false;
        bulletText.text = $"{bulletCount}/{maxCountBullet}";
    }
}
