using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    //OHJEET: Area on se alue, missä tuuli vaikuttaa. Se voi olla mikä tahansa collider asetettuna triggeriksi. Direction on se suunta mihin tuuli puskee.
    //Saadaksesi tuulen vaikuttamaan esineihin, niissä pitää olla joko tagi "throwable" tai "WindAffected". Rigidbodyssä oleva "Mass" vaikuttaa tuulen voimakkuuteen.

    public float speed;
    public Transform direction;
    Vector3 pushDirection;

    private void Update() {
        pushDirection = (direction.position - transform.position).normalized;
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("throwable") || other.CompareTag("WindAffected")) {
            if (other.GetComponent<Rigidbody>() != null) {
                other.GetComponent<Rigidbody>().AddForce(pushDirection * speed, ForceMode.Force);
            }
        }
    }
}
