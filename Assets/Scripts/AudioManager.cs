using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;    // va contenir tous nos audios
    public AudioSource audioSource;
    private int musicIndex = 0;
    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance; //la variable static nous permet d'acceder a l'inventaire depuis n'importe ou 


    //Permet de gerer l'inventaire 
    private void Awake()
    {
        // Pour etre sur que l'inventaire soit unique, dans la scene il n'y a qu'un seul inventaire
        if (instance != null)
        {

            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scene");
            return;

        }

        // l'inventaire est stocke dans " instance"
        instance = this;

    }
    void Start()
    {
        audioSource.clip = playlist[0];
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();// En une seule fois elle va ajouter le component audioSource sur l'objet mais également on a une variable temporaire audioSource dans laquel on va stocker le component ajouté
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO, clip.length); // Si le son dure 2 seconde l'objets va être supprimé après
        return audioSource;
    }
}
