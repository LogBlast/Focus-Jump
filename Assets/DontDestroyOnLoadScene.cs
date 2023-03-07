using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{

    public GameObject[] objects;

    // Start is called before the first frame update
    void Awake()
    {
    foreach(var element in objects)
        {
            DontDestroyOnLoad(element);

        }    
    }

   
}
