using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
   private AudioSource audioSource;


     public GameObject AudioClip;
        public float ClipLength = 1f;


    public GameObject particleEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame



    void Update()
{
   if (Input.GetButtonDown("Fire1")) {
      Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
      RaycastHit hit;
      audioSource.Play();
       
      if (Physics.Raycast(ray, out hit)) {
         if (hit.collider.tag == "Target") {
            GameObject hitObject = hit.collider.gameObject;
            GameManager.Instance.IncrementScore();
            Destroy(hitObject);
         }
      }
      Instantiate(particleEffectPrefab, hit.point, Quaternion.identity);
     

   }
}

  IEnumerator PlaySound()
    {
        AudioClip.SetActive(true);
        yield return new WaitForSeconds(ClipLength);
        AudioClip.SetActive(false);
    }



}
