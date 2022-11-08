# Playwright.Vethman
Demo project for using Playwright with NUnit

# First try test HomePage_Logout_ShouldLogout
It should not succeed, because you need to login first. We do not want to login for every test or keep the browser open after logging in for every test. So we are going to make use of Playwright LoginOnce functionality.

# Run Test LoginAndSaveState
First comment out the ignore attribute on the test. This test will login for you, if you get the captcha please be creative and debug to solve the puzzle. The goal is to get playwright to save the sessionstate after login in.

# Run every test 
Uncomment the ignore attribute first on test 'LoginAndSaveState', then run all the tests.

# Failed test!
Investigate why one test fails with trace viewer https://trace.playwright.dev/. The trace.zip can be found in ..\Playwright.Vethman\Playwright.Vethman.UiTests\bin\Debug\net6.0\Tracing

# Create a test to order a delicious pizza... 
Try to create the necessary pageObjects/components to fill in your adres and more! Start learning this amazing library PLAYWRIGHT!