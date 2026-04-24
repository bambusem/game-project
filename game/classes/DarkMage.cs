public class DarkMage : Character
{
    public int spellOfDarkLBolt;
    public int spellOfLifeDrain;
    public int spellOfDarkLBoltDamage;
    public int spellOfDeathManipulation;
    public int darkMana;
    private static Random rng = new Random();

    public DarkMage(
        string name,
        int health,
        int darkMana,
        bool isDefending = false)
        : base(
            name,
            health,
            isDefending
        )
    {
        this.darkMana = darkMana;
        this.name = name;
        this.health = health;
        this.isDefending = isDefending;
    }

    public new string Attack(Character target)
    {
        int damage = rng.Next(10, 21);

        bool crit = rng.Next(13) == 0;
        if (crit)
            damage *= 2;

        int defenseBlock = 0;

        if (target.isDefending)
        {
            defenseBlock = rng.Next(3, 9);
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

    public string CastDarkBolt(Character target)
    {
        if (darkMana >= 10)
        {
            darkMana -= 10;
            int damage = 50;
            target.health -= damage;
            return $"{name} casts Dark Bolt on {target.name} for {damage} damage! ({target.health} HP left)";
        }
        return $"{name} not enough dark mana!";
    }

    public string CastLifeDrain(Character target)
    {
        if (darkMana >= 15)
        {
            darkMana -= 15;
            int damage = 50;
            int heal = damage;
            target.health -= damage;
            health += heal;
            return $"{name} casts Life Drain on {target.name} for {damage} damage and heals {heal} HP! ({health} HP now)";
        }
        return $"{name} not enough dark mana!";
    }

    public string CastDeathManipulation(Character target)
    {
        if (darkMana >= 12)
        {
            darkMana -= 12;
            int damage = rng.Next(10, 16);
            target.health -= damage;
            return $"{name} summons an undead to attack {target.name} and deals {damage} damage! ({target.health} HP left)";
        }
        return $"{name} not enough dark mana!";
    }
}