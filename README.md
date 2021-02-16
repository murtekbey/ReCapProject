## Car Rental Management System

### Introduction - Tanıtım
- This is an automation project where you can manage your car rental operations. Still working on this project. It is a fast software development infrastructure suitable for modular PnP (Plug and Play) architecture, focusing on SOLID principles and Clean Architecture methods. The project will progress and take its final form over time.
- Araç kiralama operasyonlarınızı yönetebileceğiniz bir otomasyon projesidir. Modüler PnP (Tak ve Çalıştır) mimarisine uygun, SOLID prensiplerine ve temiz mimari yöntemlerine bağlı bir projedir. Hala proje üzerinde çalışmalar devam ediyor. Zaman içerisinde ilerleyecek ve nihai şeklini alacaktır.

### Latest Updates - Son Güncellemeler
- 16 February 2021
	- WebAPI layer is added. Set WebAPI as startup project for testing (WebAPI katmanı sisteme eklendi. Test etmek için WebAPI katmanını başlangıç projesi olarak ayarlamanız gerekiyor)
	- CRUD Operations is added to WebAPI/Controllers layer (CRUD operasyonları WebAPI/Controllers katmanına eklendi) 
	- Detail operations have been updated (Detay operasyonları güncellendi)
	- Singletons are added to [Startup.cs](https://github.com/murtekbey/ReCapProject/tree/master/WebAPI/Startup.cs)
	- RentalDetailDto entity and its operations has been updated.
	- Some bugs fixed.
	- Tested via [Postman](https://www.postman.com/)

### Installation - Kurulum
- [SqlQuery.sql](https://github.com/murtekbey/ReCapProject/blob/master/SQLQuery.sql) Create your table as you can see on the link. (Tablonuzu linkde gördüğünüz şekilde oluşturun)

- The following packages must be added to the "DataAcess" layer via "NuGet". ("NuGet" aracılığıyla "DataAccess" katmanına aşağıdaki paketler eklenmelidir.)
	- Microsoft.EntityFrameworkCore(3.1.11)
	- Microsoft.EntityFrameworkCore.SqlServer(3.1.11)

- The following package must be added to the "Core" layer via "NuGet". ("NuGet" aracılığıyla "Core" katmanına aşağıdaki paket eklenmelidir.)
	- Microsoft.EntityFrameworkCore.SqlServer(3.1.11)

### Layers - Katmanlar
- [Business](https://github.com/murtekbey/ReCapProject/tree/master/Business)
- [Core](https://github.com/murtekbey/ReCapProject/tree/master/Core)
- [DataAccess](https://github.com/murtekbey/ReCapProject/tree/master/DataAccess)
- [Entities](https://github.com/murtekbey/ReCapProject/tree/master/Entities)
- [ConsoleUI](https://github.com/murtekbey/ReCapProject/tree/master/ConsoleUI)
- [WebAPI](https://github.com/murtekbey/ReCapProject/tree/master/WebAPI)

Code released under the [MIT](https://github.com/murtekbey/ReCapProject/blob/master/LICENSE) License. © 2021 Murat ALTINPINAR