using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Warewolf : Hero
    {
        private int attackCount = 0;
        public Warewolf(string name, string weapon) : base(name, weapon)
        {

        }
        public override void TakeDamage(int incomingDamage)
        {
            if (ThrowDice(30)) incomingDamage = 0;//po sushtiq nachin kato pri Rogue
            base.TakeDamage(incomingDamage);
        }
        public override int Attack()
        {
            int attack = base.Attack();
            attackCount++;

            if (attackCount == 3)
            {
                int attackIncrease = Random.Shared.Next(40, 81);
                attack += attackIncrease; //Uvelichvam atakata na 3tiq udar 
                attackCount = 0; 
            }

            return attack;

        }
    }
}
