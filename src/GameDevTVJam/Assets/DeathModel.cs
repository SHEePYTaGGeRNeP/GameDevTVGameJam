using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathModel : MonoBehaviour
{
    public void DeathTick()
    {
        GameObject.Destroy(this.gameObject);
    }    
}
