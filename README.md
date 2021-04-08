## __Car Rental Management System__

### Introduction - *Tanıtım*
- This is an automation project where you can manage your car rental operations. Still working on this project. It is a fast software development infrastructure suitable for modular PnP (Plug and Play) architecture, focusing on SOLID principles and Clean Architecture methods. The project will progress and take its final form over time.
- *Araç kiralama operasyonlarınızı yönetebileceğiniz bir otomasyon projesidir. Modüler PnP (Tak ve Çalıştır) mimarisine uygun, SOLID prensiplerine ve temiz mimari yöntemlerine bağlı bir projedir. Hala proje üzerinde çalışmalar devam ediyor. Zaman içerisinde ilerleyecek ve nihai şeklini alacaktır*

### Installation - *Kurulum*
- [SqlQuery.sql](https://github.com/murtekbey/ReCapProject/blob/master/SQLQuery.sql) Create your table as you can see on the link. *(Tablonuzu linkde gördüğünüz şekilde oluşturun)*

- Please run the following codes in order to install the required packages. *(Gerekli paketleri kurmak için lütfen aşağıdaki kodları sırasıyla çalıştırın.)*
```
# Clone to repository (Depoyu klonla)
$ git clone https://github.com/murtekbey/ReCapProject

# Go to the folder you cloned (Klonladığınız klasöre gidin)
$ cd ReCapProject

# Install dependencies (Bağımlı olduğunuz paketleri yükleyin)
$ dotnet restore

# Run the application from the WebAPI layer (WebAPI katmanından uygulamayı çalıştırın)
```

### Latest Updates - *Son Güncellemeler*
- 29 March 2021
	- Payment Service is added. *(Ödeme servisi eklendi.)*
	- Some business rules are refactored. *(Bazı iş kuralları yeniden düzenlendi.)*
	- Implementation of Angular SPA is added.  *(Angular eklendi.)*
	(You can check here. [ReCapProject-SPA](https://github.com/murtekbey/ReCapProject-SPA) *(Linkden Angular projesine ulaşabilirsiniz.)*

- 04 March 2021
	- Cache is added.
	- Transaction is added.
	- Performance is added.
	- Managers are refactored according to new updates *(Managerlar yeni güncellemelere göre yeniden düzenlendi.)*
	- Performance time was set to 1 second for testing purposes. You can update it if you want. *(Test etme amacıyla performans süresi 1 saniye olarak ayarlandı. İsterseniz güncelleyebilirsiniz.)*
	- Tested via [Postman](https://www.postman.com/) *(Postman aracılığıyla test edildi.)*


- 02 March 2021
	- Authentication and Authorization is added. *(Kimlik doğrulama ve yetkilendirme eklendi.)*
	- For now, Need Authorization for Create, Update, Delete functions. *(Artık ekleme, silme ve güncelleme fonksiyonları için yetkiye ihtiyaç var.)*
	- [SqlQuery.sql](https://github.com/murtekbey/ReCapProject/blob/master/SQLQuery.sql) is updated for Authorization tables. *(SqlQuery dosyası güncellendi.)*
	- Tested via [Postman](https://www.postman.com/) *(Postman aracılığıyla test edildi.)*
	- CarImages operations are refactored. *(CarImages operasyonları yeniden düzenlendi.)*
	- ConsoleUI layer is removed. *(ConsoleUI katmanı silindi.)*

- 26 February 2021
	- CarImageCreationDto is added *(CarImageCreationDto eklendi)*
	- AutoMapper injected to WebAPI layer *(WebAPI katmanına AutoMapper eklendi)*
	- Image files "POST" operations can now be executed via FormData. *(Resim dosyaları "POST" operasyonları artık FormData üzerinden gerçekleştirilebilir.)*

- 25 February 2021
	- [SqlQuery.sql](https://github.com/murtekbey/ReCapProject/blob/master/SQLQuery.sql) is updated for CarImages *(SqlQuery dosyası CarImages eklenerek güncellendi.)*
	- Business Rules added *(Business kuralları eklendi.)*
	- CarImages added to project. *(CarImages projeye eklendi.)*
	- Filing Rules are added for CarImages *(CarImages için dosyalama kuralları eklendi.)*
	- Tested via [Postman](https://www.postman.com/) after refactoring. *(Yeniden düzenleme yapıldıktan sonra Postman aracılığıyla test edildi.)*

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

### Layers - *Katmanlar*
- [Business](https://github.com/murtekbey/ReCapProject/tree/master/Business)
- [Core](https://github.com/murtekbey/ReCapProject/tree/master/Core)
- [DataAccess](https://github.com/murtekbey/ReCapProject/tree/master/DataAccess)
- [Entities](https://github.com/murtekbey/ReCapProject/tree/master/Entities)
- [WebAPI](https://github.com/murtekbey/ReCapProject/tree/master/WebAPI)

_**Code released under the [MIT](https://github.com/murtekbey/ReCapProject/blob/master/LICENSE) License. © 2021 Murat ALTINPINAR**_