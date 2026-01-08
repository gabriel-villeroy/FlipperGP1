using UnityEngine;

public class Shooter : MonoBehaviour
{
    private GameObject innerWall;
    private GameObject outerWall;

    [SerializeField] private Vector3 innerWallBasePos;
    [SerializeField] private Vector3 innerWallOpenPos;
    [SerializeField] private Vector3 outerWallBasePos;
    [SerializeField] private Vector3 outerWallOpenPos;

    
    [Header("Shooter")]
    private Rigidbody shooterRb;
    private Transform shooterTrs;

    
    void Start()
    {
        GameManager.Instance.shooter = this;
        GameManager.Instance.GetComponent<InputManager>().shooter = this;
        
        outerWall = gameObject.transform.GetChild(0).gameObject;
        innerWall = gameObject.transform.GetChild(1).gameObject;
        shooterRb = gameObject.transform.GetChild(2).gameObject.GetComponent<Rigidbody>();
        shooterTrs = gameObject.transform.GetChild(2).gameObject.GetComponent<Transform>();
        
        outerWallOpenPos = outerWall.transform.position;
        innerWallOpenPos = innerWall.transform.position;

        initYPos = shooterTrs.position.y;
        
        DesactivateShooter();
    }

    public void EnableShooter()
    {
        ChangePos(innerWall, innerWallOpenPos);
        ChangePos(outerWall, outerWallOpenPos);
    }

    public void DesactivateShooter()
    {
        ChangePos(innerWall, innerWallBasePos);
        ChangePos(outerWall, outerWallBasePos);
    }

    private void ChangePos(GameObject wallToMove, Vector3 targetPos)
    {
        wallToMove.transform.position = targetPos;
    }

    public float initYPos;
    public float yOffset = 0.2f;
    public float liftingSpeed;
    public float loadingSpeed = 1;
    
    public bool canPush;

    public void ChargeShoot()
    {
        shooterRb.isKinematic = false;

        if (shooterTrs.localPosition.y > initYPos - yOffset)
        {
            //moves down the shooter
            shooterRb.linearVelocity += -shooterTrs.up * loadingSpeed * Time.deltaTime;
        }
        else
        {
            //stop if max valued reached
            shooterRb.linearVelocity = Vector3.up * yOffset;
            shooterRb.isKinematic = true;
        }
    }

    public void ReleaseShoot()
    {
        shooterRb.isKinematic = false;
        
        if (shooterTrs.localPosition.y < initYPos)
        {
            //allows up movement
            shooterRb.linearVelocity += shooterTrs.up * liftingSpeed * Time.deltaTime;
        }
        else
        {
            //constraint when push is false
            shooterRb.isKinematic = true;
            shooterTrs.localPosition = Vector3.up * yOffset;

            canPush = true;
        }
    }
}