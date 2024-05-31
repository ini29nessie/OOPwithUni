namespace ArenaGame
{
    public class Arena
    {
        public Hero HeroA { get; private set; }
        public Hero HeroB { get; private set; }

        public Arena(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }

        public Hero Battle()
        {
            Hero attacker, defender;
            
            if (Random.Shared.Next(2) == 0)
            {
                attacker = HeroA;
                defender = HeroB;
            }
            else
            {
                attacker = HeroB;
                defender = HeroA;
            }
            while (true)
            {
                int damage = attacker.Attack();
                defender.TakeDamage(damage);
                Console.WriteLine($"{attacker.Name} ({attacker.Health})HP deals {damage} damage to {defender.Name} ({defender.Health})HP");
                if (defender.IsDead) return attacker;
                //Swap the heroes
                Hero tmp = attacker;
                attacker = defender;
                defender = tmp;
            }
        }
    }
}
