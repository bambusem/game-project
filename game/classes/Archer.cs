public class Archer : Character
{
    public int mana;
    public int bow;
    public int arrowDamage;
    public int arrowCount;
    public int fireArrow;
    public int fireArrowDamage;
    private static Random rng = new Random();

    public Archer(
        string name,
        int health,
        int mana,
        int bow,
        int arrowCount = 60,
        int fireArrow = 30,
        int fireArrowDamage = 20,
        bool isDefending = false
    )
    : base(
        name,
        health,
        isDefending
    )
    {
        this.mana = mana;
        this.bow = bow;
        this.arrowDamage = 10;
        this.isDefending = isDefending;
        this.arrowCount = arrowCount;
        this.fireArrow = fireArrow;
        this.fireArrowDamage = fireArrowDamage;
    }

    public override string Attack(Character target)
    {
        int damage = rng.Next(arrowDamage, arrowDamage + bow + 1);

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
        arrowCount--;

        if (crit)
            return $"{name} CRITS {target.name} with an arrow for {damage} damage (-{defenseBlock} blocked). ({target.health} HP left) [{arrowCount} arrows left]";
        else
            return $"{name} shoots {target.name} for {damage} damage (-{defenseBlock} blocked). ({target.health} HP left) [{arrowCount} arrows left]";
    }

    public string CastFireArrow(Character target)
    {
        if (fireArrow > 0)
        {
            fireArrow--;
            int damage = rng.Next(fireArrowDamage, fireArrowDamage + bow + 1);
            target.health -= damage;
            return $"{name} shoots {target.name} with a fire arrow for {damage} damage! ({target.health} HP left) [{fireArrow} fire arrows left]";
        }
        return $"{name} is out of fire arrows!";
    }

}