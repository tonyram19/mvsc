using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip loseLifeSFX;

	void Start ()
    {
        source = GetComponent<AudioSource>();
	}

    public void PlayLoseLifeSFX()
    {
        source.PlayOneShot(loseLifeSFX, 1);

    }

  
}
