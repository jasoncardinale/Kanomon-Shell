using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
    // class properties
    public Kanomon[] playerKanomons;
    public Kanomon[] enemyKanomons;
    public int currentPlayerKanomon;
    public int currentEnemyKanomon;
    public BattleType battleType;

    // constructor
    public Battle(
        Kanomon[] playerKanomons, 
        Kanomon[] enemyKanomons,
        BattleType battleType
    ) {
        this.playerKanomons = playerKanomons;
        this.enemyKanomons = enemyKanomons;
        this.battleType = battleType;
    }
 
    public enum BattleType {
        Wild,
        Challenge
    }

    public void startBattle() {
        currentPlayerKanomon = 0;
        currentEnemyKanomon = 0;
        playerKanomons[currentPlayerKanomon].beginFight();
    }

    public void endBattle() {

    }

    public void playerAttack(int abilityId) {
        Kanomon kanomon = playerKanomons[currentPlayerKanomon];

        if (abilityId < kanomon.abilities.Count)
        {
            int damage = kanomon.attack(kanomon.abilities[abilityId], enemyKanomons[currentEnemyKanomon].type);
            enemyKanomons[currentEnemyKanomon].takeDamage(kanomon.type, damage);
        }
    }

    public void enemyAttack() {
        Kanomon enemy = enemyKanomons[currentEnemyKanomon];
        int damage = enemy.attack(enemy.abilities[Random.Range(0, enemy.abilities.Count)], playerKanomons[currentPlayerKanomon].type);
        playerKanomons[currentPlayerKanomon].takeDamage(playerKanomons[currentPlayerKanomon].type, damage);
    }

    public void swapKanomon(int kanomonId) {
        if(kanomonId < playerKanomons.Length)
        {
            currentPlayerKanomon = kanomonId;
        }
    }

    public bool retreat() {
        if(battleType == BattleType.Wild)
        {
            return true;
        }

        return false;
    }
}
