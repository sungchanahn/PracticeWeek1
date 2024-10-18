using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    public float Fuel { get; set; }
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        Fuel = 100f;
    }

    public void Shoot()
    {
        if (Fuel >= 10)
        {
            Fuel -= FUELPERSHOOT;
            _rb2d.AddForce(new Vector2(0, SPEED), ForceMode2D.Impulse);
        }
    }
}
