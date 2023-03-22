using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    public void Start(){
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();   // va enlever les choix par défaut ("Option A, Option B ...")

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)  // astuce: écris for et fais 2 fois tab (ça le fais automatiquement)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;                 // width x height 
            options.Add(option);   // pour chaque résolution compatible avec l'écran, on va créer une string avc à l'intérieur la longeur et la largeur
                                   // qu'on va ajouter à notre liste d'options d'écran
        }

        resolutionDropdown.AddOptions(options);
    }

    public void setVolume(float volume){
        
        audioMixer.SetFloat("volume", volume);  // la variable "volume" est dans audioMixer puis en haut à droite de audioMixer --> "Exposed Parameters"

     // la valeur va changer quand on bouge le curseur du slider (regarder dans le slider la fonction "On Value Change" ).

    }

    public void setFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;    
        
        // Unity va détecter quand la case est coché grâce à la fonction dans le toggleFullScreen
        // --> on Value Changed (Boolean) --> Mettre en bas à gauche le SettingsWindows  --> à droite, aller sur "SettingsMenu" 
        //et prendre la variable setFullScreen tout en haut
        // donc si on décoche la cose, on va envoyer false (isFullScreen = false) ce qui ne va pas mettre le fullScreen

    }
}
