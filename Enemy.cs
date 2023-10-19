
using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Player player;
    public GameObject deadObject;
    public new CameraControl camera;
    public Objective objective;
    bool Hit = false;
    public int health = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name.Contains("Ant"))
        {
            Ant(other);
        }
        else if (gameObject.name.Contains("SK_Tank"))
        {
            Tank(other);
        }
    }

    private void Ant(Collider other)
    {
        Debug.Log("Triggered Entered by " + other.name);
        if (other.tag == "PlayerWeapon" && player.AnimatorIsPlaying("2H_Melee_Attack_Spin") && Hit == false)
        {
            Hit = true; //This is to ensure the trigger script runs only once per enemy.
            if (camera.AnimatorIsPlaying("CameraShake") == false)
            {
                Vibration.Vibrate(500);
                camera.ShakeScreen();
            }
            DeathActions();
            StartCoroutine(DeathWait());
        }

        if (other.tag == "Objective")
        {
            Hit = true;
            Vibration.Vibrate(250);
            objective.DealDamage(10);
            StartCoroutine(DeathWait());
        }
    }
    private void Tank(Collider other)
    {
        Debug.Log("Triggered Entered by " + other.name);
        if (other.tag == "PlayerWeapon" && player.AnimatorIsPlaying("2H_Melee_Attack_Spin") && Hit == false)
        {
            StartCoroutine(DecreaseTankHealth());
            Debug.Log("HIT!\n Current Health: " + health);
            if (health <= 0)
            {
                Hit = true; //This is to ensure the trigger script runs only once per enemy.
                if (camera.AnimatorIsPlaying("CameraShake") == false)
                {
                    Vibration.Vibrate(500);
                    camera.ShakeScreen();
                }
                DeathActions();
                StartCoroutine(DeathWait());
            }
        }

        if (other.tag == "Objective")
        {
            Hit = true;
            Vibration.Vibrate(250);
            objective.DealDamage(10);
            StartCoroutine(DeathWait());
        }
    }

    IEnumerator DecreaseTankHealth()
    {
        health -= 1;
        yield return new WaitForSeconds(1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "ThePlayerCapsule")
        {

            if (other.name == "ThePlayerCapsule")
            {
                Debug.Log("Initiate Attack");
                player.InitiateAttack();
            }
        }
    }

    private void DeathActions()
    {
        Vector3 position = new Vector3(gameObject.transform.position.x, 0.7f, gameObject.transform.position.z); //Due to errors in transform
        Instantiate(deadObject, position, Quaternion.identity);
    }

    IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
