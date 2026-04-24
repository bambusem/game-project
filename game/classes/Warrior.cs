public class Warrior : Character
{
    public int mana;
    public Warrior(
        string name,
        int health,
        int mana,
        bool isDefending = false
        ) : base(name, health, isDefending)
    {
        this.name = name;
        this.health = health;
        this.mana = mana;
        this.isDefending = isDefending;
    }
}