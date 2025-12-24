# İkinci El Eşya Satış Platformu

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş bir web uygulamasıdır.  
Uygulamanın amacı, kullanıcıların ikinci el ürünlerini listeleyebilmesi ve diğer kullanıcıların bu ürünleri görüntüleyebilmesidir. Yönetici (Admin) rolüne sahip kullanıcılar ise sistem yönetimi işlemlerini gerçekleştirebilir.


## Kullanılan Teknolojiler

- ASP.NET Core (MVC Mimarisi)
- Entity Framework Core (Code-First ve Migrations)
- ASP.NET Core Identity
- SQLite / SQL Server
- Bootstrap
- HTML / CSS



## Proje Özellikleri

Kullanıcı (User):
- Kayıt olma ve giriş yapma
- Profil oluşturma
- Yeni ürün ekleme (başlık, açıklama, fiyat, kategori, resim yükleme)
- Kendi ürünlerini düzenleme ve silme
- Diğer kullanıcıların ürünlerini listeleme ve filtreleme
- Yönetici rolü için Kategori yönetimi (CRUD)

Yönetici (Admin):
- Kategori yönetimi (CRUD)
- Uygunsuz ürünleri silme
- Kullanıcı yönetimi


Kimlik Doğrulama ve Yetkilendirme:
- Kimlik doğrulama için ASP.NET Core Identity kullanılmıştır
- Rol bazlı yetkilendirme uygulanmıştır
- Projede kullanılan roller:
  - Admin
  - User
- Yönetici sayfaları `[Authorize(Roles = "Admin")]` attribute’ü ile korunmuştur


## Veritabanı

- Entity Framework Core (Code-First yaklaşımı)
- Veritabanı güncellemeleri için Migrations kullanılmıştır
- İlişkiler:
  - One-to-Many (Kategori → Ürünler)
  - One-to-Many (Kullanıcı → Ürünler)


## Resim Yükleme

- Kullanıcılar ürünler için resim yükleyebilir
- Yüklenen resimler `wwwroot` klasöründe saklanır
- Resim yolları veritabanında tutulur


## Projeyi Çalıştırma

1. Repository’yi klonlayın:
   ```bash
   git clone <repository-url>
2. Projeyi Visual Studio ile açın
3. Veritabanını oluşturun:
	update-database
4. Uygulamayı çalıştırın:
	dotnet run
