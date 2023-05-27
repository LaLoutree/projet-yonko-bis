using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesManagement : MonoBehaviour
{
    [SerializeField] private GameObject Endingdefaite;
    [SerializeField] public float zombie_number = 15f;
    [SerializeField] public int zombieRemains = 0;
    [SerializeField] private Player player;
    public int round = 0;
    public Transform[] zombieSpawnsLocation;
    private float TimeBetweenWaves = 5f;
    private float countdown = 5f;
    private float multiplier = 1;
    public GameObject zombie;
    [SerializeField] public List<Player> deadPlayers = new List<Player>();
    [SerializeField] public List<Player> alivePlayers = new List<Player>();
    void Update()
    {
        if (alivePlayers.Count == 0)
        {
            Endingdefaite.SetActive(true);
            return;
        }
        if (zombieRemains <= 0)
        {
            if (countdown <= 0)
            {
                zombie_number *= multiplier;
                SpawnWaves((int)zombie_number);
                multiplier *= 1.2f;
                round++;
                countdown = TimeBetweenWaves;
            }
            else
            {
                countdown -= Time.deltaTime;
            }
            RespawnDeadPlayers(deadPlayers);
            foreach (var player in alivePlayers)
            {
                player.questAvailable = true;
            }
        }

        foreach (var player in alivePlayers)
        {
            if (player.haveQuest)
            {
                if (player.quest.IsComplete())
                {
                    player.quest.RewardPlayer();
                }
            }
        }
    }
    
    void SpawnWaves(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 randomSpawnAround = zombieSpawnsLocation[Random.Range(0, zombieSpawnsLocation.Length)].position;
            Instantiate(zombie, randomSpawnAround, Quaternion.identity);
            zombieRemains++;
        }
    }

    void RespawnDeadPlayers(List<Player> deadPlayer)
    {
        foreach (Player player in deadPlayer)
        {
            Vector3 spawnPoint = new Vector3(165,1,135);
            player.transform.position = spawnPoint;
            alivePlayers.Add(player);
        }
        deadPlayers.Clear();
    }
}
