using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float HairForce;
    public CameraShake cameraShake;

    public AudioClip HairCut;
    public AudioClip RevUp;

    AudioSource Source;

    public float camRayLength = 100f;
    public float FireRate = 15f;
    private float NextTimeToFire = 0f;

    bool PlayHairCut = true;
    bool PlayRevUp = false;

    Rigidbody HairRB;

    int HairMask;

   public GameObject Particle;

    // Use this for initialization
    void Start()
    {
        HairMask = LayerMask.GetMask("Hair");
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
            if(Gamemanager.Instance.CanShoot)
            {
                NextTimeToFire = Time.time + 1f / FireRate;
                Shooting();

                DoPlayRevUp();

                StartCoroutine(cameraShake.Shake(0.2f, 0.1f));
            }
        }

        if(Input.GetButtonUp("Fire1"))
        {
            Source.Stop();
        }
    }

    void Shooting()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, camRayLength, HairMask))
        {

            GameObject Hair = hit.transform.gameObject;

            ActivateHair(Hair);

            GameObject Poof = Instantiate(Particle, hit.point, Quaternion.identity);
            Destroy(Poof, 2f);


            DoPlayHairCut();
        }

        else
        {
            Source.Stop();
        }
    }

    void ActivateHair(GameObject _Hair)
    {
        HairRB = _Hair.GetComponent<Rigidbody>();

        HairRB.isKinematic = false;
        HairRB.AddForce(0, HairForce, 0);

        Destroy(_Hair.gameObject, 2f);
    }

    void DoPlayHairCut()
    {
        if(Source.isPlaying)
        {
            return;
        }

        else
        {
            Source.PlayOneShot(HairCut);
        }
    }

    void DoPlayRevUp()
    {
        if (PlayRevUp)
        {
            Source.PlayOneShot(RevUp);
            PlayRevUp = false;
        }
    }
}
