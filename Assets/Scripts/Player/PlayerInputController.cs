using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private string m_horizontalAxis;



    private float m_horizontalInput;

    // Update is called once per frame
    void Update()
    {
        m_horizontalInput = Input.GetAxis(m_horizontalAxis);
    }
}
