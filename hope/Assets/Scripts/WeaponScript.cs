using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Animator animator;

    public int ammoMax;
    public int ammoAmount;
    public int ammoDamage;

    public float weaponCooldown = 20f;
    bool isCooldown;
    public float cooldownTimer;

    public bool canFire;
    public bool weaponUnlocked;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime; // Decrease time
            }
            else
            {
                //UnityEngine.Debug.Log("Time's up!");
                cooldownTimer = 0;
                isCooldown = false; // Stop the timer
                canFire = true;
            }
        }
        
    }

    public void weaponFire()
    {
        if (canFire)
        {
            //play animation
            animator.SetTrigger("fire");
            
            //instantiate bullet (invisible?)


            //cooldown
            isCooldown = true;
            cooldownTimer = weaponCooldown;
            canFire = false;
        }
    }
}
