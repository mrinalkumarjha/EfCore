# EfCore6

# What is EF Core?

	ef core is evolution of ef orm which is been around 2008 and improving itself dramatically over the years.
	ef core encompasses a set of .NET API for performing data access in your software.
	and it is a official data access plateform for Microsoft. it is cross plateform.
	you can build and run efcore based application and api in window, linux , mac and even in docker container...

	microsoft has so many database provider available for different databases.

	we can use LocalDb which is lighter version of sqlserver which comes with visual studio.


# Setting up the solution

	
	1> Create a solution name SamuraiApp.

	2> Create a classLibrary project inside solution which will represent business domain (SamuraiApp.Domain).
		Add Samurai and Quotes class in domain.samurai and quotes has one to many relationship. a samurai can
		have multiple quotes.

	3> Create a classLibrary project inside solution which will hold data(SamuraiApp.Data).
		Add Microsoft.EntityFrameworkCore.SqlServer provider to data project from nuget. once you install provider it also install its 
		dependencies which is efcore.

		Add the reference of domain project in data.

		Add SamuraiContext class and inherit with DbContext. it has all operation related to database
		tracking and update.
		EX:
		public class SamuraiContext:DbContext
		{

		}


		Now we need to explicitly provide data provider and connection string to context. there is few ways to do that.
		1: directly in dbcontext class. for this method we can override OnConfiguring virtual method. and
			use optionbuilder to configure provider and connection string.
			
		2: inject connection and provider info at run time dynamically.


	4> Create a UI project inside solution which will show data(SamuraiApp.UI).

		Reference domain and data into UI app. and make ui project as startup project of solution.



# Controlling Database creation and schema change with migration.

	FLow of migration

	Define/ Change Model  > Create migration file > Apply migration to db or script.


# Adding first migration

	Migration commands: Microsoft.EntityFrameworkCore.Tools package holds migration command.
	add it in .Data project. it has dependency of Microsoft.EntityFrameworkCore.Design package also
	so by adding it we get design package also.

	Migration APIS:  migration api are in Microsoft.EntityFrameworkCore.Design package.
	add this in ui project.it is needed to create migration.

	run following command to create first migration

	add-migration init   : this creates a migration folder inside proj .Data


