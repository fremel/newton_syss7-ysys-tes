namespace Exercise_03a.Tests;

[TestClass]
public class UnitTest2
{
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        Console.WriteLine("AssembyInitialize has been executed.");
    }

    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        Console.WriteLine("ClassInitialize TWO has been executed");
    }

    [TestMethod]
    public void TestMethod3()
    {
        Console.WriteLine("TestMethod3 has been executed");
    }
}