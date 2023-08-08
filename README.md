# Hastane Randevu Sistemi

Bu projede, hastane randevu işlemlerini dijitalleştirmek ve kullanıcıların kolayca randevu almasını sağlamak amacıyla bir web uygulaması geliştirilmiştir.

## Proje Tanımı

Hastane Randevu Sistemi, hastaların internet üzerinden kolayca randevu almasını ve doktorlar ile polikliniklerin yönetimini sağlayan bir çevrimiçi platformdur. Sistem, kullanıcıların uygun doktor ve poliklinikleri seçerek randevu oluşturmasına olanak tanır.

## Kullanılan Teknolojiler

- Asp.Net Core 6 MVC (veya Asp.Net Core 7 MVC)
- C#
- Veritabanı: SQL Server / PostgreSQL / vb.
- Entity Framework Core ORM
- Bootstrap Tema
- HTML5, CSS3, JavaScript ve jQuery

## Özellikler

- Kullanıcı dostu arayüz ile kolayca randevu oluşturma
- Kullanıcı kaydı ve oturum açma
- Kullanıcı yetkilendirme ve güvenli giriş
- Çok dilli destek (Türkçe/İngilizce)
- Veri tabanındaki verileri sorgulamak için LINQ tabanlı API hizmeti

## Kurulum

1. Projeyi klonlayın: `git clone https://github.com/sizin-hesap/ProjeyiAdi.git`
2. Proje klasörüne gidin: `cd ProjeyiAdi`
3. `appsettings.json` dosyasında veritabanı bağlantı bilgilerinizi ayarlayın.
4. Veritabanını güncelleyin: `dotnet ef database update`

## Kullanım

1. Uygulamayı başlatın: `dotnet run`
2. Tarayıcınızda `http://localhost:5000` adresine gidin.
3. Ana sayfada, kullanıcı kaydı yapın veya oturum açın.
4. Randevu oluşturmak için uygun doktor ve polikliniği seçin.
5. Randevu tarih ve saatini belirleyin ve onaylayın.

## Notlar

- Admin girişi için kullanıcı adı: OgrenciNuramarasi@sakarya.edu.tr
- Admin şifresi: sau

## Katkılar

Her türlü katkıya açığız. Lütfen [CONTRIBUTING.md](CONTRIBUTING.md) dosyasını okuyun.

## Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır.
