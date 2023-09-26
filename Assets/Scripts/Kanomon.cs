using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public string name;
    public int damage;
    public int healing;

    public Ability(string name, int damage, int healing) 
    { 
        this.name = name;
        this.damage = damage;
        this.healing = healing;
    }
}

public class Type
{
    public id type;

    public Type(id myType) { type = myType; }

    public enum id
    {
        Leaf,
        Blaze,
        Hydro,
        Wild,
        Magic,
        Legendary
    }

    public id getWeakness()
    {
        switch(type)
        {
            case id.Leaf:
                return id.Blaze;
            case id.Blaze:
                return id.Hydro;
            case id.Hydro:
                return id.Leaf;
            case id.Wild:
                return id.Legendary;
            case id.Magic:
                return id.Wild;
            case id.Legendary:
                return id.Magic;
            default:
                return id.Wild;
        }
    }
}

public class Kanomon
{
    public string name;
    public int maxHP;
    public int level;
    public int id;
    public int exp;
    public int evolveLevel;
    public Type type;
    public List<Ability> abilities;
    public GameObject gameObject;
    public Kanomon nextEvolve;

    public List<Ability> forgottenMoves = new List<Ability>();

    public Kanomon(
        string name,
        int maxHP,
        int level,
        int id,
        int exp,
        int evolveLevel,
        Type[] types,
        List<Ability> abilities,
        GameObject gameObject,
        Kanomon nextEvolve
    ) {
        this.name = name;
        this.maxHP = maxHP;
        this.level = level;
        this.id = id;
        this.exp = exp;
        this.evolveLevel = evolveLevel;
        this.types = types;
        this.abilities = abilities;
        this.gameObject = gameObject;
        this.nextEvolve = nextEvolve;

        currentHP = maxHP;
    }

    public Kanomon fromJson(string name) {

    }

    int tempExp = 0;
    int currentHP = 0;

    public int attack(Ability ability, Type enemytype)
    {
        currentHP += ability.healing;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        tempExp += 5;
        if (type.getWeakness() == enemytype.type)
        {
            tempExp += 5;
        }

        return ability.damage;
    }

    public int takeDamage(Type enemyType, int damage)
    {
        int finalDamange = damage;
        if(enemyType.type == type.getWeakness())
        {
            finalDamange = (int)(finalDamange * 1.5);
        }

        currentHP -= finalDamange;
        if(currentHP < 0)
        {
            currentHP = 0;
        }
        return currentHP;
    }

    public void endFight(bool didWin)
    {
        if(didWin)
        {
            exp += tempExp;

            if(exp >= 100)
            {
                exp -= 100;
                level++;

                if(level == evolveLevel)
                {
                    evolve();
                }

                levelUpDisplay();
            }
        }
    }

    public void beginFight()
    {
        tempExp = 0;
    }

    public void levelUpDisplay()
    {
        // visuals for leveling up
    }

    public void winDisplay()
    {
        // visuals for winning
    }

    public void lossDisplay()
    {
        // visuals for losing
    }

    public void fullHeal()
    {
        currentHP = maxHP;
    }

    public void evolve()
    {
        name = nextEvolve.name;
        maxHP = nextEvolve.maxHP;
        exp = nextEvolve.exp;
        evolveLevel = nextEvolve.evolveLevel;
        gameObject = nextEvolve.gameObject;
        nextEvolve = nextEvolve.nextEvolve;

        currentHP = maxHP;

        evolveDisplay();
    }

    public void learnMove(Ability newMove)
    {
        if(abilities.Count < 4)
        {
            abilities.Add(newMove);
        }
    }

    public void forgetMove(Ability move)
    {
        if(abilities.Contains(move))
        {
            abilities.Remove(move);
        }

        forgottenMoves.Add(move);
    }

    public void evolveDisplay()
    {

    }
}
