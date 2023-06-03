using KissMap;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PropertyMap()
        {
            var map = new PropertyMap<Dto1, Dto2>("Code", "Name");
            var src = new Dto1();
            var dst = new Dto2();

            map.Apply(src, dst);

            Assert.AreEqual("Dto1", dst.Name);
        }

        [TestMethod]
        public void ObjectMap()
        {
            var map = new ObjectMap<Dto1, Dto2>();
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
            var map = new ObjectMap<Dto1, Dto2>();
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
        public void ObjectMapCreateWConvert()
        {
            var map = new ObjectMap<Dto1, Dto2>();
            map.Register("Code", "Name");
            map.Register("Number", "Count");
            map.Register("Is");

            var src = new Dto1();

            var dst = map.CreateFrom(src);

            Assert.AreEqual("Dto1", dst.Name);
            Assert.AreEqual(1, dst.Count);
            Assert.IsTrue(dst.Is);
        }
        [TestMethod]
        public void SimpleReader()
        {
            var map = new ObjectMap<Dto1, Dto2>();
            map.Register(obj => obj.Code, "Name");
            map.Register("Number", "Count");

            var src = new Dto1();
            var dst = new Dto2();

            map.CopyTo(src, dst);

            Assert.AreEqual("Dto1", dst.Name);
            Assert.AreEqual(1, dst.Count);
        }

        [TestMethod]
        public void ComplexReader()
        {
            var map = new ObjectMap<Dto1, Dto2>();
            map.Register(obj => $"{obj.Code}-{obj.Number}", "Name");
            map.Register("Number", "Count");

            var src = new Dto1();
            var dst = new Dto2();

            map.CopyTo(src, dst);

            Assert.AreEqual("Dto1-1", dst.Name);
            Assert.AreEqual(1, dst.Count);
        }
    }
}