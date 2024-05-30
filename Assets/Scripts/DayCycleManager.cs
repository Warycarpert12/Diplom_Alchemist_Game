using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [Range(0,1)]
    public float TimeOfDay;
    public float DayDuration = 30f;

    public AnimationCurve SunCurve;
    public AnimationCurve MoonCurve;
    public AnimationCurve SkyboxCurve;

    public Material DaySkyBox;
    public Material MoonSkyBox;

    public Light Sun;
    public Light Moon;

    private float sunIntensity;
    private float moonIntensity;
    // Start is called before the first frame update
    void Start()
    {
        sunIntensity = Sun.intensity;
        moonIntensity = Moon.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfDay += Time.deltaTime / DayDuration;
        if (TimeOfDay >= 1) TimeOfDay -= 1;

        RenderSettings.skybox.Lerp(MoonSkyBox, DaySkyBox, SkyboxCurve.Evaluate(TimeOfDay));
        RenderSettings.sun = SkyboxCurve.Evaluate(TimeOfDay) > 0.1f ? Sun : Moon;


        DynamicGI.UpdateEnvironment();

        Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f,180,0);
        Moon.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f + 180f, 180, 0);

        Sun.intensity = sunIntensity * SunCurve.Evaluate(TimeOfDay);
        Moon.intensity = sunIntensity * MoonCurve.Evaluate(TimeOfDay);
    }
}
