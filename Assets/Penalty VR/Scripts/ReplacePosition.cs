using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacePosition : MonoBehaviour
{
    [Header("Audios in game")]
    public AudioSource m_ShootPlaceAudioSource;  // for using its AudioSource!
    public AudioClip m_ReadyAudioClip;

    [Header("Time For Replacing")]
    public float m_Time;

    [Header("Ball Reference")]
    public ReplaceBall m_Ball;

    private void Start()
    {
        ReplaceGameObjectPosition();
    }

    private void ReplaceGameObjectPosition()
    {
        m_Ball.Replce();
        m_ShootPlaceAudioSource.PlayOneShot(m_ReadyAudioClip);

        System.Action b = () => { m_Ball.Kick(); };
        Invoke(b.Method.Name, 2f);

        Invoke("ReplaceGameObjectPosition", m_Time);
    }
}