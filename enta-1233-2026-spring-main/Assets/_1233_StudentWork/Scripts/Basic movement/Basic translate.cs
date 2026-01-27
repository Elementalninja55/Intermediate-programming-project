using UnityEngine;

public class Basictranslate : MonoBehaviour
{
    [SerializeField] private Vector3 _speed;
    [SerializeField] private bool _fixedupdate; // [ true / false]

    // Update is called once per frame
    void Update()
    {
        if (!_fixedupdate)
            transform.Translate(translation: _speed * Time.deltaTime);


    }
    private void FixedUpdate()
    {
        if (_fixedupdate)
            transform.Translate(translation: _speed * Time.fixedDeltaTime);
    }
}
