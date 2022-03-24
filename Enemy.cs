using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int RandomClass;
    public int MaxHP;
    public float Speed;
    public Transform [] MoveSpots;
    public int scaler;
    public int Amax, Bmax, Cmax, Dmax;
    public int Amob, Bmob, Cmob, Dmob;
    public static int DificultLvl;
    public int Ammo;
    public int Damage;
    public float shootingDistance;
    public int randomSpot;
    public bool Charge;

    private Transform player;
    private Vector2 target;


    void Start()
    {
        randomSpot = Random.Range(0, MoveSpots.Length);
        player = GameObject.FindGameObjectWithTag("Unit").transform;
        target = new Vector2(player.position.x, player.position.y);

        

        RandomClass = Random.Range(1, DificultLvl);
        if (RandomClass == 1)
        {
            Charge = false;
            MaxHP = 2 + scaler;
            Speed = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RandomClass == 1)
        {
            if (Charge == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, MoveSpots[randomSpot].position, Speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, MoveSpots[randomSpot].position) < 0.1f)
                {
                    Charge = true;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
            }


            /*EnemyWeapon other = gameObject.GetComponent<EnemyWeapon>();*/
            if (Vector2.Distance(transform.position, player.position) < shootingDistance)
            {
                StartCoroutine(Shooting());
            }
        }
    }
    IEnumerator Shooting()
        
    {
        Speed = 0;
        shootingDistance = -1;
        ShootingTime();
        yield return new WaitForSeconds(3.5f);
        StopShooting();
        Speed = 1f;
    }

    public void ShootingTime()
    {
        EnemyWeapon other = gameObject.GetComponent<EnemyWeapon>();
        other.enabled = true;
     
    }
    public void StopShooting()
    {
        EnemyWeapon other = gameObject.GetComponent<EnemyWeapon>();
        other.enabled = false;
    }


}
