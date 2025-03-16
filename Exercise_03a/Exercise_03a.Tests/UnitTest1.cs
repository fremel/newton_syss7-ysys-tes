namespace Exercise_03a.Tests;

[TestClass]
public class UnitTest1
{
    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        Console.WriteLine("ClassInitialize ONE has been executed");
    }

    [TestInitialize]
    public void TestInit()
    {
        Console.WriteLine("TestInitialize has been executed.");
    }

    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine("TestMethod1 has been executed");
    }

    [TestMethod]
    public void TestMethod2()
    {
        Console.WriteLine("TestMethod2 has been executed");
    }
}