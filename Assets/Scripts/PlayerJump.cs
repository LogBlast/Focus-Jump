using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public int maxJump = 1;
    public int currentJump;
    public JumpBar jumpBar;


    private void Start()
    {
        currentJump = 0;
        jumpBar.SetMinJump(0);
    }
}
