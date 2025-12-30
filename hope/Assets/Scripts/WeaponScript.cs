using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public int ammoMax;
    public int ammoAmount;
    public int ammoDamage;
    public int weaponCooldown;

    public bool canFire;
    public bool weaponUnlocked;

    private float fire1Input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fire1Input = Input.GetAxis("Fire1");
        
        if (fire1Input == 1) {
            weaponFire();
        }
        
    }

    void weaponFire()
    {
        if (canFire)
        {
            //play animation
            //instantiate bullet (invisible?)
        }
    }
}
