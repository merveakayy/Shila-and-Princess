using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float mesafe;
    public Transform target;
    private Rigidbody rb;
    Vector3 pos;
    private Animator enemyanimator;

    bool EnemyDead = false;


    public float Health = 100f;

    bool followtarget, attack;
    float timer;

    bool hit;

    void Start()
    {
        enemyanimator = GetComponent<Animator>();
        enemyanimator.SetInteger("State", 0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyDead == true)
        {
            return;
        }
        //mesafe = Vector3.Distance(transform.position, target.position);
        //pos = new Vector3(target.position.x, transform.position.y, target.position.z);
        if (followtarget)
        {
            transform.LookAt(target.position);
            Quaternion Rotation = transform.rotation;
            Rotation.x = 0;
            Rotation.z = 0;
            transform.rotation = Rotation;
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                return;
            }

            //enemyanimator.SetBool("EnemyMode", true);
            if (hit == false)
            {
                enemyanimator.SetInteger("State", 2);
                transform.Translate(Vector3.forward * 7 * Time.deltaTime);
                Attack();
            }
            
        }
            Damage();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            followtarget = true;
            target = other.transform;
            timer = 2.7f;
            enemyanimator.SetInteger("State", 1);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hit = false;
            followtarget = false;
            enemyanimator.SetInteger("State", 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            if (hit == false)
            {
                hit = true;
                Invoke(nameof(SetHit), 1.3f);
            }
            enemyanimator.SetInteger("State", 4);
            FindObjectOfType<Effects>().DamageEffect(collision.transform.position);
            Health -= 10;
            Sounds.instance.damageSound(collision.transform.position);
            if (Health <= 0 && !EnemyDead)
            {
                EnemyDead = true;
                followtarget = false;
                enemyanimator.SetInteger("State", 5);
                Destroy(gameObject, 5f);
            }
        }
    }

    private void SetHit()
    {
        hit = false;
    }
 private void Attack()
    {
        if(Vector3.Distance(transform.position, target.position)<13)
        {
            followtarget = false; attack = true;
            enemyanimator.SetInteger("State", 3);
        }   
    }

float hitTime = 1;
    private void Damage()
    {
        if(attack==true)
        {
            hitTime -= Time.deltaTime;
            if(hitTime<=0)
            {
                if(Vector3.Distance(transform.position, target.position)<13)
                {
                    target.GetComponent<PlayerStats>().GetDamage();
                } 
                followtarget = true;
                hitTime = 2;
                attack = false;
            }
        }
    }


}
