using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCamera : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 cameraStartPos;

    // Start is called before the first frame update
    void Start()
    {
        this.cameraStartPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x;
        float y;

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        this.transform.position += new Vector3(x * this.speed * Time.deltaTime, y * this.speed * Time.deltaTime, 0);

        if(Input.GetButton("Jump"))
        {
            this.transform.position = this.cameraStartPos;
        }
    }
}
