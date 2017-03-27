using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CnControls;
using SocketIO;

// This is merely an example, it's for an example purpose only
// Your game WILL require a custom controller scripts, there's just no generic character control systems, 
// they at least depend on the animations

[System.Serializable]
public class Person
{
    public string name;
    public Vector3 pos;
}

[System.Serializable]

public class NetPerson : Person
{
    public string id;
}

[RequireComponent(typeof(CharacterController))]

public class MovePlayer : MonoBehaviour {

    public float MovementSpeed = 10f;

    private Transform _mainCameraTransform;
    private Transform _transform;
    private CharacterController _characterController;
    private Person _per = new Person();

    private SocketIOComponent socket;
    private Vector3 temp;


    public void Start()
    {
        _per.name = "TestUer" + Random.Range(1, 500);
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

        socket.On("open", TestOpen);


        _per.pos = _characterController.transform.position;

        string json = JsonUtility.ToJson(_per);
        JSONObject jobj = new JSONObject(json);

        socket.Emit("PLAY", jobj);

        temp = new Vector3(_characterController.transform.position.x, _characterController.transform.position.y, _characterController.transform.position.z);


        socket.On("PLAY", Player);

        socket.On("USER_CONNECTED", AddUser);
        socket.On("USER_DISCONNECTED", DelUser);

    }

    public void TestOpen(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
    }

    public void Player(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);

        NetPerson per = JsonUtility.FromJson<NetPerson>(e.data.ToString());
    }

    public void AddUser(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);

        NetPerson per = JsonUtility.FromJson<NetPerson>(e.data.ToString());
    }

    public void DelUser(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);

        NetPerson per = JsonUtility.FromJson<NetPerson>(e.data.ToString());
    }



    private void OnEnable()
    {
        _mainCameraTransform = Camera.main.GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    public void Update()
    {
        // Just use CnInputManager. instead of Input. and you're good to go
        var inputVector = new Vector3(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
        Vector3 movementVector = Vector3.zero;

        // If we have some input
        if (inputVector.sqrMagnitude > 0.001f)
        {
            movementVector = _mainCameraTransform.TransformDirection(inputVector);
            movementVector.y = 0f;
            movementVector.Normalize();
            _transform.forward = movementVector;
        }

        movementVector += Physics.gravity;
        _characterController.Move(movementVector * Time.deltaTime);


        if (temp != _characterController.transform.position )
        {
            _per.pos = _characterController.transform.position;

            temp = _characterController.transform.position;

            string json = JsonUtility.ToJson(_per);
            JSONObject jobj = new JSONObject(json);
            socket.Emit("Move", jobj);

        }
      
    }
}
