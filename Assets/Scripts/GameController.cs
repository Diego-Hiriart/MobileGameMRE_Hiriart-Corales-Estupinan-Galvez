using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    private PlayerController player;
    [SerializeField]
    private GameObject canvas;
    private UIController ui;
    private int maxPoints = 14;
    private float prevHealth = 0;
    private int prevPoints = 0;
    private float prevSpeed = 0;
    private int prevLives = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.player = this.playerObj.GetComponent<PlayerController>();
        this.ui = this.canvas.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player.GetPlayerInfo().GetHealth()!=this.prevHealth)
        {
            this.prevHealth = this.player.GetPlayerInfo().GetHealth();
            this.ui.UpdateHealth(this.prevHealth);
        }

        if (this.player.GetPlayerInfo().GetLives() != this.prevLives)
        {
            this.prevLives = this.player.GetPlayerInfo().GetLives();
            this.ui.UpdateLives(this.prevLives);
        }

        if (this.player.GetPlayerInfo().GetPickUpCount() != this.prevPoints)
        {
            this.prevPoints = this.player.GetPlayerInfo().GetPickUpCount();
            this.ui.UpdatePoints(this.prevPoints);
        }

        if (this.player.GetPlayerInfo().GetSpeed() != this.prevSpeed)
        {
            this.prevSpeed = this.player.GetPlayerInfo().GetSpeed();
            this.ui.UpdateSpeed(this.prevSpeed);
        }

        if (this.player.GetPlayerInfo().GetLives() <= 0)
        {           
            this.ui.WinLoseMessage(false);//False if game is lost
            Time.timeScale = 0;
        }

        if (this.player.GetPlayerInfo().GetPickUpCount() >= this.maxPoints)
        {           
            this.ui.WinLoseMessage(true);//False if game is won

        }
    }
}
