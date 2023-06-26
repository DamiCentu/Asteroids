using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class OffScreenRepositionManager : MonoBehaviour, IOffScreenRepositionManager
{
    private readonly List<IOffScreenRepositionable> offScreenRepositionables = new List<IOffScreenRepositionable>();
    
    private IOrthographicCameraHelper CameraHelper { get; set; }

    [Inject]
    public void Construct(IOrthographicCameraHelper helper)
    {
        CameraHelper = helper;
    }

    public void Subscribe(IOffScreenRepositionable repositionable)
    {
        offScreenRepositionables.Add(repositionable);
    }

    public void UnSubscribe(IOffScreenRepositionable repositionable)
    {
        offScreenRepositionables.Remove(repositionable);
    }

    private void Update()
    {
        WrapOffScreenRepositionables();
    }

    private void WrapOffScreenRepositionables()
    {
        foreach (IOffScreenRepositionable repositionable in offScreenRepositionables)
        {
            Vector3 currentPosition = repositionable.Position;
            Vector3 newPosition = GetNewPositionIfOutsideScreen(repositionable);
            
            if (currentPosition != newPosition)
            {
                repositionable.Position = newPosition;
            }
        }
    }

    private Vector3 GetNewPositionIfOutsideScreen(IOffScreenRepositionable repositionable)
    {
        Vector3 newPosition = repositionable.Position;
        Bounds objectBounds = repositionable.Bounds;
        
        float cameraWidth = CameraHelper.CameraWidth;
        float cameraHeight = CameraHelper.CameraHeight;
        
        if (repositionable.Position.x + objectBounds.extents.x < -cameraWidth && Vector3.Dot(repositionable.ObjectDirection, Vector3.right) < 0f)
        {
            newPosition.x = cameraWidth + objectBounds.extents.x;
        }
        else if (repositionable.Position.x - objectBounds.extents.x > cameraWidth && Vector3.Dot(repositionable.ObjectDirection, Vector3.left) < 0f)
        {
            newPosition.x = -cameraWidth - objectBounds.extents.x;
        }

        if (repositionable.Position.y + objectBounds.extents.y < -cameraHeight && Vector3.Dot(repositionable.ObjectDirection, Vector3.up) < 0f)
        {
            newPosition.y = cameraHeight + objectBounds.extents.y;
        }
        else if (repositionable.Position.y - objectBounds.extents.y > cameraHeight && Vector3.Dot(repositionable.ObjectDirection, Vector3.down) < 0f)
        {
            newPosition.y = -cameraHeight - objectBounds.extents.y;
        }

        return newPosition;
    }
}