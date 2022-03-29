using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBarManager : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxForce(int force)
    {
        slider.maxValue = force;
        slider.value = force;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetForce(int force)
    {
        slider.value = force;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
