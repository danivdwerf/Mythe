using System.Collections;
using UnityEngine;

public class RegenerateHealth : MonoBehaviour 
{
    private PlayerHealth healthScript;
    private bool isBusy;

    private void Start()
    {
        healthScript = this.GetComponent<PlayerHealth>();
        healthScript.onDamage += stopRegen;
        isBusy = false;
    }

    private void Update()
    {
        if (healthScript.CurHealth < healthScript.MaxHealth && !isBusy)
            StartCoroutine("regen");
    }

    private IEnumerator regen()
    {
        isBusy = true;
        yield return new WaitForSeconds(10f);
        while (healthScript.CurHealth < healthScript.MaxHealth)
        {
            healthScript.addHealth(1);
            yield return new WaitForSeconds(0.1f);
        }
        isBusy = false;
    }

    private void stopRegen()
    {
        StopCoroutine("regen");
        isBusy = false;
    }
}