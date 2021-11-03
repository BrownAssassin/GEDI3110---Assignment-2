using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCherry : MonoBehaviour
{
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        var cherry = Instantiate(Prefab, transform);
        cherry.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y, -1);
    }

}
