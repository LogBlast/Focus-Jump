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

    public void AddJumpForce(float jumpForce, float jumpDuration)
    {
        PlayerMovement.instance.jumpForce += jumpForce;
        StartCoroutine(RemoveJumpForce(jumpForce, jumpDuration));

    }

    private IEnumerator RemoveJumpForce(float jumpForce, float jumpDuration)
    {
        yield return new WaitForSeconds(jumpDuration);// fait une pause dans le code
        PlayerMovement.instance.jumpForce -= jumpForce;
    }
}
