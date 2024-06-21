using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCreater : MonoBehaviour
{

    [SerializeField] private GameObject _newTunnel;
    [SerializeField] private GameObject _laser;
    private GameObject _mainTunnel;
    private GameObject _clone;
    private double stage = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _mainTunnel = transform.GetChild(0).gameObject;
    }
    private void UpdateStage()
    {
        if (stage < 10)
            stage += 0.25;
            
    }
    public void CreateNext(int i = 1)
    {
        Transform child = transform.GetChild(i);
        Vector3 temp = child.position;
        //Debug.Log(temp.z + " -OLD");
        temp.z = child.position.z + child.GetChild(i).localScale.x;
        //Debug.Log(temp.z + " -NEW");
        Quaternion tempRotation = child.rotation;
        _clone = Instantiate(original: _newTunnel, position: temp, rotation: tempRotation);
        _clone.transform.SetParent(transform);
        Debug.Log("Create");
        GenerateLasers(i+1);
        UpdateStage();

    }
    private void GenerateLasers(int koef = 2)
    {
        int[] sides = { Random.Range(1, 5), 0 };
       
        int lasersCount = 1;
        if (stage > 1)
            lasersCount++;
            int second_rand = sides[0] + Random.Range(1, 4);
            sides[1] = second_rand > 4 ? second_rand - 4 : second_rand;
        int[] angles = { -90, -90 };
        for(int j = 0; j < lasersCount; j++)
        {
            for(int i = 0; i < sides[j]; i++)
            {
                angles[j] += 90;
            }
            Transform tunnel = transform.GetChild(koef);
            GameObject laser = Instantiate( _laser);
            laser.transform.SetParent(tunnel);
            Debug.Log(sides[j] + " Side; " + angles[j] + " Angle;");
            Vector3 tempPos = new Vector3(Random.Range(-6, 6),
                sides[j] == 1 ? -1 : sides[j] == 3 ? 1 : 0,
                sides[j] == 2 ? 3 : sides[j] == 4 ? 0.5f : 1.7f);
            Vector3 tempRot = new Vector3(angles[j], 90, 0);
            laser.transform.localPosition = tempPos;
            laser.transform.rotation = Quaternion.Euler(tempRot);
        }
    }
    public void DestroyOld()
    {
        Destroy(transform.GetChild(0).gameObject);
        CreateNext();
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
