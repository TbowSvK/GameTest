using System;

namespace Game
{
    internal class Enemy : Entity
    {
        public Enemy(int maxHp, int damage, string name) : base(maxHp, damage, name) { }

        public void Status()
        {
            Console.WriteLine($"{this.name}\n{this.hp}/{this.maxHp}\n{this.damage}");
        }
    }
}
