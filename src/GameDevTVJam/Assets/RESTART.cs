using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RESTART : MonoBehaviour
{
    public KeyCode resetKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(resetKey)) SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
