using UnityEngine;

public class DecorationSpawner : MonoBehaviour {
    [System.Serializable]
    public struct SpawnableObject {
        //Each Spawnable Object is a prefab with a Spawn Chance
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable(){
        //Starts Spawning at rate between 1-2 seconds
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable(){
        //Stops Spawning
        CancelInvoke();
    }

    private void Spawn(){
        float spawnChance = Random.value;

        foreach (var obj in objects){
            //Essentially if random number is 0-0.2 Spawn First Decoration Type
            //If random number is 0.2-0.4 Spawn Second Decoration Type and so on
            //Is adjustable in Unity
            if (spawnChance < obj.spawnChance){
                GameObject decoration = Instantiate(obj.prefab);
                decoration.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        //Spawns every 1-2 seconds
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}
