using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAndTriggerEnters : MonoBehaviour
{
    public Transform m_GameAudioSource;
    public AudioClip m_HitAudioClip;

    private void Start()
    {
        m_GameAudioSource = GameObject.FindGameObjectWithTag("Audio").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint collisionPoint = collision.contacts[0];
        m_GameAudioSource.position = collisionPoint.point;
        m_GameAudioSource.GetComponent<AudioSource>().PlayOneShot(m_HitAudioClip);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            // do something
            Debug.Log("Goal");
        }
    }
}