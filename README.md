<p align="center"><img src="https://theinventory.travelgosystems.net/images/logo.png"></p>

## **About:**

Example solution to provide basic functionalities for a products inventory. 

- Check **problem.md** (in spanish) to review functionalities and requirements.
- Using *.Net Core 2.1* and *SQLite*. 
- *WebAPI* service project manages the inventory operations and interacts with the database.
- *Inventory.WebAPI.Proxy* acts as a middle layer to get/post objects from/to the *WebAPI* service and the consuming clients.
- Inventory management website project uses *MVC* on top of *.Net Core 2.1*. Security, Session (*TempData*) and Config extensions. *Bootstrap* theme and controls.
- Console application project can be used to test *WebAPI* functionalities and for initial products insertion as well.

## **Important tips and notes:**



- **Clone** this repository in your local repo folder then **Open** solution then **Rebuild** solution to restore **Nuget** packages.
- Before launching the website check the *WebAPI* application is running in yout *IIS Express*.
- The *WebAPI* application uses *SQLite* to store the inventory products.
- Login and password to access the website are: 
    - **login**: admin 
    - **password**: 1Inventory23
- Before logging into the website, check that security is working by clicking on any of the menu links in the login page.
- An online working version of both, the website and *WebAPI* service are available here:
    - https://theinventory.travelgosystems.net
    - https://theinventorywebapi.travelgosystems.net
    
      >Usage example: https://theinventorywebapi.travelgosystems.net/api/products/all
- If you remove all products in the inventory and want to insert few test ones, just run the console application provided in the solution: *Products.Webapi.Creator*.
- *JS* validators located at Insertion page just show a red box if empty or invalid values.
