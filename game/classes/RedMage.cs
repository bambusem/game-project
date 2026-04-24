public class RedMage : Character
{
    public int spellOfHealing;
    public int spellOfFireball;
    public int spellOfLightning;
    public int spellOfInferno;
    public int spellOfBlizzard;
    public int spellOfLava;
    public int redMana;
    private static Random rng = new Random();

    public RedMage(
        string name,
        int health,
        int redMana,
        int spellOfHealing,
        int spellOfFireball,
        int spellOfLightning,
        int spellOfInferno,
        int spellOfBlizzard,
        int spellOfLava,
        bool isDefending = false
        )
        : base(
            name,
            health,
            isDefending
        )
    {
        this.name = name;
        this.health = health;
        this.redMana = redMana;
        this.spellOfHealing = spellOfHealing;
        this.spellOfFireball = spellOfFireball;
        this.spellOfLightning = spellOfLightning;
        this.spellOfInferno = spellOfInferno;
        this.spellOfBlizzard = spellOfBlizzard;
        this.spellOfLava = spellOfLava;
        this.isDefending = false;
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

    public string CastInferno(Character target)
    {
        if (redMana >= spellOfInferno)
        {
            redMana -= spellOfInferno;
            int damage = 50;
            target.health -= damage;
            return $"{name} casts Inferno on {target.name} for {damage} damage! ({target.health} HP left)";
        }
        return $"{name} not enough red mana!";
    }

    public string CastBlizzard(Character target)
    {
        if (redMana >= spellOfBlizzard)
        {
            redMana -= spellOfBlizzard;
            int damage = 50;
            target.health -= damage;
            return $"{name} casts Blizzard on {target.name} for {damage} damage! ({target.health} HP left)";
        }
        return $"{name} not enough red mana!";
    }

    public string CastLava(Character target)
    {
        if (redMana >= spellOfLava)
        {
            redMana -= spellOfLava;
            int damage = 50;
            target.health -= damage;
            return $"{name} casts Lava on {target.name} for {damage} damage! ({target.health} HP left)";
        }
        return $"{name} not enough red mana!";
    }

    public string CastHealing()
    {
        if (redMana >= spellOfHealing)
        {
            redMana -= spellOfHealing;
            int healAmount = 50;
            health += healAmount;
            return $"{name} casts Healing and recovers {healAmount} HP! ({health} HP now)";
        }
        return $"{name} not enough red mana!";
    }
}