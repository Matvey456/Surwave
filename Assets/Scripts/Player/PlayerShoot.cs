using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject firePoint;

    [SerializeField] private AudioSource playerShooting;
    [SerializeField] private AudioSource playerReloading;
    [SerializeField] private AudioSource playerNoBullet;
    
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
                playerShooting.Play();
            
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
            playerReloading.Play();

            _isReloading = true;
            Invoke("Check", 1);
            Debug.Log("Перезарядка сработало");
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
        playerNoBullet.Play();
        _isReloading = false;
        bulletText.text = $"{bulletCount}/{maxCountBullet}";
    }
}
