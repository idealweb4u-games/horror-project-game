using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AdvancedHorrorFPS
{
    public class SummonUndead : MonoBehaviour
    {
        public int maxSpawnAmount;
        public float spawnSpeed;
        public int currentWave = 0;

        public static UnityEvent onZombieKilled = new UnityEvent();
        [SerializeField] private GameObject undead;
        [SerializeField] private Vector3[] spawnLocations;
        [SerializeField] private GameObject[] particles;
        [SerializeField] private Dialogue dialogue;
        [SerializeField] private GameObject removeDarkness;

        private float timeSinceLastSpawn;
        private int currentSpawnAmmount = 0;
        private int amountLeftToSpawn;
        private int zombiesAlive;
        private bool waveActive = false;
        private bool canSpawn = true;
        private bool lastWave = false;
        private bool isDefeated = false;

        private void Awake()
        {
            onZombieKilled.AddListener(OnZombieDeath); // add listener to call for zombie deaths
            amountLeftToSpawn = maxSpawnAmount;
        }

        public void StartSummoning()
        {
            StartCoroutine(SpawnerManager());
        }

        private void Update()
        {
            if (!waveActive) return;
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= spawnSpeed && amountLeftToSpawn > 0) 
            {
                SummonEnemy();
                amountLeftToSpawn--;
                zombiesAlive++;
                timeSinceLastSpawn = 0f;
            }
            if (zombiesAlive == 0 && amountLeftToSpawn == 0 && !lastWave)
            {
                TouchpadFPSLook.Instance.fCamShakeImpulse = 0.5f;
                lastWave = true;
                dialogue.NextDialogue();
            }
            if (zombiesAlive == 0 && amountLeftToSpawn == 0 && lastWave && isDefeated)
            {
                //isDefeated = true;
                waveActive = false;
                dialogue.FinalDialogue();
            }
        }

        private IEnumerator SpawnerManager()
        {
            yield return new WaitForSeconds(3f);
            // ADD: Add dialogue here telling what player must do
            // ADD: Camera zoom in on spectre
            currentWave++;
            if (!lastWave)
            {
                foreach(GameObject flame in particles)
                {
                    flame.SetActive(true);
                }
                waveActive = true;
            }
            else
            {
                Debug.Log("Last Wave");
                spawnSpeed -= 0.5f;
                amountLeftToSpawn = maxSpawnAmount + 5;
            }

            if (currentWave == 3)
            {
                isDefeated = true;                          
                removeDarkness.SetActive(true);
                Destroy(gameObject);
            }
        }

        public void OnZombieDeath()
        {
            zombiesAlive--;
            Debug.Log("Zombies left to spawn: " + amountLeftToSpawn);
            Debug.Log("Zombies alive: " + zombiesAlive);

            if (zombiesAlive == 0 && amountLeftToSpawn == 0 && currentWave >= 2)
            {
                Debug.Log("TEST!!!!!");
                dialogue.FinalDialogue();
            }
        }


        public void SummonEnemy()
        {
            // Use object pooling?? Might not be needed if we don't have large amounts of enemies
            GameObject zombie = Instantiate(undead, spawnLocations[Random.Range(0, spawnLocations.Length)], Quaternion.identity);
        }
    }
}
