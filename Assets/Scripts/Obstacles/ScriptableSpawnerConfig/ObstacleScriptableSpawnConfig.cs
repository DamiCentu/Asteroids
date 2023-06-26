using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleScriptableSpawnConfig", menuName = "Scriptable/ObstacleSpawnConfig/SpawnConfig")]
public class ObstacleScriptableSpawnConfig : ScriptableObject
{
    [SerializeField] private float spawnMinTimeRate = 1f;
    [SerializeField] private float spawnMaxTimeRate = 2f;
    [SerializeField] private float spawnOffsetFromBorders = 3f;
    [SerializeField] private AbstractObstacle obstaclePrefab;
    [SerializeField] private string spawnHandlerClass;
    
    public AbstractObstacle ObstaclePrefab => obstaclePrefab;
    public float SpawnMaxTimeRate => spawnMaxTimeRate;
    public float SpawnMinTimeRate => spawnMinTimeRate;
    public float SpawnOffsetFromBorders => spawnOffsetFromBorders;
    public string SpawnHandlerClass => spawnHandlerClass;
}