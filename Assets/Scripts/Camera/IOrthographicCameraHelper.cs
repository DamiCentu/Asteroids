using UnityEngine;

public interface IOrthographicCameraHelper
{
    Vector2 GetRandomSpawnPosition(ScreenSides randomSide, float borderSpawnOffset);
    public float CameraHeight { get; }
    public float CameraWidth { get; }
}