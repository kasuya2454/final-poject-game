using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckmumyAttack : MonoBehaviour
{
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Hpbar.instance.DamagePlayer(10);
        }


    }
}
