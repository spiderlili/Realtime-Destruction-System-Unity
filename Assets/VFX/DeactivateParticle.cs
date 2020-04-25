using UnityEngine;
using System.Collections;

public class DeactivateParticle : MonoBehaviour
{
    [Tooltip("Deactivate gameObject on Awake.")]
    public bool startInactive;

    private ParticleSystem particle;   
    float delay;

    void Awake()
    {
        if (particle == null)
        {
            particle = GetComponent<ParticleSystem>();
            
        }

        if (particle == null)
        {
            Debug.LogError(GetType().Name + ": Particle System not found.");
            enabled = false;
        }
        else
        {
            var particleMain = particle.main;
            foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
            {
                delay = particleMain.startLifetime.constant + Mathf.Max(particleMain.startLifetime.constant, p.main.startLifetime.constant);
            }
            
            particleMain.playOnAwake = true;
            particleMain.loop = false;

            gameObject.SetActive(!startInactive);
        }
    }

    void OnEnable()
    {
        if (particle != null)
        {
            if (gameObject.activeInHierarchy)
            {
                Invoke("Deactivate", delay);
            }
        }
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
