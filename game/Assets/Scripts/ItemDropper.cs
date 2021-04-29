using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public List<GameObject> Spawns;
    public List<int> Probabilities;
    public float DropProbability;
    private int probabilitiesTotal;
    void Start()
    {
        probabilitiesTotal = GetProbabilitiesTotal();
    }

    private void OnDestroy()
    {
        if (DropProbability > Random.Range(0.0f, 1.0f))
        {
            Instantiate(GetRandomGameObjectSpawn(), this.gameObject.transform.position, Quaternion.identity);
        }
    }

    private int GetProbabilitiesTotal()
    {
        int output = 0;
        foreach (int probability in Probabilities)
        {
            output += probability;
        }
        return output;
    }

    private GameObject GetRandomGameObjectSpawn()
    {
        int valueIndex = Random.Range(0, probabilitiesTotal);
        int currentIndex = 0;
        int i;
        for (i = 0; i < Probabilities.Count; ++i)
        {
            currentIndex += Probabilities[i];
            if (currentIndex >= valueIndex) return Spawns[i];
        }
        return Spawns[Spawns.Count - 1];
    }
}
