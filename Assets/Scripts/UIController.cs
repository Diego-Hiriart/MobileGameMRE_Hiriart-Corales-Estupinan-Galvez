using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI health;
    [SerializeField]
    private TextMeshProUGUI lives;
    [SerializeField]
    private TextMeshProUGUI points;
    [SerializeField]
    private TextMeshProUGUI speed;
    [SerializeField]
    private GameObject winLoseObj;
    private TextMeshProUGUI winLose;

    // Start is called before the first frame update
    void Start()
    {
        this.winLoseObj.SetActive(false);
    }

    public void UpdateHealth(float value)
    {
        this.health.text = $"Health: {Mathf.Floor(value)}";
    }

    public void UpdateLives(int lives)
    {
        this.lives.text = $"Lives: {lives}";
    }

    public void UpdatePoints(int points)
    {
        this.points.text = $"Points: {points}";
    }

    public void UpdateSpeed(float value)
    {
        this.speed.text = $"Speed: {value.ToString("F2")}";
    }

    public void WinLoseMessage(bool wonLost)
    {
        this.winLoseObj.SetActive(true);
        if (wonLost)
        {
            this.health.text = "You Won!";
        }
        else
        {
            this.health.text = "You Lost";
        }
    }
}
