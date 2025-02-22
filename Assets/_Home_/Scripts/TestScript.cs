using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
// Esto es lo que hay que hacer para compilar con cosas de editor
#endif

[RequireComponent(typeof(MeshRenderer))]
public class TestScript : MonoBehaviour
{
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

    

    public Color bodyColor;
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
    }

    void FixedUpdate()
    {
        Move();
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

    private void Move()
    {
        transform.localPosition += transform.forward * metersPerSecond * Time.fixedDeltaTime;
    }
}
