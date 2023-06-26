using System;
using UnityEngine;

public class Ship : MonoBehaviour, IControllable, IDestroyable, IHittable
{
    [SerializeField] private AbstractInputActionScriptable verticalMovementController;
    [SerializeField] private AbstractInputActionScriptable horizontalMovementController;
    
    [SerializeField] private AbstractInputActionScriptable shootAction;

    [SerializeField] private Transform frontalSpawnPoint;

    private Vector3 startPos; 
    
    public float VerticalInput { private get; set; }
    public float HorizontalInput { private get; set; }
    
    public event Action<AbstractDestroyData> OnDestroyed;

    public void PerformFireAction()
    {
        ShootAction();
    }

    public void OnHit(AbstractHitData data)
    {
        OnDestroyed?.Invoke(null);
        ResetToSpawn();
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        UpdateHorizontalMovement();
        UpdateVerticalMovement();
    }

    private void UpdateHorizontalMovement()
    {
        horizontalMovementController.ApplyInput(transform, HorizontalInput);
    }

    private void UpdateVerticalMovement()
    {
        verticalMovementController.ApplyInput(transform, VerticalInput);
    }

    private void ShootAction()
    {
        shootAction.ApplyInput(frontalSpawnPoint);
    }

    private void ResetToSpawn() //This should be handled by some handler.
    {
        transform.position = startPos;
        horizontalMovementController.ResetAction();
        verticalMovementController.ResetAction();
    }
}