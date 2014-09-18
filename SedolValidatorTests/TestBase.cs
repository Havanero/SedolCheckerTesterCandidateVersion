namespace SedolValidatorTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The Testing Base Class.
    /// </summary>
    [TestClass]
    public class TestBase
    {
        #region Microsoft Test Related Properties

        /// <summary>
        /// The test context instance.
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }
        #endregion

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public virtual void TestInitialize()
        {
        }

        /// <summary>
        /// Tests the clean up.
        /// </summary>
        [TestCleanup]
        public virtual void TestCleanup()
        {
        }
    }
}
