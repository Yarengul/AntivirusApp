# AntivirusApp
C# Antivirus App (C# Antivirüs Uygulaması)
Bu proje, C# ve Windows Forms kullanılarak geliştirilmiş, dosya ve klasörleri MD5 Hash (imza) tabanlı olarak tarayan temel bir güvenlik yazılımıdır.

Özellikler (Features)
Tekli Dosya Tarama (Single File Scan): Belirli bir dosyanın MD5 özetini çıkarır ve veritabanı ile karşılaştırır.

Klasör Tarama (Folder Scan): Seçilen bir klasör ve tüm alt klasörlerindeki dosyaları toplu halde tarar.

İlerleme Çubuğu (Progress Bar): Tarama işleminin ne kadarının tamamlandığını görsel olarak gösterir.

Tehdit Yönetimi (Threat Management):

Silme (Delete): Zararlı dosyayı sistemden kalıcı olarak kaldırır.

Karantina (Quarantine): Zararlı dosyayı izole bir klasöre taşıyarak etkisiz hale getirir.

Kullanılan Teknolojiler (Technologies Used)
Dil: C#

Platform: .NET / Windows Forms (WinForm)

Kütüphaneler:

System.Security.Cryptography (MD5 hesaplama için)

System.IO (Dosya ve klasör yönetimi için)

Nasıl Çalışır? (How It Works?)
MD5 Üretimi: Program taranan her dosyanın benzersiz bir parmak izini (Hash) oluşturur.

Karşılaştırma: Oluşturulan bu parmak izi, kodun içindeki virusSignatures (virüs imzaları) listesiyle karşılaştırılır.

Tespit: Eğer dosyanın özeti listedeki bir değerle eşleşirse, dosya "TEHLİKELİ" olarak işaretlenir.

Aksiyon: Kullanıcı bulunan tehdidi silebilir veya güvenli bir alana taşıyabilir.

Kurulum (Installation)
Bu projeyi Visual Studio ile açın.

Form1.cs dosyasındaki virusSignatures dizisine test etmek istediğiniz MD5 kodlarını ekleyin.

Projeyi Build (Derle) edin ve Start (Başlat) butonuna basın.

Uyarı (Disclaimer)
Bu uygulama eğitim amaçlı geliştirilmiş temel düzeyde bir projedir. Gerçek dünya tehditlerine karşı tam koruma sağlamaz. Profesyonel kullanım için ticari antivirüs yazılımları tercih edilmelidir.
