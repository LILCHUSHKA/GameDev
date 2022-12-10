using UnityEngine;

public class HideButton : MonoBehaviour
{
    [SerializeField] Animator imageAnimator;

    [SerializeField] Transform image;

    bool panelIsHide = true;

    public void RotateImage()
    {
        if (panelIsHide)
        {
            imageAnimator.SetTrigger("RotateB");
            panelIsHide = false;
        }
        else
        {
            imageAnimator.SetTrigger("RotateA");
            panelIsHide = true;
        }
    }
}