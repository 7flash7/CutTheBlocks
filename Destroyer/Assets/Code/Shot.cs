using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float maxSpeed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay2D(Input.mousePosition);
            //RaycastHit2D mouseHit;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //if (Physics2D.Raycast(ray, out mouseHit))
            //{
            if (hit.collider != null)
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.layer != LayerMask.NameToLayer("UI"))
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 dir = clickPos - (new Vector2(transform.position.x, transform.position.y));
                    dir.Normalize();
                    bullet.GetComponent<Rigidbody2D>().velocity = dir * maxSpeed;
                    bullet.GetComponent<BulletType>().shotType = GetComponent<HeroState>().shotType;
                }
            }
        }
    }
}
