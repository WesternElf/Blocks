using UnityEngine;

public class Particle : MonoBehaviour
{

    public void SetColor(Color color)
    {
        foreach (var ps in GetComponentsInChildren<ParticleSystem>())
        {
            var main = ps.main;
            main.startColor = color;
        }
    }
}
