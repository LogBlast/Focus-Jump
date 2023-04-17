using System.Collections; // pour les couroutines 
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    

    public void AddSpeed(int speedGiven, float speedDuration)
    {
        PlayerMovement.instance.moveSpeed += speedGiven;
        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));

    }


    private IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);// fait une pause dans le code
        PlayerMovement.instance.moveSpeed -= speedGiven;
    }

}
