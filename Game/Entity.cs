using System;

namespace Game
{
    class Entity
    {
        public int hp;
        public int maxHp;
        public int damage;
        public string name;

        public Entity(int maxHp, int damage, string name)
        {
            this.maxHp = maxHp;
            this.hp = this.maxHp;
            this.damage = damage;
            this.name = name;
        }

        public void Attack(Entity enemy, int random)
        {
            if (random <= 0 )
            {
                Console.WriteLine(this.name + " have missed his attack.");
            }
            else if ( random >= this.damage )
            {
                Console.WriteLine(this.name + " hit critical attack on " + enemy.name + " for " + (random + 5) + " damage!");
                enemy.Damage(random + 5);
            }
            else
            {
                Console.WriteLine(this.name + " have attacked " + enemy.name + " for " + random + " damage.");
                enemy.Damage(random);
            }
        }

        public void Damage(int damage)
        {
            this.hp -= damage;
        }

        public void Reroll(int maxHp, int damage, string name)
        {
            Console.WriteLine(this.name + " was slayed!");

            this.maxHp = maxHp;
            this.hp = maxHp;
            this.damage = damage;
            this.name = name;

            Console.WriteLine("New enemy appeared " + this.name);
        }
    }
}
