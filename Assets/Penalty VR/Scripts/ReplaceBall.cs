using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ReplaceBall : MonoBehaviour
{
    #region Refs
    private Rigidbody m_Rigidbody;
    public AudioSource m_AudioSource;
    #endregion

    public float m_Force = 500f;
    public Transform[] m_KickPoints;
    public Transform m_Target;  // Player
    public Transform m_ShootPlace;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void Replce()
    {
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.isKinematic = true;
        Vector3 newPosition = m_KickPoints[Random.Range(0, m_KickPoints.Length)].position;
        m_Rigidbody.isKinematic = false;
        transform.position = newPosition;
        m_ShootPlace.position = newPosition;
    }

    public void Kick()
    {
        Vector3 direction = (m_Target.position - transform.position).normalized;
        m_Rigidbody.AddForceAtPosition(direction * m_Force * Time.fixedDeltaTime, -transform.forward, ForceMode.Impulse);
        m_AudioSource.Play();
    }
}