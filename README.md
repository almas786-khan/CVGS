# CVGS
 
# Owner: Almas Khan
# Project: CVGS gaming store
# About: 
This is a gaming web store where users can register and login to view new released games. They can also purchase and download games through this webstore.
There are many features in the webstore:
* Add friends
* Add games to wishlist and share it on social media
* Register for an gaming event to participate
* Rate and post a review for games
* Add preferences 
* save credit cards for payments.
The webstore also has a admin panel for crud operations of games and events. Admin should also evaluate game reviews before posting on website.

This repo also contains unit testing project for the same project, so if you need just the webstore code go to CVGS folder and clone that folder to your local folder.
Unit testing is done with Selenium and firefox webdriver, so if you need unit testing code go to UnitTestProject folder and clone it to your local folder. You do need CVGS code to make run the unit testing project. 
-----------------------------------------------------------------------------------------------------------------------------------------
# Link for live project: 
* Used Azure to live the project. The project uses SQL database, so on Azure first made a SQL database with SQL authentication and then open SQL management studio on your local and copy the Azure Sql Database instance and same username and password to connect, then import your local database to the azure database instance, the steps will be straight forward. After this your Azure database has your local database. After that make a web app in azure and link your github repo in deployment center, that way Azure will take your code from Git and make it live.
