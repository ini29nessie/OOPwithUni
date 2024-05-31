namespace ArenaGame
{
    public class Hero
    {
        public string Name { get; private set; }

        public int Health { get; private set; }

        public int Strength { get; private set; }

        protected int StartingHealth { get; private set; }

        public bool IsDead { get { return Health <= 0; } }

        public string Weapon { get; private set; }

        public Hero(string name, string weapon)
        {
            Name = name;
            Health = 500;
            StartingHealth = Health;
            Strength = 100;
            Weapon = weapon;
        }

        public virtual int Attack()
        {
           Strength= (Strength * Random.Shared.Next(80, 121)) / 100;//izchislqvam damage na hero
            switch (Weapon)// v zavisimost na orujieto mi se ovishava Strength
            {
                case "sword": Strength += 30;
                    break;
                case "shield": Strength +=5;
                    break;
                case "bow": Strength += 15;
                    break;
                default: Strength+=0;
                    break;                
            }
            return Strength;
        }

        public virtual void TakeDamage(int incomingDamage)//polzvam izchisleniq damage na atakuvasht geroi za da vidq kolko jivot mi se otnema
        {
            if (incomingDamage < 0) return;

            switch (Weapon)
            {
                case "sword":
                    // nqmam promqna incomingDamage
                    break;

                case "shield":
                    incomingDamage -= 40;
                    if (incomingDamage < 0)//ako stoinostta stane po- malka ot nula, ne vzimam damage
                    {
                        incomingDamage = 0;
                    }
                    break;

                case "bow":
                    incomingDamage -= 15;
                    if (incomingDamage < 0)
                    {
                        incomingDamage = 0;
                    }
                    break;

                default:
                    break;
            }

            Health -= incomingDamage;
        }



        protected bool ThrowDice(int chance)
        {
            int dice = Random.Shared.Next(101);
            return dice <= chance;
        }

        protected void Heal(int value)
        {
            Health = Health + value;
            if (Health > StartingHealth) Health = StartingHealth;
        }
    }
}
