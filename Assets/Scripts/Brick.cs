using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;
    
    public int PointValue;
    public AudioClip BreakSound;
    private AudioSource audioSource;

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (PointValue)
        {
            case 1 :
                block.SetColor("_BaseColor", Color.green);
                break;
            case 2:
                block.SetColor("_BaseColor", Color.yellow);
                break;
            case 5:
                block.SetColor("_BaseColor", Color.blue);
                break;
            default:
                block.SetColor("_BaseColor", Color.red);
                break;
        }
        renderer.SetPropertyBlock(block);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        onDestroyed.Invoke(PointValue);
        audioSource.PlayOneShot(BreakSound);
        Destroy(gameObject, 0.1f);

        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
