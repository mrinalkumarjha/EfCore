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
		Add Ef core to data project from nuget.

	4> Create a UI project inside solution which will show data(SamuraiApp.UI).
