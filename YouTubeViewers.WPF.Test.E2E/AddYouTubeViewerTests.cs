using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace YouTubeViewers.WPF.Test.E2E
{
    public class Tests
    {
        [Test]
        public void ShouldAddYouTubeViewer()
        {
            AppiumOptions options = new AppiumOptions();

            options.AddAdditionalCapability("app", @"C:\Storage\VS Repos\YouTube\YouTubeViewers\YouTubeViewers.WPF\bin\Debug\net5.0-windows\YouTube Viewers.exe");
            options.AddAdditionalCapability("appWorkingDir", @"C:\Storage\VS Repos\YouTube\YouTubeViewers\YouTubeViewers.WPF\bin\Debug\net5.0-windows");

            WindowsDriver<WindowsElement> driver = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"),
                options);

            try
            {
                driver.FindElementByAccessibilityId("AddYouTubeViewerButton").Click();

                driver.FindElementByAccessibilityId("YouTubeViewerUsernameTextBox").SendKeys("SingletonSean");
                driver.FindElementByAccessibilityId("YouTubeViewerSubscribedCheckBox").Click();
                driver.FindElementByAccessibilityId("YouTubeViewerMemberCheckBox").Click();
                driver.FindElementByAccessibilityId("YouTubeViewerSubmitButton").Click();

                WindowsElement addedYouTubeViewerListingItem = driver.FindElementByAccessibilityId("SingletonSean_YouTubeViewerListingItem");

                Assert.That(addedYouTubeViewerListingItem, Is.Not.Null);
            }
            finally
            {
                driver.Close();
            }
        }
    }
}