using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshManageColor : MonoBehaviour
{
    public GameObject Bottle;
    public Transform ColorPosition;
    public GameObject ColorPrefab;
    private List<GameObject> ColorObject;
    private bool state = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "hands")
        {
            Debug.Log(Bottle.transform.rotation.eulerAngles.z);
            Debug.Log("rotation");
            if (state == true)
            {
                Instantiate(ColorPrefab, ColorPosition.position, Quaternion.identity);
                state = false;
                StartCoroutine(Waiting());
                Debug.Log("createColor");
            }
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        state = true;
    }
}
