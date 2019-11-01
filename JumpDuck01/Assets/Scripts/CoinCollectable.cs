using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            GameManager.instance.scoreManager.AddScore(100);
            Destroy(gameObject);
        }
    }
}
