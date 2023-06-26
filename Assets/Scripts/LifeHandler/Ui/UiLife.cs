
using UnityEngine;
using UnityEngine.UI;

public class UiLife : MonoBehaviour
{
    [SerializeField] private Image lifeImage;

    public bool IsActive => lifeImage.enabled;
    public void Enable(bool value)
    {
        lifeImage.enabled = value;
    }
}
