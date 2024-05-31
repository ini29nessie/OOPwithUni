using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Magician: Hero
    {
        int ExtraDamageChance = 30;
        public int Mana { get; private set; }
        public Magician() : this("Merlin", "shield")
        {

        }

        public Magician(string name, string weapon) : base(name, weapon)
        {
            Mana = 100;
        }
        public override void TakeDamage(int incomingDamage)
        {
            base.TakeDamage(incomingDamage);
        }

        public override int Attack()
        {
            if (Mana <= 0)
            {
                Console.WriteLine($"{Name} is out of mana and cannot attack.");
                return 0; 
            }

            int attack = base.Attack();
            if (ThrowDice(ExtraDamageChance))
                attack = attack * 170 / 100;

            int manaCost = Random.Shared.Next(5, 11); // Random izrazhodvane na mana
            Mana -= manaCost;
            if (Mana < 0) Mana = 0;

            return attack;
        }
    }
}
