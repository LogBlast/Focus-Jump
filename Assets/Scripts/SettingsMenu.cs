using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    public void Start(){
        resolutions = setFullScreen.resolutions;
        resolutionDropdown.ClearOptions();   // va enlever les choix par défaut ("Option A, Option B ...")
    }

    public void setVolume(float volume){
        
        audioMixer.SetFloat("volume", volume);  // la variable "volume" est dans audioMixer puis en haut à droite de audioMixer --> "Exposed Parameters"

     // la valeur va changer quand on bouge le curseur du slider (regarder dans le slider la fonction "On Value Change" ).

    }

    public void setFullScreen(boolean isFullScreen){
        Screen.fullScreen = isFullScreen;    
        
        // Unity va détecter quand la case est coché grâce à la fonction dans le toggleFullScreen
        // --> on Value Changed (Boolean) --> Mettre en bas à gauche le SettingsWindows  --> à droite, aller sur "SettingsMenu" 
        //et prendre la variable setFullScreen tout en haut
        // donc si on décoche la cose, on va envoyer false (isFullScreen = false) ce qui ne va pas mettre le fullScreen

    }
}
