using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField] //0 tripleshot, 1 speed, 2 shield
    private int _powerupId = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                if (_powerupId == 0)
                {
                    player.TripleShotPowerUpOn();

                }else if (_powerupId == 1)
                {
                    player.SpeedPowerUpOn();
                }else if (_powerupId == 2)
                {
                    player.ShieldPowerUpOn();
                }
                
            }
            Destroy(this.gameObject);
        }
    }
}
