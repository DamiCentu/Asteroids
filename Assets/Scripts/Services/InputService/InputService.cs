using UnityEngine;
using Zenject;

public class InputService : MonoBehaviour, IInputService
{
    [Inject] private SignalBus SignalBus { get; }
    private InputSignal InputSignal { get; set; } //To avoid creating a new operator on an update.

    private static readonly InputAxisWrapper[] AxisWrappers = new InputAxisWrapper[2] //This can be get from an scriptable.
        {
            new InputAxisWrapper(IInputService.HORIZONTAL_AXIS),
            new InputAxisWrapper(IInputService.VERTICAL_AXIS)
        };

    private static readonly string[] inputPressedDownStrings = new string[1] //This can be get from an scriptable.
    {
        IInputService.FIRE_1_INPUT,
    };

    private void Awake()
    {
        InputSignal = new InputSignal();
    }

    private void Update()
    {
        UpdateAllAxisAndDispatchInputSignal();
        UpdateAllInputPressedDown();
    }

    private void UpdateAllInputPressedDown()
    {
        foreach (string inputName in inputPressedDownStrings)
        {
            if (Input.GetButtonDown(inputName))
            {
                DispatchInputSignal(inputName, 1);
            }
        }
    }

    private void UpdateAllAxisAndDispatchInputSignal()
    {
        foreach (InputAxisWrapper inputAxisWrapper in AxisWrappers)
        {
            inputAxisWrapper.UpdateAxis();

            if (inputAxisWrapper.isDirty)
            {
                DispatchInputSignal(inputAxisWrapper.AxisName, inputAxisWrapper.AxisValue);

                inputAxisWrapper.isDirty = false;
            }
        }
    }

    private void DispatchInputSignal(string signalName, float signalValue)
    {
        InputSignal.ActionPerformed = signalName;
        InputSignal.Value = signalValue;
        SignalBus.Fire(InputSignal);
    }
}