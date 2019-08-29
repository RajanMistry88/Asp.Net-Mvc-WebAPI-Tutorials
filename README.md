# Asp.Net-Mvc-WebAPI-Tutorials
Asp.Net MVC WebAPI CRUD operation

<a href="https://www.youtube.com/playlist?list=PL_i5XdFY8J5uS6QGwCViDQhmt56JrlOhk" target="_blank">Video link</a><br/>

<b>Overview</b><br>
In this project i created simple Webservices for diffrent platform(Angular, Android, Ionic etc.) using .Net Mvc WebAPI. 
I'm using SQL Server 2014 for the DataBase you can find the database backup file in Asp.Net Mvc CRUD Project folder MvcTutorial >> DataBase >> MvcTutorial.bak and Script file MvcTutorialscript.sql 
 

<b>Environment setup</b><br>
<b>Step 1:</b> Restore database.
<br><b>Note: This my common and single Database for all the projects.(ex: if i create account using mvc application and login with angular aplicatoin it work because database is common for both the websites.</b>

<b>Step2:</b> After generating  database clone <a href="https://github.com/RajanMistry88/Asp.Net-Mvc-WebAPI-Tutorials" target="_blank">.Net Mvc WebAPI</a> and configure it with the Database for more deatils how to configure Database with Project read the <a href="https://github.com/RajanMistry88/Asp.Net-Mvc-Tutorials" target="_blank">MVC Project README.md</a> <br>
1.Change WebAPI connectionStrings in webconfig file.
2.Default RouteURL is : (routeTemplate: "api/{controller}/{id}") i have change with this (routeTemplate: "api/{controller}/{action}/{id}") so it will work like MVC url patten.
        
<b>Step 3:</b> You can use this WebAPI file for any other project like Mvc-5, Angualr-5 Ionic etc. 

<ul><b>Topic Cover in this Project</b>
  <li><b>(Routing, Model Validation, HttpGet, HttpPost, HttpPut, HttpDelete, Session Manage)</b></li>
  <li>User Registration (Insert Operation)</li>
  <li>Login (Authentication and Session Managing Operation)</li>
  <li>Forgot Password (Authenticate and Update Operation)</li>
  <li>Active User Account (Edit and Update Operation)</li>
  <li>Profile Update (Edit and Update Operation)</li>
  <li>Change Password (Create New Password Operation)</li>
  <li>Account (Delete Operation | Deactivate Operation)</li>
  <li>Logout (Session Dismiss)</li>
</ul>

