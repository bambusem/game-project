Archer joan = new Archer("Joan", 100, 100, 1, 60), toph = new Archer("Toph", 100, 100, 1, 60);
Warrior eve = new Warrior("Eve", 100, 100);
Mage allura = new Mage("Allura", 100, 100, 10, 10, 10, false);
DarkMage ethera = new DarkMage("Ethera", 100, 100, false);
LightMage imnakora = new LightMage("Imnakora", 100, 100, 10, 10, 10, 10, 10, 10, false);
RedMage indobus = new RedMage("Indobus", 100, 100, 10, 10, 10, 10, 10, 10, false);
Boss great_grey_wolf_sif = new Boss("Great Grey Wolf Sif", 500, false);

Character[] party = { joan, toph, eve, allura, ethera, imnakora, indobus };

while (great_grey_wolf_sif.health > 0)
{
    foreach (Character character in party)
    {
        if (character.health <= 0)
            continue;

        Console.WriteLine($"\n{character.name}'s turn (HP: {character.health})");

        // Handle different character types
        if (character is Mage mage)
        {
            Console.WriteLine($"Mana: {mage.mana}");
            Console.WriteLine("Choose action: (1) Attack (2) Defend (3) Fireball (4) Lightning (5) Healing");
            string choice = Console.ReadLine() ?? "";

            if (choice == "2")
            {
                mage.isDefending = true;
                Console.WriteLine($"{mage.name} is defending.");
            }
            else if (choice == "3")
            {
                Console.WriteLine(mage.CastFireball(great_grey_wolf_sif));
            }
            else if (choice == "4")
            {
                Console.WriteLine(mage.CastLightning(great_grey_wolf_sif));
            }
            else if (choice == "5")
            {
                Console.WriteLine(mage.CastHealing());
            }
            else
            {
                Console.WriteLine(mage.Attack(great_grey_wolf_sif));
            }
        }
        else if (character is DarkMage darkMage)
        {
            Console.WriteLine($"Dark Mana: {darkMage.darkMana}");
            Console.WriteLine("Choose action: (1) Attack (2) Defend (3) Dark Bolt (4) Life Drain");
            string choice = Console.ReadLine() ?? "";

            if (choice == "2")
            {
                darkMage.isDefending = true;
                Console.WriteLine($"{darkMage.name} is defending.");
            }
            else if (choice == "3")
            {
                Console.WriteLine(darkMage.CastDarkBolt(great_grey_wolf_sif));
            }
            else if (choice == "4")
            {
                Console.WriteLine(darkMage.CastLifeDrain(great_grey_wolf_sif));
            }
            else
            {
                Console.WriteLine(darkMage.Attack(great_grey_wolf_sif));
            }
        }
        else if (character is LightMage lightMage)
        {
            Console.WriteLine($"Light Mana: {lightMage.lightMana}");
            Console.WriteLine("Choose action: (1) Attack (2) Defend (3) Holy Smite (4) Divine Shield (5) Sunburst (6) Healing");
            string choice = Console.ReadLine() ?? "";

            if (choice == "2")
            {
                lightMage.isDefending = true;
                Console.WriteLine($"{lightMage.name} is defending.");
            }
            else if (choice == "3")
            {
                Console.WriteLine(lightMage.CastHolySmite(great_grey_wolf_sif));
            }
            else if (choice == "4")
            {
                Console.WriteLine(lightMage.CastDivineShield());
            }
            else if (choice == "5")
            {
                Console.WriteLine(lightMage.CastSunburst(great_grey_wolf_sif));
            }
            else if (choice == "6")
            {
                Console.WriteLine(lightMage.CastHealing());
            }
            else
            {
                Console.WriteLine(lightMage.Attack(great_grey_wolf_sif));
            }
        }
        else if (character is RedMage redMage)
        {
            Console.WriteLine($"Red Mana: {redMage.redMana}");
            Console.WriteLine("Choose action: (1) Attack (2) Defend (3) Inferno (4) Blizzard (5) Lava (6) Healing");
            string choice = Console.ReadLine() ?? "";

            if (choice == "2")
            {
                redMage.isDefending = true;
                Console.WriteLine($"{redMage.name} is defending.");
            }
            else if (choice == "3")
            {
                Console.WriteLine(redMage.CastInferno(great_grey_wolf_sif));
            }
            else if (choice == "4")
            {
                Console.WriteLine(redMage.CastBlizzard(great_grey_wolf_sif));
            }
            else if (choice == "5")
            {
                Console.WriteLine(redMage.CastLava(great_grey_wolf_sif));
            }
            else if (choice == "6")
            {
                Console.WriteLine(redMage.CastHealing());
            }
            else
            {
                Console.WriteLine(redMage.Attack(great_grey_wolf_sif));
            }
        }
        else if (character is Archer archer)
        {
            Console.WriteLine($"Arrows: {archer.arrowCount}, Fire Arrows: {archer.fireArrow}");
            Console.WriteLine("Choose action: (1) Attack (2) Defend (3) Fire Arrow");
            string choice = Console.ReadLine() ?? "";

            if (choice == "2")
            {
                archer.isDefending = true;
                Console.WriteLine($"{archer.name} is defending.");
            }
            else if (choice == "3")
            {
                Console.WriteLine(archer.CastFireArrow(great_grey_wolf_sif));
            }
            else
            {
                Console.WriteLine(archer.Attack(great_grey_wolf_sif));
            }
        }
        else
        {
            // Default for Warrior
            Console.WriteLine("Choose action: (1) Attack (2) Defend");
            string choice = Console.ReadLine() ?? "";

            if (choice == "2")
            {
                character.isDefending = true;
                Console.WriteLine($"{character.name} is defending.");
            }
            else
            {
                Console.WriteLine(character.Attack(great_grey_wolf_sif));
            }
        }

        if (great_grey_wolf_sif.health <= 0)
            break;
    }

    bool allDead = true;
    foreach (Character character in party)
    {
        if (character.health > 0)
        {
            allDead = false;
            break;
        }
    }

    if (allDead)
    {
        Console.WriteLine("\nAll party members have fallen. Game over.");
        break;
    }

    Random rng = new Random();
    Character[] livingParty = party.Where(c => c.health > 0).ToArray();
    if (livingParty.Length > 0)
    {
        Character target = livingParty[rng.Next(livingParty.Length)];

        if (rng.Next(3) == 0)
        {
            great_grey_wolf_sif.isDefending = true;
            Console.WriteLine($"\n{great_grey_wolf_sif.name} is defending.");
        }
        else
        {
            Console.WriteLine($"\n{great_grey_wolf_sif.name} attacks {target.name}!");
            Console.WriteLine(great_grey_wolf_sif.Attack(target));
        }
    }

    foreach (Character character in party)
    {
        character.isDefending = false;
    }
    great_grey_wolf_sif.isDefending = false;
}

if (great_grey_wolf_sif.health <= 0)
{
    Console.WriteLine("\nVictory! The Great Grey Wolf Sif has been defeated!");
}