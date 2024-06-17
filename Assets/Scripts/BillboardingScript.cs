using UnityEngine;

public class BillboardingScript : MonoBehaviour
{
    [SerializeField] bool BillboardX = true;
    [SerializeField] bool BillboardY = true;
    [SerializeField] bool billboardZ = true;
    float rotationX = 0f;
    float rotationY = 0f;
    float rotationZ = 0f;
    void Update()
    {
        if (BillboardX) { rotationX = Camera.main.transform.rotation.eulerAngles.x; }
        else { rotationX = 0f;}

        if(BillboardY) { rotationY = Camera.main.transform.rotation.eulerAngles.y;}
        else {rotationY = 0f;}

        if(billboardZ) { rotationZ = Camera.main.transform.rotation.eulerAngles.z;}
        else {rotationX = 0f;}

        transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
    }
}
