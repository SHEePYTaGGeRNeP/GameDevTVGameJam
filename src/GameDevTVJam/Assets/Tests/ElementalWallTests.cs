using Assets.Scripts.GamePlay.Collisions;
using NUnit.Framework;
using UnityEngine;

public class NewTestScript
{
    private static ElementalWall CreateWall(ElementEnum element)
    {
        GameObject go = new GameObject();
        go.AddComponent<Collider>();
        var wall = go.AddComponent<ElementalWall>();
        wall.ElementToIgnore = element;
        return wall;
    }

    [Test]
    public void AllowPass_WithCharacter_WithoutElement_Should_ReturnFalse()
    {
        // arrange
        var character = new GameObject();
        var wall = CreateWall(ElementEnum.Fire);

        // act
        var allowed = wall.AllowPass(character);

        // assert
        Assert.IsFalse(allowed);
    }

    [Test]
    public void AllowPass_WithCharacter_WithWrongElement_Should_ReturnFalse()
    {
        // arrange
        var character = new GameObject().AddComponent<Element>();
        character.ElementalValue = ElementEnum.Cold;
        var wall = CreateWall(ElementEnum.Fire);

        // act
        var allowed = wall.AllowPass(character.gameObject);

        // assert
        Assert.IsFalse(allowed);
    }

    [Test]
    public void AllowPass_WithCharacter_WithCorrectElement_Should_ReturnTrue()
    {
        // arrange
        var character = new GameObject().AddComponent<Element>();
        character.ElementalValue = ElementEnum.Fire;
        var wall = CreateWall(ElementEnum.Fire);

        // act
        var allowed = wall.AllowPass(character.gameObject);

        // assert
        Assert.IsTrue(allowed);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    //[UnityTest]
    //public IEnumerator NewTestScriptWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // Use yield to skip a frame.
    //    yield return null;
    //    NewBehaviourScript nbs = new GameObject().AddComponent<NewBehaviourScript>();
    //    Assert.NotNull(nbs);
    //}
}
