using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanopad
{
    public List<string> knownKanomon = new List<string>();
    public Dictionary<string, List<Kanomon>> ownedKanonon = new Dictionary<string, List<Kanomon>>();
    public List<Kanomon> playerTeam = new List<Kanomon>();

    public void find(Kanomon kanomon)
    {
        if(!knownKanomon.Contains(kanomon.name))
        {
            knownKanomon.Add(kanomon.name);
        }

        ownedKanonon[kanomon.name].Add(kanomon);

        addToTeam(kanomon);
    }

    public bool release(Kanomon kanomon)
    {
        if(ownedKanonon[kanomon.name].Contains(kanomon))
        {
            ownedKanonon[kanomon.name].Remove(kanomon);
            return true;
        }
        return false;
    }

    public bool trade(Kanomon accepting, Kanomon giving) 
    {
        if(release(giving))
        {
            find(accepting);
            return true;
        }
        return false;
    }

    public void addToTeam(Kanomon kanomon)
    {
        if(!playerTeam.Contains(kanomon) && playerTeam.Count < 6)
        {
            playerTeam.Add(kanomon);
        }
    }

    public void replaceTeamMember(Kanomon newKanomon, Kanomon oldKanomon)
    {
        if(playerTeam.Contains(oldKanomon) && !playerTeam.Contains(newKanomon))
        {
            playerTeam.Remove(oldKanomon);
            playerTeam.Add(newKanomon);
        }
    }

}
