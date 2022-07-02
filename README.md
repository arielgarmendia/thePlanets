<p align="center"><img src="https://github.com/arielgarmendia/thePlanets/blob/master/Website/wwwroot/images/logo_big.png"></p>

## **About:**

Example solution to provide a list of near-collition objects to a planet. 

## **Important tips and notes:**

- **Clone** this repository in your local repo folder then **Open** solution then **Rebuild** solution to restore **Nuget** packages.
- Before launching the website check the *WebAPI* service is running in yout *IIS Express*. 
    - Also check the port number in use by the WebAPI service, and compare it with the one assigned in Planets.WebAPI.Proxy/PlanetsProxu.ce => static string baseAddress = "http://localhost:61889/";.
- Login and password to access the website are: 
    - **login**: admin 
    - **password**: 1Planets23
- Before logging into the website, check that security is working by clicking on any of the menu links in the login page.
    - Check API's port, then goto Planets.WebAPI.Proxy/class PlanetsProxy/baseAddress property, and change port if different.
