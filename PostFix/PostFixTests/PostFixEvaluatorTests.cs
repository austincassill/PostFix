using NUnit.Framework;
using PostFix;

namespace PostFixTests
{
    public class Tests
    {
        private PostFixEvaluator _postFixConverter;

        [SetUp]
        public void Setup()
        {
            _postFixConverter = new PostFixEvaluator();
        }

        [Test]
        public void Evaluates_Simple_PostFix()
        {
            var results = _postFixConverter.Evaluate("1 2 +");
            Assert.AreEqual(3, results);
        }

        [Test]
        public void Ignore_Too_Many_Operands()
        {
            var results = _postFixConverter.Evaluate("1 1 2 1 2 +");
            Assert.AreEqual(3, results);
        }
    }
}