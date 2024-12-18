using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSquareMover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f; // 장애물 이동 속도

    [SerializeField]
    private float moveRange = 3f; // 이동 범위

    private float startPositionX; // 초기 위치 저장
    private int direction = 1; // 이동 방향 (1: 오른쪽, -1: 왼쪽)

    void Start()
    {
        startPositionX = transform.position.x; // 초기 위치를 기준으로 움직임
    }

    void Update()
    {
        // 좌우로 왕복하는 움직임
        float newPositionX = transform.position.x + direction * moveSpeed * Time.deltaTime;
        if (Mathf.Abs(newPositionX - startPositionX) >= moveRange)
        {
            direction *= -1; // 방향 전환
        }

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
