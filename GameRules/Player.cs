using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRules
{
    public class Player
    {
        private float health;
        private int lives;
        private int pickUpCount;
        private float speed;

        public float Health { get { return this.health; } }
        public int Lives { get { return this.lives; } }
        public int PickUpCount { get { return this.pickUpCount; } }
        public float Speed { get { return this.speed; } }

        public Player() {
            this.health = 100;
            this.lives = 3;
            this.pickUpCount = 0;
            this.speed = 4f;
        }

        public Player(float health, int lives, int pickUps, float speed)
        {
            this.health = health;
            this.lives = lives;
            this.pickUpCount = pickUps;
            this.speed = speed;
        }

        public void SetHealth(float value)
        {
            this.health = value;
        }

        public void SetLives(int number)
        {
            this.lives = number;
        }

        public void SetPickUpCount(int count)
        {
            this.pickUpCount = count;
        }

        public void SetSpeed(float value)
        {
            this.speed = value;
        }

        public float GetHealth()
        {
            return this.health;
        }

        public int GetLives()
        {
            return this.lives;
        }

        public int GetPickUpCount()
        {
            return this.pickUpCount;
        }

        public float GetSpeed()
        {
            return this.speed;
        }
    }
}
