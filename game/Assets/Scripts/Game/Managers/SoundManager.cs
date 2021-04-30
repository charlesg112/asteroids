using System;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour, EventListener
{
    public AudioSource BulletFired;
    public List<AudioSource> AsteroidCrushed;
    public AudioSource BulletPickedUp;
    private int AsteroidCrushedLastUsed = 0;
    private void Start()
    {
        EventBus.Subscribe(this);
    }

    void EventListener.onEvent(EventType eventType, GameObject source, int arg)
    {
        switch(eventType)
        {
            case EventType.BulletFired:
                PlayBulletFiredSoundEffect(); break;
            case EventType.AsteroidDestroyed:
                PlayAsteroidCrushedSoundEffect(); break;
            case EventType.PickableBulletPickedUp:
                PlayBulletPickedUpSoundEffet(); break;
        }
    }

    private void PlayBulletPickedUpSoundEffet()
    {
        BulletPickedUp.Play(0);
    }

    private void PlayBulletFiredSoundEffect()
    {
        BulletFired.Play(0);
    }

    void PlayAsteroidCrushedSoundEffect()
    {
        AsteroidCrushed[AsteroidCrushedLastUsed].Play(0);
        AsteroidCrushedLastUsed = (AsteroidCrushedLastUsed + 1) % AsteroidCrushed.Count;
    }
}
