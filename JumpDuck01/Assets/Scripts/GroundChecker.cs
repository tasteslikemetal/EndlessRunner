using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundChecker : MonoBehaviour
{
    public PlayerMovement pMovement;
    public GameObject self;

    public GameObject dissolvedSelf;
    public Material dissolveMat;
    public float dissolveAmount = 0;

    float noDissolve = 0;
    float fullDissolve = 1;
    float dissolveSPEED = 5;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == pMovement.gameObject)
        {
            return;
        }
        pMovement.isGrounded = true;
        pMovement.isJumping = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathTouch"))
        {
            Destroy(self);
            Debug.Log("death");
            dissolveAmount = Mathf.Lerp(noDissolve, fullDissolve, Time.time * dissolveSPEED);
            GameManager.instance.state = GameManager.eState.RESULTS;
            GameManager.instance.scoreManager.SaveScore();
        }

        if (other.gameObject.CompareTag("WinGate") && SceneManager.GetActiveScene().name != "PlayScene3")
        {
            Destroy(self);
            //self.GetComponent<MeshRenderer>().enabled = false;
            //dissolvedSelf.GetComponent<MeshRenderer>().enabled = true;
            //dissolveMat.SetFloat("Vector1_788489E9", dissolveAmount);
            
            Debug.Log("win");
            GameManager.instance.currentLevel++;
            GameManager.instance.state = GameManager.eState.WIN;
            GameManager.instance.scoreManager.SaveScore();
        }
        if (other.gameObject.CompareTag("WinGate") && SceneManager.GetActiveScene().name == "PlayScene3")
        {
            Debug.Log("win");
            GameManager.instance.state = GameManager.eState.WIN;
            GameManager.instance.scoreManager.SaveScore();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        pMovement.isGrounded = false;
        pMovement.isJumping = true;
    }

    private void Update()
    {
        /*if (dissolvedSelf.GetComponent<MeshRenderer>().enabled == true)
        {
            dissolveAmount = Mathf.Lerp(noDissolve, fullDissolve, Time.time * dissolveSPEED);
        }*/


    }
}
