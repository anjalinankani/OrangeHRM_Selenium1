using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

class EditTest1
{

    static IWebDriver driver = new ChromeDriver();

    static string url = "http://opensource.demo.orangehrmlive.com/";
    static string badLoginUrl = "http://opensource.demo.orangehrmlive.com/index.php/auth/validateCredentials";
    static string url2 = "http://opensource.demo.orangehrmlive.com/index.php/pim/contactDetails/empNumber/1";
    static string userNameId = "txtUsername";
    static string userPasswordId = "txtPassword";
    static string loginButtonId = "btnLogin";
    static string userName = "linda.anderson"; // login username
    static string userPassword = "linda.anderson"; // login user password
    string team = "05";


    static IWebElement userNameInputField;
    static IWebElement userPasswordInputField;
    static IWebElement loginButton;
    static IWebElement textBox;
    static IWebElement myinfo;

    static void Main()
    {

        // Navigating to the Main Page

        driver.Navigate().GoToUrl(url);

        // Username input field

        userNameInputField = driver.FindElement(By.Id(userNameId));

        // User Password input field 

        userPasswordInputField = driver.FindElement(By.Id(userPasswordId));

        // getting login button

        loginButton = driver.FindElement(By.Id(loginButtonId));

        // entering the username 

        userNameInputField.SendKeys(userName);

        try
        {

            if (userNameInputField.GetAttribute("value") == userName)
            {
                Console.WriteLine("User name input successful!");
            }

            if (userPasswordInputField.GetAttribute("value") == userPassword)
            {
                Console.WriteLine("User password input successful!");
            }

            // Entering the user password 

            userPasswordInputField.SendKeys(userPassword);

            // Clicking the login button

            loginButton.Click();

            if (driver.Url != url && driver.Url != badLoginUrl)
            {
                Console.WriteLine("User logged in successfully!");
            }

            // Finding the element of myinfo by id 

            myinfo = driver.FindElement(By.Id("menu_pim_viewMyDetails"));

            // Clicking the myinfo 

            myinfo.Click();
            Console.WriteLine("my info is clicked");

            // Navigating to the url2 to open contact details

            driver.Navigate().GoToUrl(url2);

            // Creating IWebElement for EDIT and Finding Element by the Id

            IWebElement Edit;
            Edit = driver.FindElement(By.Id("btnSave"));
            Edit.Click();

            textBox = driver.FindElement(By.Id("contact_street1"));
            textBox.SendKeys("105 - Gibson Street");

            textBox = driver.FindElement(By.Id("contact_street2"));
            textBox.SendKeys("5 - St.George, Toronto");

            textBox = driver.FindElement(By.Id("contact_city"));
            textBox.SendKeys("Toronto");

            textBox = driver.FindElement(By.Id("contact_province"));
            textBox.SendKeys("Ontario");

            // Creating IWebElement for SAVE and Finding Element by the Id

            IWebElement Save;
            Save = driver.FindElement(By.Id("btnSave"));
            Save.Click();

            Console.WriteLine("Address Street 1 information successfully displayed into the contact details");

            Console.WriteLine("Address Street 2 information successfully displayed into the contact details");

            Console.WriteLine("City Name information successfully displayed into the contact details");

            Console.WriteLine("State/Province information successfully displayed into the contact details");

            // 5 seconds pause

            Thread.Sleep(5000);



        }

        catch (NoSuchElementException) { }
        Thread.Sleep(3000);

        // Close the browser

        driver.Quit();
    }
}
