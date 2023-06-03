using KissMap;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PropertyMap()
        {
            var map = new PropertyMap("Code", "Name");
            var src = new Dto1();
            var dst = new Dto2();

            map.Apply(src, dst);

            Assert.AreEqual("Dto1", dst.Name);
        }

        [TestMethod]
        public void ObjectMap()
        {
            var map = new ObjectMap();
            map.Register("Code", "Name");
            map.Register("Number", "Count");

            var src = new Dto1();
            var dst = new Dto2();

            map.CopyTo(src, dst);

            Assert.AreEqual("Dto1", dst.Name);
            Assert.AreEqual(1, dst.Count);
        }

        [TestMethod]
        public void ObjectMapWConvert()
        {
            var map = new ObjectMap();
            map.Register("Code", "Name");
            map.Register("Number", "Count");
            map.Register("Is");

            var src = new Dto1();
            var dst = new Dto2();

            map.CopyTo(src, dst);

            Assert.AreEqual("Dto1", dst.Name);
            Assert.AreEqual(1, dst.Count);
            Assert.IsTrue(dst.Is);
        }

        [TestMethod]
        public void ObjectMapWCreate()
        {
            var map = new ObjectMap();
            map.Register("Code", "Name");
            map.Register("Number", "Count");
            map.Register("Is");

            var src = new Dto1();

            var dst = map.Create<Dto2>(src);

            Assert.AreEqual("Dto1", dst.Name);
            Assert.AreEqual(1, dst.Count);
            Assert.IsTrue(dst.Is);
        }
    }
}