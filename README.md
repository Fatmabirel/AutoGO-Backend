# AutoGO: Araç Kiralama Sistemi 🚗

Bu proje, kullanıcıların kolaylıkla araç kiralayabileceği, çeşitli özellikler sunan kapsamlı bir araç kiralama sistemidir.

<p>📌Projenin frontend kısmına <a href=https://github.com/Fatmabirel/RentACar-Frontend>buradan</a> ulaşabilirsiniz.</p>

#### GEREKSİNİMLER 🛠
- [x] Web projesi: 
  ![Asp.NET Web API](https://img.shields.io/badge/asp.net%20web%20api-%231BA3E8.svg?style=for-the-badge&logo=dotnet&logoColor=white)
- [x] Veri tabanı: 
  ![MsSQL Server](https://img.shields.io/badge/mssql%20server-%23CC2927.svg?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
- [x] Dökümantasyon için:
  ![Postman](https://img.shields.io/badge/postman-%23FF6C37.svg?style=for-the-badge&logo=postman&logoColor=white)
  ![Swagger](https://img.shields.io/badge/swagger-%2385EA2D.svg?style=for-the-badge&logo=swagger&logoColor=black)

#### PROJEDE KULLANILAN TEKNOLOJİLER VE KÜTÜPHANELER 🛠️
<p>
  <img alt="C#" src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white" />
  <img alt=".NET" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" />
  <img alt="Entity Framework" src="https://img.shields.io/badge/entity%20framework-%2358B9C9.svg?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img alt="FluentValidation" src="https://img.shields.io/badge/fluentvalidation-%23563D7C.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="JWT" src="https://img.shields.io/badge/jwt-%23FFA500.svg?style=for-the-badge&logo=generic&logoColor=white" />
</p>


#### 📫 NASIL BİR PROJE OLUŞTURDUK?
<p>Projemiz, kullanıcıların kolaylıkla araç kiralayabileceği, çeşitli özellikler sunan kapsamlı bir araç kiralama sistemidir. Bu proje, kullanıcı deneyimini ön planda tutarak, araç kiralama sürecini hem hızlı hem de verimli hale getirmeyi amaçlamaktadır.</p>

## PROJE DETAYLARI📝

Projemiz, .Net ve Angular teknolojilerini içeren modern bir web uygulamasıdır. Projemizde MsSQL kullanılmış olup, dökümantasyon için Swagger entegrasyonu sağlanmıştır.

Projemizde veritabanı işlemleri için **Entity Framework** kullanılmış ve **Database First** yaklaşımı benimsenmiştir.

Ek olarak, projede şu önemli kütüphaneler ve araçlar kullanılmaktadır:
- **FluentValidation**: Veri doğrulama süreçlerini yönetmek için.
- **JWT (JSON Web Token)**: Kimlik doğrulama ve yetkilendirme işlemlerini güvenli bir şekilde gerçekleştirmek için.

Bu sayede, projemiz yüksek performanslı, kolay yönetilebilir ve güvenli bir mimariye sahip olmuştur.

🎯Projede veri tabanı bağlantı yolu RentACarContext içinde yazılmıştır. 

```c#
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("Server=DESKTOP-Q270QVE\\SQLEXPRESS;Database=ReCap;Trusted_Connection=True;TrustServerCertificate=True;");
}
```

🔒 Projemizin katmanları aşağıda gösterilmiştir:
</br>
<img width="400" alt="image" src="https://github.com/user-attachments/assets/2c216b69-7c98-43da-819a-9468e82879a7">
</br>

-----------------------------------------------------------------------
## 🌱ENTITY KATMANI

✎ Entityler Entity katmanında oluşturulmuştur. Aşağıda örnek olarak Brand Entity dosyasını görebilirsiniz. Her class için gereksiz kod tekrarını önlemek adına base class olan Entity sınıfından miras alır. Diğer entityleri projenin içerisinde inceleyebilirsiniz.

Oluşturulan Entityler

- ⚡Brand, marka bilgilerini tutar.
- ⚡Car, araba bilgilerini tutar.
- ⚡CarImage, araba resimleri bilgilerini tutar.
- ⚡Color, renk bilgilerini tutar.
- ⚡Customer, müşteri bilgilerini tutar.
- ⚡OperationClaim, rol bilgilerini tutar.
- ⚡Rental, araba kiralama bilgilerini tutar.
- ⚡User, kullanıcı bilgilerini tutar.
- ⚡UserOperationClaim, kullanıcı rol bilgilerini tutar.
```c#
 public class Brand : IEntity
 {
     public int Id { get; set; }
     public string Name { get; set; }
 }
```
-----------------------------------------------------------------------
## 🌱DATA ACCESS KATMANI

Data Access katmanı, uygulamanın veri tabanı ile olan etkileşimini düzenleyerek, veri saklama işlemlerinin güvenli ve etkili bir şekilde yönetilmesini sağlayan katmandır.

<img width="400" alt="image" src="https://github.com/user-attachments/assets/bd79cfb2-98d9-4b96-8d79-8c523f5a6890">
</br>
<p>✎ Data Access katmanında, oluşturulan Entity sınıflarını veri tabanı modellerine karşılık gelecek olan tabloların oluşturulması için RentACarContext sınıfı bulunmaktadır. Ayrıca bu katmanda veri tabanı işlemlerini gerçekleştirmek için oluşturulan repository sınıfları bulunmaktadır.</p>

📌 Aşağıda RentACarContext sınıfı örnek olarak verilmiştir. Diğer sınıfları projeden inceleyebilirsiniz.

```c#
public class RentACarContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-Q270QVE\\SQLEXPRESS;Database=ReCap;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<CarImage> CarImages { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}
```
-----------------------------------------------------------------------
## 🌱BUSINESS KATMANI

<img width="400" alt="image" src="https://github.com/user-attachments/assets/b9759e6d-70eb-4a51-9e3e-d38cb4f122e3">
</br>
<p> 
</br>🌕 Business katmanında, uygulamanın iş kodları, iş kuralları ve doğrulama (validation) işlemleri yapılmaktadır. Ayrıca, iş kurallarını uygulayan ve veri doğrulamasını gerçekleştiren sınıflar burada bulunur. </br> </p>
<p>📃 Aşağıda Fluent Validation kütüphanesi kullanılarak Brand Entity için oluşturulan validator sınıfı örnek olarak verilmiştir. Diğer sınıfları projeden inceleyebilirsiniz.</p>

```c#
public class BrandValidator : AbstractValidator<Brand>
{
    public BrandValidator()
    {
        RuleFor(b=>b.Name).NotEmpty();
        RuleFor(b=>b.Name).MinimumLength(2);
    }
}
```
🔎 Böylece daha Controller tarafında istek atılmadan requestlerin istenilen kurallara uygun olup olmadığı kontrol edilir.

-----------------------------------------------------------------------
## 🌱WEBAPI KATMANI

⚓ Bu katmanda işlemlerin gerçekleştirildiği Controller sınıfları oluşturulur. Aşağıda BrandsController dosyasının kodları örnek olarak gösterilmiştir.

```c#
[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    IBrandService _brandService;
    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
       var result = _brandService.GetAll();
        if(result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(int id)
    {
        var result = _brandService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("Add")]
    public IActionResult Add(Brand brand)
    {
        var result = _brandService.Add(brand);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("Update")]
    public IActionResult Update(Brand brand)
    {
        var result = _brandService.Update(brand);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("Delete")]
    public IActionResult Delete(Brand brand)
    {
        var result = _brandService.Delete(brand);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
   //diğer metotlara proje kodlarından ulaşabilirsiniz.
```

Projede 9 adet Controller sınıfı bulunmaktadır. Proje isterlerine göre eklenen Controller sınıfları ise şunlardır;
- ⚡ AuthController, yetkilendirme işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ BrandsController, marka işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ CarsController, araba işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ CarImagesController, araba resimleri işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ ColorsController, renk işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ CustomersController, müşteri işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ RentalsController, araba kiralama işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ UsersController, kullanıcı işlemlerinin gerçekleştirildiği sınıftır.

Görüşürüz 🎉
