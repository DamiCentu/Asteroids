using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayer : MonoBehaviour
{
    protected IControllable ControllableObject { get; set; }
    
    private Dictionary<string, Action<InputSignal>> actionsByInput; 
    private void Awake()
    {
        actionsByInput = new Dictionary<string, Action<InputSignal>>()
        {
            [IInputService.HORIZONTAL_AXIS] = HorizontalAction,
            [IInputService.VERTICAL_AXIS] = VerticalAction,
            [IInputService.FIRE_1_INPUT] = FireAction
        };
    }
    
    public void OnInputSignal(InputSignal signal)
    {
        if (actionsByInput.ContainsKey(signal.ActionPerformed))
        {
            actionsByInput[signal.ActionPerformed].Invoke(signal);
        }
    }
    
    private void FireAction(InputSignal signal)
    {
        ControllableObject.PerformFireAction();
    }
    
    private void HorizontalAction(InputSignal signal)
    {
        ControllableObject.HorizontalInput = signal.Value;
    }

    private void VerticalAction(InputSignal signal)
    {
        ControllableObject.VerticalInput = signal.Value;
    }
}