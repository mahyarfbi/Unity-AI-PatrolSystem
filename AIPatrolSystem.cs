# Unity-AI-PatrolSystem
using System.Collections;
using UnityEngine;
//////////////////////////////////////////
/////////// Mahoo Game Company////////////
//////////////////////////////////////////
//Name Developer :Mahyar_Akbari
//Github:Mahyar_FBI
// این کد توسط مهیار نوشته شده ** This code was written by Mahyar
public class AIPatrolSystem : MonoBehaviour 
{
    [Header("For the speed of movement towards the place where it is going.")] public float Speed_Move; // برای سرعت ابحکت به سمت مکانی که قراره بره
    [Header("Time to stand at the desired location")] public float Wait_ForPlus; // زمانی که برای ایستادن در مکان مورد نظر
    [Header("Array of places where the object should go. It takes value inside the inspector.")] public Transform[] array_TargetPostion; // ارایه مکان هایی که ابجکت باید برو. داخل اینس پکتور مقدار میگیره
    [Header("The current index of the destination in the patrol point array.")] int length_Target; // اندیس فعلی مقصد در آرایه‌ی نقاط پاترول
    [Header("The numerical length of the distance from the current location to the desired location.")][SerializeField] float Distance_Target; // طول عددی فاصله از مکانی که هست تا مکان مورد نظر
    [Header("To activate and deactivate the system")] public bool Is_Patroling = true; // برای فعال و غیر فعال کردن سیستم
    [Header("For a coroutine that doesn't run multiple times")] bool bol_enum_Patrol;
    private void Update()
    {
        if (array_TargetPostion.Length == 0) return; // اگر مکانی داده نشود برگشت میخورد///If no location is given, it will be returned.
        if (Is_Patroling)  Founc_AIPatrolSystem(); // صدا زدن فانکشن سیستم پاترول//Calling the patrol system function


    }
    public void Founc_AIPatrolSystem()
    {
        Vector3 dir = array_TargetPostion[length_Target].position - transform.position;
        // پیدا کردن فاصله مکانی ابجکت// Find the spatial distance of the object
        transform.position = Vector3.MoveTowards(transform.position, array_TargetPostion[length_Target].position, Speed_Move * Time.deltaTime);
        // حرکت به سمت تارگت مورد نظر// Move to the desired target
        if (dir.sqrMagnitude < 1.5f * 1.5f && !bol_enum_Patrol) StartCoroutine(enum_Patrol());
        //  اگه فاصله از تارگت خود کم بود کروتین را صدا بزنه . چون مقدار مربع رو بدست میاورد باید ضرب در خودش بشه.1.5 برای اطمینان که اگر موقعیت مکاین زیر زمین باشه باگ نشه
        // If the distance from its target is small, call the croutine. Since it gets the square value, it must be multiplied by itself. 1.5 to ensure that there is no bug if the location of the location is underground.
    }
    IEnumerator enum_Patrol()
    {
        bol_enum_Patrol = true; // برای تکرار نشدن چند بار کروتین// To avoid repeating the coroutine multiple times
        Is_Patroling = false; // سیستم تا زمان استراحت قطع میشود// The system is suspended until the break time
        yield return new WaitForSeconds(Wait_ForPlus); // زمان استراحت
        length_Target++; // موقعیت مکانی آپدیت میشود// Location is updated
        if (length_Target >= array_TargetPostion.Length) // اگر تعداد موقعیت مکانی به پایان رسید موقعیت از اول شروع میشود// If the number of locations is exhausted, the location will start over.
            length_Target = 0;
        Is_Patroling = true; // سیستم شروع به کار میکند// The system starts working
        bol_enum_Patrol = false; // برای استفاده میتوان دوباره  صدا زده شود// Can be called again for use
    }
    private void OnDisable() // اگر در  زمانی کامپونت خاموش شد اطلاعات باگ نشود// If the component is turned off at some point, the information will not be bugged.
    {
        // رست کردن تنظیمات// Refresh settings
        StopAllCoroutines();
        bol_enum_Patrol = false;
        Is_Patroling = true;
        length_Target = 0;
    }
}

