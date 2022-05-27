using Assets.Scripts.GamePlay.Collisions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections;
using UnityEngine;

public class NewTestScript
{
    public static class TraitConstants
    {
        public static Trait fireTrait
        {
            get
            {
                Trait trait = ScriptableObject.CreateInstance<Trait>();
                trait.type = "Fire";
                trait.color = Color.red;
                return trait;
            }
        }
        public static Trait iceTrait
        {
            get
            {
                Trait trait = ScriptableObject.CreateInstance<Trait>();
                trait.type = "Ice";
                trait.color = Color.cyan;
                return trait;
            }
        }
    }

    private static ElementalWall CreateWall(Trait element)
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
        var wall = CreateWall(TraitConstants.fireTrait);

        // act
        var allowed = wall.AllowPass(character, out var _);

        // assert
        Assert.IsFalse(allowed);
    }

    [Test]
    public void AllowPass_WithCharacter_WithWrongElement_Should_ReturnFalse()  
    {
        // arrange
        Trait characterElement, wallElement;
        characterElement = TraitConstants.fireTrait;
        wallElement = TraitConstants.iceTrait;
        var character = new GameObject().AddComponent<Element>();
        character.ElementalValue = characterElement;
        var wall = CreateWall(wallElement);

        // act
        var allowed = wall.AllowPass(character.gameObject, out var _);

        // assert
        Assert.IsFalse(allowed);
    }

    [Test]
    public void AllowPass_WithCharacter_WithCorrectElement_Should_ReturnTrue()
    {
        // arrange
        Trait characterElement, wallElement;
        characterElement = TraitConstants.iceTrait;
        wallElement = TraitConstants.iceTrait;
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
        var wall = CreateWall(null);

        // act
        character.ElementalValue = TraitConstants.fireTrait;
        var allowed = wall.AllowPass(character.gameObject, out var _);

        // assert
        Assert.False(allowed);
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
