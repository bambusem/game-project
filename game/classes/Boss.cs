public class Boss : Character
{
    private static Random rng = new Random();

    public Boss(
        string name,
        int health,
        bool isDefending = false
    )
    : base(name, health, isDefending)
    {
    }

    public new string Attack(Character target)
    {
        int damage = 25;

        bool crit = rng.Next(13) == 0;
        if (crit)
            damage *= 2;

        int defenseBlock = 0;

        if (target.isDefending)
        {
            // Check for Divine Shield defense block
            if (target is LightMage lightMage && lightMage.defenseBlock > 0)
            {
                defenseBlock = lightMage.defenseBlock;
            }
            else
            {
                defenseBlock = rng.Next(3, 9);
            }
            damage -= defenseBlock;
        }

        if (damage < 0)
            damage = 0;

        target.health -= damage;

        if (crit)
            return $"{name} CRITS {target.name} for {damage} damage (-{defenseBlock} blocked). ({target.health} HP left)";
        else
            return $"{name} hits {target.name} for {damage} damage (-{defenseBlock} blocked). ({target.health} HP left)";
    }
}