using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject deathVfx;
    [SerializeField] float speed = 5f;
    [SerializeField] float xRange = 2f;
    [SerializeField] float yRange = 2f;

    [SerializeField] float pitch = 10f;
    [SerializeField] float yaw = 10f;
    [SerializeField] float roll = 20f;
    bool isAlive=true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive){return;}
        Move();
        Rotate();
    }
    void Rotate()
    {
        transform.localRotation = Quaternion.Euler(-transform.localPosition.y * pitch, transform.localPosition.x * yaw, -roll * Input.GetAxis("Horizontal"));
    }
    void Move()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xMove = xThrow * speed * Time.deltaTime;
        float yMove = yThrow * speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.localPosition.x + xMove, -xRange, xRange);
        float clampedY = Mathf.Clamp(transform.localPosition.y + yMove, -yRange, yRange);

        transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
    }
    private void OnTriggerEnter(Collider other) {
        if(!isAlive){return;}
        Invoke("Die",1f);
        Instantiate(deathVfx,transform.localPosition,Quaternion.identity);
        isAlive=false;
    }

    private void Die(){
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
