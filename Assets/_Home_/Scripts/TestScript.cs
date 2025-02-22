using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
// Esto es lo que hay que hacer para compilar con cosas de editor
#endif

[RequireComponent(typeof(MeshRenderer))]
public class TestScript : MonoBehaviour
{
    public Color bodyColor;
    public float metersPerSecond = 2f;
    //private MeshRenderer meshRenderer;
    private MeshRenderer _meshRenderer;
    private MeshRenderer meshRenderer{
        get{
            if(_meshRenderer == null){
                _meshRenderer = GetComponent<MeshRenderer>();
            }
            return _meshRenderer;
        }
    }

    private Rigidbody _rb;
    private Rigidbody rb{
        get{
            if(_rb == null){
                _rb = GetComponent<Rigidbody>();
            }
            return _rb;
        }
    }
    
    private Vector2 lastMovementInput = Vector2.zero;
    

    void Awake()
    {
        // meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnEnable()
    {
        //Debug.Log("Enabled");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
        GetMovementInput();
    }

    void FixedUpdate()
    {
        // Move(lastMovementInput);
    }

    void OnDisable()
    {
        //Debug.Log("OnDisable");
    }

    void OnDestroy()
    {
        //Debug.Log("OnDestroy");
    }

    private void ChangeColor(){
        meshRenderer.material.color = bodyColor;
    }

    private Vector2 GetMovementInput(){
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");
       Vector2 movementInput = new Vector2(horizontalInput, verticalInput);
       movementInput = movementInput.normalized;
       lastMovementInput = movementInput;
       return movementInput;
    }

    private void Move(Vector2 movementInput)
    {
       // TODO: Fix and make it work
       rb.linearVelocity = new Vector3(
                                        transform.forward.x * movementInput.x * metersPerSecond,
                                        rb.linearVelocity.y,
                                        transform.forward.z * movementInput.y * metersPerSecond
       );
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollisionEnter with {collision.collider.gameObject.name}", this);
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log($"OnCollisionExit with {collision.collider.gameObject.name}", this);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter with {other.gameObject.name}", this);
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log($"OnTriggerExit with {other.gameObject.name}", this);
    }

}
