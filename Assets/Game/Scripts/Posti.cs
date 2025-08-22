using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Posti : MonoBehaviour
{
    private PostProcessVolume vol;

    private LensDistortion dist;
    private ChromaticAberration chrom;
    private ColorGrading grad;
    private Bloom blu;
    private Vignette vig;

    private bool cambio = true;

    void Start()
    {
        vol = GetComponent<PostProcessVolume>();

        vol.profile.TryGetSettings(out dist);
        vol.profile.TryGetSettings(out chrom);
        vol.profile.TryGetSettings(out grad);
        vol.profile.TryGetSettings(out blu);
        vol.profile.TryGetSettings(out vig);

        StartCoroutine(Waiter());
    }

    void Update()
    {
        if (cambio)
        {
            dist.intensity.value -= 10 * Time.deltaTime * 5;
            chrom.intensity.value += .2f * Time.deltaTime * 5;
            grad.saturation.value -= 20 * Time.deltaTime * 5;
            grad.contrast.value += 20 * Time.deltaTime * 5;
            blu.intensity.value += 10 * Time.deltaTime * 5;
            vig.intensity.value += .1f * Time.deltaTime * 5;
        }
        else
        {
            dist.intensity.value += 10 * Time.deltaTime * 5;
            chrom.intensity.value -= .2f * Time.deltaTime * 5;
            grad.saturation.value += 20 * Time.deltaTime * 5;
            grad.contrast.value -= 20 * Time.deltaTime * 5;
            blu.intensity.value -= 10 * Time.deltaTime * 5;
            vig.intensity.value -= .1f * Time.deltaTime * 5;
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1);
        cambio = !cambio;
        StartCoroutine(Waiter());
    }
}
