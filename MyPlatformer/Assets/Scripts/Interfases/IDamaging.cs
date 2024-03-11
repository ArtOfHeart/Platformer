using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamaging 
{
    void CauseDamage(Collider2D collision = null);

}
