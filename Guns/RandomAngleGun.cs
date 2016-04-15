using UnityEngine;
using System.Collections;
using ExtensionMethods;

public class RandomAngleGun : aGun {
    float _counter = 0;
    float _counterSpeed = 2;
    float _counterLimit = 2000;

    void Update()
    {
        _counter += _counterSpeed * Time.deltaTime;
        if (_counter > _counterLimit)
            _counter = 0;
    }

    public override void Shoot()
    {
        (Instantiate(shot, transform.position, Quaternion.identity) as GameObject)
            .transform.LookAt2d(target.position, Mathf.Sin(_counter)*30);
    }
}
