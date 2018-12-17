1] Please unzip the ContactCrud.zip file which will create the ContactCrud folder and 

2] Please run ContactCrud\ContactDBScript.sql on any SQL database.
   This will create required tables and sp for the application 

3] Please change the connection string in ContactCrud\WebMVCContacts\WcfContactService\webconfig for the database connection

4] Please configure the webservice in local IIS server with following setting
    hosting app name : WcfContactService
    physical path : ContactCrud\WebMVCContacts\WcfContactService
    application pool : .Net CLR Version 4.0 Pipeline Mode: Integrated 
    Enabled Protocol : http

5] Notes : 
   5.1]  I  have added the service referance with name "WcfClientRef" for http://localhost/WcfContactService/Service1.svc
   in the project ContactCrud\WebMVCContacts .prj
   5.2] I have set WebMVCContacts.prj as startup project the  
        along with start url as http://localhost:3324/Contact/GetAllContactDetails


7] Please open the ContactCrud\WebMVCContacts\WebMVCContacts.sln in any visual studio with version 2013 
   and above and run the app which has functionality of create edit, delete, listing of contacts




