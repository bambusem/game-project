public class Mage : Character
{
    public int mana;
    public int spellOfHealing;
    public int spellOfFireball;
    public int spellOfLightning;
    private static Random rng = new Random();

    public Mage(
        string name,
        int health,
        int mana,
        int spellOfHealing,
        int spellOfFireball,
        int spellOfLightning,
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
        this.mana = mana;
        this.spellOfHealing = spellOfHealing;
        this.spellOfFireball = spellOfFireball;
        this.spellOfLightning = spellOfLightning;
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

    public string CastFireball(Character target)
    {
        if (mana >= spellOfFireball)
        {
            mana -= spellOfFireball;
            int damage = 50;
            target.health -= damage;
            return $"{name} casts Fireball on {target.name} for {damage} damage! ({target.health} HP left)";
        }
        return $"{name} not enough mana for Fireball!";
    }

    public string CastLightning(Character target)
    {
        if (mana >= spellOfLightning)
        {
            mana -= spellOfLightning;
            int damage = 50;
            target.health -= damage;
            return $"{name} casts Lightning on {target.name} for {damage} damage! ({target.health} HP left)";
        }
        return $"{name} not enough mana for Lightning!";
    }

    public string CastHealing()
    {
        if (mana >= spellOfHealing)
        {
            mana -= spellOfHealing;
            int healAmount = 50;
            health += healAmount;
            return $"{name} casts Healing and recovers {healAmount} HP! ({health} HP now)";
        }
        return $"{name} not enough mana for Healing!";
    }
}