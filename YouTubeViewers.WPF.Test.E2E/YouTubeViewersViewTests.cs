using NUnit.Framework;
using YouTubeViewers.WPF.Views;

namespace YouTubeViewers.WPF.Test.E2E
{
    [TestFixture]
    public class YouTubeViewersViewTests
    {
        [Test]
        public void Initialize_ShouldFailBecauseYouCanNotRenderWpfComponentsOffTheUiThread()
        {
            Assert.Throws<InvalidOperationException>(() => new YouTubeViewersView());
        }
    }
}
