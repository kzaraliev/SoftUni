using UnityEngine;

public class FlameController : MonoBehaviour
{
    public ParticleSystem leftFlame;
    public ParticleSystem rightFlame;

    public void ToggleFlames(bool playing)
    {
        ParticleSystem.EmissionModule emission = leftFlame.emission;
        emission.enabled = playing;

        emission = rightFlame.emission;
        emission.enabled = playing;
    }
}
