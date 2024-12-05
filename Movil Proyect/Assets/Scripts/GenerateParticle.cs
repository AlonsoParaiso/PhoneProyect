using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateParticle : MonoBehaviour
{
    public GameObject particle;
    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetMouseButtonDown(0))
        {
            InstanceParticles(Input.mousePosition, Color.red);

        }

#elif UNITY_ANDROID

        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                InstanceParticles(touch.position, Color.blue);
            }
        }
#endif
    }

        void InstanceParticles(Vector3 screenCoords, Color color)
        {
            screenCoords.z = 10;
            Vector3 gamCoords = _cam.ScreenToWorldPoint(screenCoords);
            GameObject particleClone=Instantiate(particle, gamCoords, Quaternion.identity);
            particleClone.GetComponent<Renderer>().material.color = color;
        }
}
