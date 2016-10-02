# BookStore

BookStore is E-commerce  web site developed using web technologies: 
* ASP.NET 4.5
* entity framework(EF6)
* [autofac](https://github.com/autofac/Autofac)
* [automapper](https://github.com/AutoMapper/AutoMapper/wiki)
* twitter Bootstrap
* javascrip/JQuery
* HTML5/CSS3
* Razor engine

this project is divided in 4 sub projects for purpose of respecting solution architectures and best practices:
* BookStore.Domain.Classes is a Class library project containing the models used in the project
* BookStore.Domain.DataModels is a class library project representing the data access layer
* BookStore.Service is a class library project representing the service layer
* BookStore.web is ASP.net project representing the presentation layer

## Implemented features:
* filter books by keyword 
* view book details
* add book to shopping cart
* manage shopping cart(list added books , remove books, checkout)

## License 
[MIT License](https://opensource.org/licenses/MIT)

  
