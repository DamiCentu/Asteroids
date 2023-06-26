using UnityEngine;

public class OrthographicCameraHelper : IOrthographicCameraHelper
{
    public float CameraHeight { get; private set; }
    public float CameraWidth { get; private set; }
    
    public OrthographicCameraHelper(Camera camera)
    {
        CameraHeight = camera.orthographicSize;
        CameraWidth = CameraHeight * camera.aspect;
    }
    
    public Vector2 GetRandomSpawnPosition(ScreenSides randomSide, float borderSpawnOffset)
    {
        float spawnX = 0f, spawnY = 0f;

        switch (randomSide)
        {
            case ScreenSides.Top:
                spawnX = Random.Range(-CameraWidth, CameraWidth);
                spawnY = CameraHeight + borderSpawnOffset;
                break;
            case ScreenSides.Right:
                spawnX = CameraWidth + borderSpawnOffset;
                spawnY = Random.Range(-CameraHeight, CameraHeight);
                break;
            case ScreenSides.Bottom:
                spawnX = Random.Range(-CameraWidth, CameraWidth);
                spawnY = -CameraHeight - borderSpawnOffset;
                break;
            case ScreenSides.Left:
                spawnX = -CameraWidth - borderSpawnOffset;
                spawnY = Random.Range(-CameraHeight, CameraHeight);
                break;
        }

        return new Vector2(spawnX, spawnY);
    }
}