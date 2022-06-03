using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("MOVEMENT...")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float _speed = 5;
    public float RotSpeed;
    public Joystick joy;
    private Vector3 _input;
    public Animator anim;
    public float Range = 5;
    public int Health = 100;

    [Header("SHOOTING...")]
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float BulletSpeed;
    public GameObject ClosestEnemy;
    public float RateOfFire = 1f;
    public int Damage = 1;

    [Header("UI..")]
    public Slider ExpBar;
    public float Exp = 0f;
    public Button Upgrade;
    public GameObject UpgradePanel;
    private int UpgAvailable;
    public Text AvailableUpgText;
    public Button UpgButton1, UpgButton2, UpgButton3;
    public Text HealthText;
    public GameObject GameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void UpgradeBtn()
    {
        UpgAvailable++;
        UpgradePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Exp = 0f;
        ExpBar.maxValue += 1f;
        UpgradePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpgradeRange()
    {
        Range += 0.5f;
        UpgAvailable--;
    }

    public void UpgradeDamage()
    {
        Damage++;
        UpgAvailable--;
    }

    public void UpgradeRateOfFire()
    {
        if(RateOfFire > 0.2f)
        {
            RateOfFire -= 0.1f;
            UpgAvailable--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ExpBar.value = Exp;
        HealthText.text ="" + Health;
        if(Health <= 0)
        {
            GameOverPanel.SetActive(true);
        }

        if(UpgAvailable <= 0)
        {
            UpgButton1.interactable = false;
            UpgButton2.interactable = false;
            UpgButton3.interactable = false;
        }
        else
        {
            UpgButton1.interactable = true;
            UpgButton2.interactable = true;
            UpgButton3.interactable = true;
        }

        if(ExpBar.value == ExpBar.maxValue)
        {
            Upgrade.interactable = true;
        }
        else
        {
            Upgrade.interactable = false;
        }
        AvailableUpgText.text = "X " + UpgAvailable;
        ClosestEnemy = FindClosestEnemy();
        float horizontalInput = joy.Horizontal;
        float verticalInput = joy.Vertical;

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);


        if(ClosestEnemy != null)
        {
            if (Vector3.Distance(transform.position, ClosestEnemy.transform.position) > Range)
            {
                if (movementDirection != Vector3.zero)
                {
                    anim.SetBool("Walking", true);
                    Quaternion toRot = Quaternion.LookRotation(movementDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, RotSpeed * Time.deltaTime);
                }
                else
                {
                    anim.SetBool("Walking", false);
                }
            }
            else
            {
                if (movementDirection != Vector3.zero)
                {
                    anim.SetBool("Walking", true);

                }
                else
                {
                    anim.SetBool("Walking", false);
                }

                transform.LookAt(ClosestEnemy.transform.position);

            }
        }

        else
        {
            if (movementDirection != Vector3.zero)
            {
                anim.SetBool("Walking", true);
                Quaternion toRot = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, RotSpeed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("Walking", false);
            }
        }
        

     
    }

    public IEnumerator Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<BulletScript>().Damage = Damage;
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * BulletSpeed;
     

        yield return new WaitForSeconds(1f);

        StartCoroutine(Shoot());
    }

    private void FixedUpdate()
    {
        
    }

    void Look()
    {
      

     
    }

    public void GatherInput()
    {

    }

    private void move()
    {
     
     
    }
}
