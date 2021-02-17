## __Car Rental Management System__

### Introduction - *Tanıtım*
- This is an automation project where you can manage your car rental operations. Still working on this project. It is a fast software development infrastructure suitable for modular PnP (Plug and Play) architecture, focusing on SOLID principles and Clean Architecture methods. The project will progress and take its final form over time.
- *Araç kiralama operasyonlarınızı yönetebileceğiniz bir otomasyon projesidir. Modüler PnP (Tak ve Çalıştır) mimarisine uygun, SOLID prensiplerine ve temiz mimari yöntemlerine bağlı bir projedir. Hala proje üzerinde çalışmalar devam ediyor. Zaman içerisinde ilerleyecek ve nihai şeklini alacaktır*

### Latest Updates - *Son Güncellemeler*

- 18 February 2021
	- Autofac, Autofac.Extensions.DependencyInjection, Autofac.Extras.DynamicProxy are added to project. *(Autofac projeye eklendi.)*
	- AOP and IoC container structures are now used in the project *(Artık projede AOP ve IoC yapıları kullanılıyor.)*
	- FluentValidation is added. Validation processes will now be performed with the help of FluentValidation. *(Validation işlemleri artık FluentValidation yardımıyla gerçekleştirilecek.)*
	- Business layer has been updated. Added attributes instead of conditions. *(Business katmanı güncellendi. Koşul döngüleri yerine attributelar eklendi.)*
	- Codes have been refactored according to Autofac and FluentValidation. You can follow commits. *(Kodlar Autofac ve FluentValidationa göre tekrar düzenlendi. Commitlerden takip edebilirsiniz.)*
	- Some bugs are fixed. *(Bazı hatalar düzeltildi)*
	- Tested via [Postman](https://www.postman.com/) after refactoring. *(Yeniden düzenleme yapıldıktan sonra Postman aracılığıyla test edildi.)*

- 16 February 2021
	- WebAPI layer is added. Set WebAPI as startup project for testing *(WebAPI katmanı sisteme eklendi. Test etmek için WebAPI katmanını başlangıç projesi olarak ayarlamanız gerekiyor)*
	- CRUD Operations is added to WebAPI/Controllers layer *(CRUD operasyonları WebAPI/Controllers katmanına eklendi)*
	- Detail operations have been updated *(Detay operasyonları güncellendi)*
	- Singletons are added to [Startup.cs](https://github.com/murtekbey/ReCapProject/tree/master/WebAPI/Startup.cs)
	- RentalDetailDto entity and its operations has been updated.
	- Some bugs fixed.
	- Tested via [Postman](https://www.postman.com/)

### Installation - *Kurulum*
- [SqlQuery.sql](https://github.com/murtekbey/ReCapProject/blob/master/SQLQuery.sql) Create your table as you can see on the link. *(Tablonuzu linkde gördüğünüz şekilde oluşturun)*

- __*"Autofac v6.1.0"*__ package must be added to the following layers via "NuGet" *("NuGet" aracılığıyla "Autofac v6.1.0" paketi aşağıdaki katmanlara eklenmelidir)*
	- [Business](https://github.com/murtekbey/ReCapProject/tree/master/Business)
	- [Core](https://github.com/murtekbey/ReCapProject/tree/master/Core)

- __*"Autofac.Extensions.DependencyInjection v7.1.0"*__ package must be added to the following layers via "NuGet" *("NuGet" aracılığıyla "Autofac.Extensions.DependencyInjection v7.1.0" paketi aşağıdaki katmanlara eklenmelidir)*
	- [Core](https://github.com/murtekbey/ReCapProject/tree/master/Core)
	- [WebAPI](https://github.com/murtekbey/ReCapProject/tree/master/WebAPI)

- __*"Autofac.Extras.DynamicProxy v6.0.0"*__ package must be added to the following layers via "NuGet" *("NuGet" aracılığıyla "Autofac.Extras.DynamicProxy v6.0.0" paketi aşağıdaki katmanlara eklenmelidir)*
	- [Business](https://github.com/murtekbey/ReCapProject/tree/master/Business)
	- [Core](https://github.com/murtekbey/ReCapProject/tree/master/Core)

- __*"Microsoft.EntityFrameworkCore v3.1.11"*__ package must be added to the following layers via "NuGet" *("NuGet" aracılığıyla "Microsoft.EntityFrameworkCore v3.1.11" paketi aşağıdaki katmanlara eklenmelidir)*
	- [DataAccess](https://github.com/murtekbey/ReCapProject/tree/master/DataAccess)

- __*"Microsoft.EntityFrameworkCore.SqlServer v3.1.11"*__ package must be added to the following layers via "NuGet" *("NuGet" aracılığıyla "Microsoft.EntityFrameworkCore.SqlServer v3.1.11" paketi aşağıdaki katmanlara eklenmelidir)*
	- [Core](https://github.com/murtekbey/ReCapProject/tree/master/Core)
	- [DataAccess](https://github.com/murtekbey/ReCapProject/tree/master/DataAccess)

### Layers - *Katmanlar*
- [Business](https://github.com/murtekbey/ReCapProject/tree/master/Business)
- [Core](https://github.com/murtekbey/ReCapProject/tree/master/Core)
- [DataAccess](https://github.com/murtekbey/ReCapProject/tree/master/DataAccess)
- [Entities](https://github.com/murtekbey/ReCapProject/tree/master/Entities)
- [ConsoleUI](https://github.com/murtekbey/ReCapProject/tree/master/ConsoleUI)
- [WebAPI](https://github.com/murtekbey/ReCapProject/tree/master/WebAPI)

_**Code released under the [MIT](https://github.com/murtekbey/ReCapProject/blob/master/LICENSE) License. © 2021 Murat ALTINPINAR**_