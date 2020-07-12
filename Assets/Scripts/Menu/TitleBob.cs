using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBob : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How far the title bobs downward")]
    private float m_BobDistance;

    [SerializeField]
    [Tooltip("How long it takes to reach full bob")]
    private float m_BobTime;

    private Vector3 m_TopPosition;
    private Vector3 m_BottomPosition;
    private int m_Direction;
    private float m_CurrProportion;

    void Start()
    {
        m_TopPosition = transform.position;
        m_BottomPosition = transform.position + Vector3.down * m_BobDistance;
        m_Direction = -1;
        m_CurrProportion = 0f;
    }

    // Makes the title bob up and down
    void Update()
    {
        transform.position = Vector3.Lerp(m_TopPosition, m_BottomPosition, m_CurrProportion);

        if (m_CurrProportion == 1f || m_CurrProportion == 0f) {
            m_Direction *= -1;
        }

        m_CurrProportion = m_CurrProportion + m_Direction * Time.deltaTime / m_BobTime;
        m_CurrProportion = Mathf.Max(m_CurrProportion, 0f);
        m_CurrProportion = Mathf.Min(m_CurrProportion, 1f);
    }
}
