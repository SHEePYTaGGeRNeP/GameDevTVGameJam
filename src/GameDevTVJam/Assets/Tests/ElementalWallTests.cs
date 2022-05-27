using Assets.Scripts.GamePlay.Collisions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections;
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
        var allowed = wall.AllowPass(character, out var _);

        // assert
        Assert.IsFalse(allowed);
    }

    [Test]
    [TestCase(ElementEnum.Cold, ElementEnum.Fire)]
    [TestCase(ElementEnum.Fire, ElementEnum.Cold)]
    [TestCase(ElementEnum.Cold, ElementEnum.None)]
    [TestCase(ElementEnum.None, ElementEnum.Fire)]
    [Parallelizable()]
    public void AllowPass_WithCharacter_WithWrongElement_Should_ReturnFalse(ElementEnum characterElement, ElementEnum wallElement)  
    {
        // arrange
        var character = new GameObject().AddComponent<Element>();
        character.ElementalValue = characterElement;
        var wall = CreateWall(wallElement);

        // act
        var allowed = wall.AllowPass(character.gameObject, out var _);

        // assert
        Assert.IsFalse(allowed);
    }

    [Test]
    [TestCase(ElementEnum.Fire, ElementEnum.Fire)]
    [TestCase(ElementEnum.Cold, ElementEnum.Cold)]
    public void AllowPass_WithCharacter_WithCorrectElement_Should_ReturnTrue(ElementEnum characterElement, ElementEnum wallElement)
    {
        // arrange
        var character = new GameObject().AddComponent<Element>();
        character.ElementalValue = characterElement;
        var wall = CreateWall(wallElement);

        // act
        var allowed = wall.AllowPass(character.gameObject, out var _);

        // assert
        Assert.IsTrue(allowed);
    }

    [Test]
    public void AllowPass_With_ElementalNoneWall_Should_ReturnFalse()
    {
        // arrange
        var character = new GameObject().AddComponent<Element>();
        var wall = CreateWall(ElementEnum.None);

        // act
        var values = Enum.GetValues(typeof(ElementEnum)).Cast<ElementEnum>();
        foreach (var val in values)
        {
            character.ElementalValue = val;
            var allowed = wall.AllowPass(character.gameObject, out var _);

            // assert
            Assert.False(allowed);
        }
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
