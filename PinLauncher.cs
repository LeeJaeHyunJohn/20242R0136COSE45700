using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinLauncher : MonoBehaviour
{
    [SerializeField] private GameObject pinObject;
    [SerializeField] private AudioClip pinShootSound; // 핀 발사 사운드

    private Pin currPin;
    private AudioSource audioSource;

    void Start()
    {
        PreparePin();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)
            && currPin != null
            && GameManager.instance.isGameOver == false)
        {
            // 핀 발사
            currPin.Launch();

            // 사운드 재생
            audioSource.PlayOneShot(pinShootSound);

            currPin = null; // 한 번 쏜 핀은 다시 쓸 수 없으므로 초기화
            Invoke("PreparePin", 0.2f);
        }
    }

    void PreparePin()
    {
        if (GameManager.instance.isGameOver == false)
        {
            GameObject pin = Instantiate(pinObject, transform.position, Quaternion.identity);
            currPin = pin.GetComponent<Pin>();
        }
    }
}

