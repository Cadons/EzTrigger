using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using EzTrigger;
public class EzTriggerTest
{
    private Trigger triggerScript;
    private GameObject testObject;

    [SetUp]
    public void SetUp()
    {
        testObject = new GameObject();
        triggerScript = testObject.AddComponent<Trigger>();
        triggerScript.OnEnter = new UnityEvent();
        triggerScript.OnExit = new UnityEvent();
        triggerScript.OnStay = new UnityEvent();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(testObject);
    }

    [Test]
    public void TestOnEnterInvoked()
    {
        bool onEnterInvoked = false;
        triggerScript.OnEnter.AddListener(() => onEnterInvoked = true);

        Collider fakeCollider = new GameObject().AddComponent<BoxCollider>();
        fakeCollider.tag = "Player";
        triggerScript.TargetTag.Add("Player");

        triggerScript.OnTriggerEnter(fakeCollider);

        Assert.IsTrue(onEnterInvoked);
    }

    [Test]
    public void TestOnExitInvoked()
    {
        bool onExitInvoked = false;
        triggerScript.OnExit.AddListener(() => onExitInvoked = true);

        Collider fakeCollider = new GameObject().AddComponent<BoxCollider>();
        fakeCollider.tag = "Player";
        triggerScript.TargetTag.Add("Player");

        triggerScript.OnTriggerExit(fakeCollider);

        Assert.IsTrue(onExitInvoked);
    }

    [Test]
    public void TestOnStayInvoked()
    {
        bool onStayInvoked = false;
        triggerScript.OnStay.AddListener(() => onStayInvoked = true);

        Collider fakeCollider = new GameObject().AddComponent<BoxCollider>();

        fakeCollider.tag = "Player";
        triggerScript.TargetTag.Add("Player");

        triggerScript.OnTriggerStay(fakeCollider);

        Assert.IsTrue(onStayInvoked);
        
    }
    [Test]
    public void TestAnyTagOnEnter()
    {
        bool onEnterInvoked = false;
        triggerScript.OnEnter.AddListener(() => onEnterInvoked = true);

        Collider fakeCollider = new GameObject().AddComponent<BoxCollider>();
        triggerScript.AnyTag = true;

        triggerScript.OnTriggerEnter(fakeCollider);

        Assert.IsTrue(onEnterInvoked);
    }

    [Test]
    public void TestAnyTagOnExit()
    {
        bool onExitInvoked = false;
        triggerScript.OnExit.AddListener(() => onExitInvoked = true);

        Collider fakeCollider = new GameObject().AddComponent<BoxCollider>();
        triggerScript.AnyTag = true;

        triggerScript.OnTriggerExit(fakeCollider);

        Assert.IsTrue(onExitInvoked);
    }

    [Test]
    public void TestAnyTagOnStay()
    {
        bool onStayInvoked = false;
        triggerScript.OnStay.AddListener(() => onStayInvoked = true);

        Collider fakeCollider = new GameObject().AddComponent<BoxCollider>();
        triggerScript.AnyTag = true;

        triggerScript.OnTriggerStay(fakeCollider);

        Assert.IsTrue(onStayInvoked);
    }

    [Test]
    public void TestGetColliderOfTheEvent()
    {
        Collider fakeCollider = new GameObject().AddComponent<BoxCollider>();
        triggerScript.OnTriggerEnter(fakeCollider);

        Collider storedCollider = triggerScript.GetColliderOfTheEvent("Enter");

        Assert.AreEqual(fakeCollider, storedCollider);
    }
}
