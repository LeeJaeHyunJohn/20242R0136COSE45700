using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool isGameOver = false;

    [SerializeField] private TextMeshProUGUI textGoal;
    [SerializeField] private GameObject btnRetry;

    [SerializeField] private Color green;
    [SerializeField] private Color red;

    [Header("Sound Clips")]
    [SerializeField] private AudioClip gameOverSound; // Game Over 사운드
    [SerializeField] private AudioClip successSound;  // Success 사운드
    [SerializeField] private AudioClip retrySound;    // Retry 사운드

    private AudioSource audioSource;

    public int goal;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        textGoal.SetText(goal.ToString());
        audioSource = GetComponent<AudioSource>();
    }

    public void DecreaseGoal()
    {
        goal -= 1;
        textGoal.SetText(goal.ToString());

        if (goal <= 0)
        {
            SetGameOver(true);
        }
    }

    public void SetGameOver(bool success)
    {
        if (isGameOver == false)
        {
            isGameOver = true;

            Camera.main.backgroundColor = success ? green : red;

            // 성공 및 실패 사운드 재생
            if (success)
            {
                audioSource.PlayOneShot(successSound);
            }
            else
            {
                audioSource.PlayOneShot(gameOverSound);
            }

            Invoke("ShowRetryButton", 1f);
        }
    }

    void ShowRetryButton()
    {
        btnRetry.SetActive(true);
    }

    public void Retry()
    {
        // Retry 사운드 재생
        audioSource.PlayOneShot(retrySound);

        SceneManager.LoadScene("SampleScene");
    }
}

