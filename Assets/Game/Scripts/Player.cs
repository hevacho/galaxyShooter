using System;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    private const float LIMIT_SHIP_X = 9f;
    private const float LIMIT_SHIP_Y = -4.2f;

    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private GameObject _laserPrefaf;
    [SerializeField]
    private float _fireRate = 0.25f;

    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private GameObject explosionPrefab;

    private float _nextFire = 0.0f;
    public bool isTripleShootActive;
    public bool isSpeedBootActive;
    public bool isShieldActive;

    [SerializeField]
    private GameObject _shieldsGO;

    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, LIMIT_SHIP_Y);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();

    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            
            if (isTripleShootActive)
            {
                Instantiate(_laserPrefaf, new Vector3(transform.position.x -0.54f , transform.position.y, 0), Quaternion.identity);
                Instantiate(_laserPrefaf, new Vector3(transform.position.x, transform.position.y + 0.95f, 0), Quaternion.identity);
                Instantiate(_laserPrefaf, new Vector3(transform.position.x + 0.56f, transform.position.y, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefaf, new Vector3(transform.position.x, transform.position.y + 0.95f, 0), Quaternion.identity);
            }
        }
    }

    private void Movement()
    {
        //creates a vector using values ([-1,1], [-1,1], 0)
        Vector3 vectorTranslate = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float speedPower = isSpeedBootActive ? 1.5f : 1f;
        transform.Translate(vectorTranslate * _speed * speedPower * Time.deltaTime);

        //limit position
        float y = Mathf.Clamp(transform.position.y, LIMIT_SHIP_Y, 0f);

        //teletransport other side
        float x = transform.position.x;
        if (x < -LIMIT_SHIP_X)
        {
            x = LIMIT_SHIP_X;
        }
        else if (x > LIMIT_SHIP_X)
        {
            x = -LIMIT_SHIP_X;
        }

        transform.position = new Vector3(x, y, 0);
    }

    public void TripleShotPowerUpOn()
    {
        isTripleShootActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

     IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShootActive = false;
    }

    public void SpeedPowerUpOn()
    {
        isSpeedBootActive = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBootActive = false;
    }

    public void ShieldPowerUpOn()
    {
        isShieldActive = true;
        _shieldsGO.SetActive(true);
    }

    public void Damage()
    {

        if (isShieldActive)
        {
            isShieldActive = false;
            _shieldsGO.SetActive(false);
        }
        else
        {
            lives--;
        }
        
        if (lives <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public bool isAlive()
    {
        return lives > 0;
    }
}
