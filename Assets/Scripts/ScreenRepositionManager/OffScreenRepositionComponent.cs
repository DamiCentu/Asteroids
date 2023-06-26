using System;
using UnityEngine;
using Zenject;

public class OffScreenRepositionComponent : MonoBehaviour, IOffScreenRepositionable
{
    [SerializeField] private Renderer renderer;
    private IOffScreenRepositionManager OffScreenRepositionManager { get; set; }
    
    [Inject]
    public void Construct(IOffScreenRepositionManager offScreenRepositionManager)
    {
        OffScreenRepositionManager = offScreenRepositionManager;
    }
    
    public virtual Vector3 ObjectDirection => throw new NotImplementedException();
    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public Bounds Bounds => renderer.bounds;
    
    private void Start()
    {
        OffScreenRepositionManager.Subscribe(this);
    }

    private void OnDestroy()
    {
        OffScreenRepositionManager.UnSubscribe(this);
    }
}