using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
        NewBehaviourScript nbs = new GameObject().AddComponent<NewBehaviourScript>();
        Assert.NotNull(nbs);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
        NewBehaviourScript nbs = new GameObject().AddComponent<NewBehaviourScript>();
        Assert.NotNull(nbs);
    }
}
