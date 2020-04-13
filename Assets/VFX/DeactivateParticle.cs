using UnityEngine;
using System.Collections;

public class DeactivateParticle : MonoBehaviour
{
    [Tooltip("Deactivate gameObject on Awake.")]
    public bool startInactive;

    ParticleSystem particle;
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
            foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
            {
                delay = particle.startLifetime + Mathf.Max(particle.startLifetime, p.startLifetime);
            }

            particle.playOnAwake = true;
            particle.loop = false;

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
