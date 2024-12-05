using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFlappy : MonoBehaviour
{
    public float addForce;
    private Rigidbody rb;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            ApplyJump();

        }

#elif UNITY_ANDROID

        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                ApplyJump();
            }
        }
#endif
    }

    void ApplyJump()
    {
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(Vector3.up * addForce);
    }
}
