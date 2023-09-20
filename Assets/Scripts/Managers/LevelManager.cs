using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Vector2 m_gridSize = new Vector2(10, 10);
    [SerializeField] private Vector2 m_padding = new Vector2(0.25f, 0.25f);
    [SerializeField] private Vector2 m_brickSize = new Vector2(1, 0.5f);
    [SerializeField] private GameObject m_brickPrefab;

    private void Awake()
    {
        CreateBricks();
    }

    private void CreateBricks()
    {
        Vector2 centerPosition = transform.position;

        Vector2 startOffset = new Vector2(
            -(m_brickSize.x + m_padding.x) * (m_gridSize.x - 1) / 2f,
            -(m_brickSize.y + m_padding.y) * (m_gridSize.y - 1) / 2f
        );

        for (int i = 0; i < m_gridSize.x; i++)
        {
            for (int j = 0; j < m_gridSize.y; j++)
            {
                Vector2 brickPosition = centerPosition + startOffset +
                    new Vector2(
                        (m_brickSize.x + m_padding.x) * i,
                        (m_brickSize.y + m_padding.y) * j
                    );

                Instantiate(m_brickPrefab, brickPosition, Quaternion.identity);
            }
        }
    }

}
