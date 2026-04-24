public class LightMage : Character
{
    public int lightMana;
    public int spellOfHealing;
    public int spellOfLight;
    public int spellOfRadiance;
    public int spellOfHolySmite;
    public int spellOfDivineShield;
    public int spellOfSunburst;
    public int defenseBlock;
    private static Random rng = new Random();

    public LightMage(
        string name,
        int health,
        int lightMana,
        int spellOfHealing,
        int spellOfLight,
        int spellOfRadiance,
        int spellOfHolySmite,
        int spellOfDivineShield,
        int spellOfSunburst,
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
        this.lightMana = lightMana;
        this.spellOfHealing = spellOfHealing;
        this.spellOfLight = spellOfLight;
        this.spellOfRadiance = spellOfRadiance;
        this.spellOfHolySmite = spellOfHolySmite;
        this.spellOfDivineShield = spellOfDivineShield;
        this.spellOfSunburst = spellOfSunburst;
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

    public string CastHolySmite(Character target)
    {
        if (lightMana >= spellOfHolySmite)
        {
            lightMana -= spellOfHolySmite;
            int damage = 50;
            target.health -= damage;
            return $"{name} casts Holy Smite on {target.name} for {damage} damage! ({target.health} HP left)";
        }
        return $"{name} not enough light mana!";
    }

    public string CastDivineShield()
    {
        if (lightMana >= spellOfDivineShield)
        {
            lightMana -= spellOfDivineShield;
            isDefending = true;
            defenseBlock = 50;
            return $"{name} casts Divine Shield and blocks {defenseBlock} damage!";
        }
        return $"{name} not enough light mana!";
    }

    public string CastSunburst(Character target)
    {
        if (lightMana >= spellOfSunburst)
        {
            lightMana -= spellOfSunburst;
            int damage = 50;
            target.health -= damage;
            return $"{name} casts Sunburst on {target.name} for {damage} damage! ({target.health} HP left)";
        }
        return $"{name} not enough light mana!";
    }

    public string CastHealing()
    {
        if (lightMana >= spellOfHealing)
        {
            lightMana -= spellOfHealing;
            int healAmount = 50;
            health += healAmount;
            return $"{name} casts Healing and recovers {healAmount} HP! ({health} HP now)";
        }
        return $"{name} not enough light mana!";
    }
}
