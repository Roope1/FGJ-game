using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SealController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private AudioSource _bonk;
    [SerializeField] private Animator _anim;

    private Rigidbody _sealRig;
    private bool _canMove = true;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = FindAnyObjectByType<Camera>();
        _sealRig = gameObject.GetComponent<Rigidbody>();
        _anim.SetBool("Dead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && _canMove)
        {
            Move(Input.GetAxis("Horizontal"));
        }
        gameObject.transform.position += new Vector3(0, 0, 0.00001f);
    }

    private void Move(float input)
    {
        //_sealRig.AddForce(Vector3.left * input * _moveForce, ForceMode.Force);
        gameObject.transform.position += new Vector3(-input * _moveSpeed, 0, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!GameManager.Instance.GameActive) return;

        GameObject target = collision.gameObject;
        Debug.Log($"Colliding with {target}");
        if (target.CompareTag("Obstacle"))
        {
            if (GameManager.Instance.GameActive)
            {
                _bonk.Play();
                _canMove = false;
                _anim.SetBool("Dead", true);
            }
            GameManager.Instance.GameOver();
            GameManager.Instance.GameActive = false;
            Debug.Log("Hit obstacle, game over");
            StartCoroutine(EndGame());
        }
        else if (target.CompareTag("Wall"))
        {
            Rigidbody rig = gameObject.GetComponent<Rigidbody>();
            rig.AddForce(Vector3.left * transform.position.x * 0.5f, ForceMode.Impulse);
        }
    }

    private IEnumerator EndGame()
    {
        Rigidbody rig = gameObject.GetComponent<Rigidbody>();
        rig.freezeRotation = false;
        float speed = GameManager.Instance.ObstacleSpeed;
        GameManager.Instance.ObstacleSpeed = 0;
        // parent camera to player
        _cam.gameObject.transform.parent = gameObject.transform.parent;
        _cam.gameObject.AddComponent<Rigidbody>().freezeRotation = true;
        _cam.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        // apply ragdoll
        //rig.velocity = new Vector3(0f, 0f, -speed);
        rig.AddForce(Vector3.up * 15, ForceMode.Impulse);
        rig.AddForce(Vector3.forward * -speed, ForceMode.VelocityChange);
        yield return new WaitForSeconds(8f);
        GameManager.Instance.SelfDestruct();
        SceneManager.LoadScene("MainMenu");

    }



}
