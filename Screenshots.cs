using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
public static class Screenshots {
       
    public static void TakeScreenShot(IWebDriver webDriver, string screenShotFileNameWithoutExtension, ImageFormat imageFormat, string screenShotDirectoryPath) {
        Screenshot screenShot = null;
        var browserName = string.Empty;

        if (webDriver.GetType() == typeof(InternetExplorerDriver)) {
            screenShot = ((InternetExplorerDriver)webDriver).GetScreenshot();
            browserName = "IE";
        }

        if (webDriver.GetType() == typeof(FirefoxDriver)) {
            screenShot = ((FirefoxDriver)webDriver).GetScreenshot();
            browserName = "Firefox";
        }

        if (webDriver.GetType() == typeof(ChromeDriver)) {
            screenShot = ((ChromeDriver)webDriver).GetScreenshot();
            browserName = "Chrome";
        }

        var screenShotFileName = screenShotFileNameWithoutExtension + "." + imageFormat.ToString().ToLower();

        if (screenShot != null) {
            if (!string.IsNullOrEmpty(screenShotDirectoryPath)) {
                Directory.CreateDirectory(screenShotDirectoryPath).CreateSubdirectory(browserName);
                var browserScreenShotDirectoryPath = Path.Combine(screenShotDirectoryPath, browserName);
                Directory.CreateDirectory(browserScreenShotDirectoryPath);
                var screenShotFileFullPath = Path.Combine(browserScreenShotDirectoryPath, screenShotFileName);
                screenShot.SaveAsFile(screenShotFileFullPath, imageFormat);
            }
        }
    }

}
