public class Character
{
    public string name;
    public int health;
    public bool isDefending;
    private static Random rng = new Random();

    public Character(
        string name,
        int health,
        bool isDefending = false
    )
    {
        this.name = name;
        this.health = health;
        this.isDefending = isDefending;
    }

    public virtual string Attack(Character target)
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
}