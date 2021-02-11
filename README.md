## Car Rental Management System


### Introduction - Tanýtým
- This is an automation project where you can manage your car rental operations. Still working on this project. It is a fast software development infrastructure suitable for modular PnP (Plug and Play) architecture, focusing on SOLID principles and Clean Architecture methods. The project will progress and take its final form over time.
- Araç kiralama operasyonlarýnýzý yönetebileceðiniz bir otomasyon projesidir. Modüler PnP (Tak ve Çalýþtýr) mimarisine uygun, SOLID prensiplerine ve temiz mimari yöntemlerine baðlý bir projedir. Zamanla Hala proje üzerinde çalýþmalar devam ediyor. Zaman içerisinde ilerleyecek ve nihai þeklini alacaktýr.


### Installation - Kurulum
- [SqlQuery.sql](https://github.com/murtekbey/ReCapProject/blob/master/SQLQuery.sql) Create your table as you can see on the link. (Tablonuzu linkde gördüðünüz þekilde oluþturun)

- The following packages must be added to the "DataAcess" layer via "NuGet". ("NuGet" aracýlýðýyla "DataAccess" katmanýna aþaðýdaki paketler eklenmelidir.)
	- Microsoft.EntityFrameworkCore(3.1.11)
	- Microsoft.EntityFrameworkCore.SqlServer(3.1.11)

- The following package must be added to the "Core" layer via "NuGet". ("NuGet" aracýlýðýyla "Core" katmanýna aþaðýdaki paket eklenmelidir.)
	- Microsoft.EntityFrameworkCore.SqlServer(3.1.11)


### Layers - Katmanlar
- [Business](https://github.com/murtekbey/ReCapProject/tree/master/Business)
- [Core](https://github.com/murtekbey/ReCapProject/tree/master/Core)
- [DataAccess](https://github.com/murtekbey/ReCapProject/tree/master/DataAccess)
- [Entities](https://github.com/murtekbey/ReCapProject/tree/master/Entities)
- [ConsoleUI](https://github.com/murtekbey/ReCapProject/tree/master/ConsoleUI)
