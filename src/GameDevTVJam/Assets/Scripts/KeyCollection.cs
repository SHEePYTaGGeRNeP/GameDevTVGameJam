using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GamePlay;

public class KeyCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().IncreaseKey();
            GameObject.Destroy(this.gameObject);
            this.enabled = false;
        }
    }
}
