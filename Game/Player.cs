using System;

namespace Game
{
    internal class Player : Entity
    {
        public int healingPower;
        public int slayedEnemys;
        public Player(int maxHp, int damage, string name, int healingPower) : base(maxHp, damage, name)
        {
            this.healingPower = healingPower;
            this.slayedEnemys = 0;
        }

        public void Heal(int random)
        {
            this.hp += random;
            Console.WriteLine(this.name + " heald for " + random + " hp.");
            if (this.hp >= this.maxHp)
            {
                this.hp = this.maxHp;
            }
        }

        public void Status()
        {
            Console.WriteLine($"{this.name}\n{this.hp}/{this.maxHp}\n{this.damage}\n{this.healingPower}");
        }

    }
}
