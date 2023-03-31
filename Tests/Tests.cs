using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using _3_aab_a2b;

namespace _TestsNS {
    
    [TestClass]
    public class CheckTransformC {
        
        [TestMethod]
        public void Check() {
            Assert.AreEqual("", Program.Transform(""), "TSTERR : void");           
            Assert.AreEqual("a", Program.Transform("a"), "TSTERR : a");
            Assert.AreEqual("abc", Program.Transform("abc"), "TSTERR : abc");
            Assert.AreEqual("a2", Program.Transform("aa"), "TSTERR : aa");
            Assert.AreEqual("a2b", Program.Transform("aab"), "TSTERR : aab");
            Assert.AreEqual("a2b2", Program.Transform("aabb"), "TSTERR : aabb");
            Assert.AreEqual("ab2", Program.Transform("abb"), "TSTERR : abb");
        }
    }
}
