using UnityEngine;

public class InputAxisWrapper
{
    public bool isDirty { get; set; }
    public float AxisValue { get; private set; }
    public string AxisName { get; private set; }
    
    public InputAxisWrapper(string axisName)
    {
        AxisName = axisName;
    }

    public void UpdateAxis()
    {
        float newAxisValue = Input.GetAxis(AxisName);
        if (AxisValue != newAxisValue)
        {
            AxisValue = newAxisValue;
            isDirty = true;
        }
    }
}