using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float turnSpeed = 200f;
    [SerializeField] private float speedGain = 0.2f;
    // [SerializeField] private float speedGainPerSecond = 0.2f;
    private int steerValue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        speed += speedGain*Time.deltaTime;
        transform.Rotate(0.0f,steerValue*turnSpeed*Time.deltaTime,0.0f);

        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    public void Steer(int value){
        steerValue = value;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Obstacle")){
            SceneManager.LoadScene(0);
        }
    }
}
