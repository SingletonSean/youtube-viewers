using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace YouTubeViewers.WPF.Test.E2E
{
    public class Tests
    {
        public WindowsDriver<WindowsElement> driver;
        AppiumOptions options;

        string appWorkingDirPath;
        string appPath;

        [Setup]
        public void Setup()
        {
            appWorkingDirPath = Path.GetFullPath(@"..\..\..\..\YouTubeViewers.WPF\bin\Debug\net5.0-windows");
            appPath = Path.Combine(appWorkingDirPath, "ouTube Viewers.exe");
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", appPath);
            options.AddAdditionalCapability("appWorkingDir", appWorkingDirPath);

            WindowsDriver<WindowsElement> driver = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"),
                options);
        }

        [Test]
        public void ShouldAddYouTubeViewer()
        {
            driver.FindElementByAccessibilityId("AddYouTubeViewerButton").Click();

            driver.FindElementByAccessibilityId("YouTubeViewerUsernameTextBox").SendKeys("SingletonSean");
            driver.FindElementByAccessibilityId("YouTubeViewerSubscribedCheckBox").Click();
            driver.FindElementByAccessibilityId("YouTubeViewerMemberCheckBox").Click();
            driver.FindElementByAccessibilityId("YouTubeViewerSubmitButton").Click();

            WindowsElement addedYouTubeViewerListingItem = driver.FindElementByAccessibilityId("SingletonSean_YouTubeViewerListingItem");

            Assert.That(addedYouTubeViewerListingItem, Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}