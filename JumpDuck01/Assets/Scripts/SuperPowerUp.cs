using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            PlayerMovement.instance.DoSuper();
            Destroy(gameObject);
        }
    }
}
