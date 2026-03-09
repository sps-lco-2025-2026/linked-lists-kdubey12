using LinkedListIntroduction.Lib;
using Mono.Cecil.Cil;

namespace LinkedListIntroduction.Tests;

[TestClass]
public sealed class BasicLinkedListTests
{

    [TestMethod]
    public void TestEmpty()
    {
        IntegerLinkedList ill = new IntegerLinkedList();
        Assert.AreEqual(0, ill.Count);
    }

    [TestMethod]
    public void TestCount()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(3, ill.Count);
    }

    [TestMethod]
    public void TestSum()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(21, ill.Sum);
    }

    [TestMethod]
    public void TestToStringExplicit()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestPrepend()
    {
        var ill = new IntegerLinkedList(5);
        ill.Prepend(7);
        ill.Prepend(9);
        Assert.AreEqual("{9, 7, 5}", ill.ToString());
    }

    [TestMethod]
    public void TestDelete()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);

        ill.Delete(7);

        Assert.AreEqual("{5, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestInsert()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);

        ill.Insert(3, 1);
        Assert.AreEqual("{5, 3, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestJoin()
    {
        var ill1 = new IntegerLinkedList(5);
        ill1.Append(7);
        ill1.Append(9);

        var ill2 = new IntegerLinkedList(6);
        ill2.Append(4);
        ill2.Append(2);

        ill1.Join(ill2);

        Assert.AreEqual("{5, 7, 9, 6, 4, 2}", ill1.ToString());
    }

    [TestMethod]
    public void TestContains()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);

        Assert.IsTrue(ill.Contains(7));
    }

    [TestMethod]
    public void TestRemoveDuplicates()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(7);
        ill.Append(9);
        ill.Append(9);
        ill.Append(9);

        ill.RemoveDuplicates();

        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }


}
