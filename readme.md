# Kurye Takip Yazılımı [TR]
Restoran, Bölge, Kurye, Ödeme Yöntemi ve Teslimat süreleri kullanılarak sipariş kaydı yapıp kuryelerin performansının takibinin yapılabileceği kontrol yazılımı.

``` Kullanılan teknolojiler;
	- .Net Framework 4.7.2
	- Entity Framework
	- LINQ
```

``` Gerekli ön koşullar;
	- [.Net Framework 4.7.2] (https://support.microsoft.com/tr-tr/topic/microsoft-net-framework-4-7-2-windows-için-çevrimdışı-yükleyici-05a72734-2127-a15d-50cf-daf56d5faec2)
	- [SQL Express] (https://go.microsoft.com/fwlink/?linkid=866658)
	- [SSMS * isteğe bağlı] (https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
```

## Sekmeler
#### Kurye Takip
Ekrandaki her bir satır, bir sipariş olarak nitelendirilmektedir.
Sipariş içerisindekiler;
	- Id => siparişin özgün tanımlayıcı numarası,
	- Restoran => siparişin çıkış restoranı,
	- Dağıtım Bölgesi => ürünün teslimat bölgesi,
	- Ödeme Yöntemi => sipariş teslimatında yapılacak ödemenin yöntemi (Nakit, POS, Yemek kartı vs.),
	- Durum => siparişin durumu ("Alınıyor", "Yolda", "Tamamlandı"),
	- Ürün Alınma Süresi => kuryenin ürünü restorandan alma süresi, 
	- Kurye => ürünün teslimatını yapacak kurye,
	- Ürün Teslim Alındı => kurye ürünü restorandan aldığı zaman işaretlenecek checkbox,
	- Ürün Dağıtım Süresi => kuryenin ürünü aldıktan sonra alıcıya teslimatının süresi,
	- Teslim Edildi => kurye ürünü teslim ettiği zaman işaretlenecek checkbox.

* Siparişlerin listelendiği ekran "WinForms ~ DataGridView" objesidir.
* DataGridView içerisindeki satırları oluşturulurken "DataGridViewTextBoxCell, DataGridViewComboBoxCell ve DataGridViewCheckBoxCell"ler kullanılmıştır.
* Ayrıca her satırın kendisine ait 2 adet "StopWatch"ları vardır. (Ürün alınma süresi ve ürün dağıtım sürelerinin sayaçları)
* Restoran > Dağıtım Bölgesi > Ödeme yöntemi seçilmesi halinde "Ürün Alınma Süresi" sayacı başlar ve siparişin durumu "Alınıyor" olarak belirlenir.
* Kurye seçimi yapıldıktan sonra "Ürün Teslim Alındı" kutucuğunun tiklenmesi halinde "Ürün Dağıtım Süresi" sayacı başlar ve siparişin durumu "Yolda" olarak belirlenir.
* "Teslim Edildi" kutucuğunun tiklenmesiyle ilgili sipariş girilen bilgilerle "Tamamlandı" olarak belirlenir ve veritabanına kayıt işlemi gerçekleştirilir.
![](ScreenShots/ss1.png)

#### Raporlama
Geniş raporlama seçenekleri ile her sipariş kaydının aşağıdaki filtrelerdeki metrikleri ve sipariş kayıtları gösterilir;
	- Kurye [Metrikler: Seçilen kuryenin teslim ettiği sipariş sayısı, ortalama teslimat süresi]
	- Restoran [Metrikler: Seçilen restorandan çıkan toplam sipariş sayısı, restoranın ortalama hazırlama süresi]
	- Bölge [Metrikler: Seçilen bölgeye teslimatı yapılan toplam sipariş sayısı, ortalama hazırlama ve teslimat süreleri]
	- Ödeme Yöntemi [Metrikler: Seçilen ödeme yöntemiyle kayıtlı toplam sipariş sayısı] 
	- Tarih Aralığı [Metrikler: Seçilen tarih aralığındaki toplam sipariş sayısı]

* Raporlama sekmesinde metrikler hespalanırken siparişler "LINQ" objesi üzerinden sorgulanıp "DataTable"a dönüştürülerek "DataGridView"de gösterilir.
* Yukarıdaki belirtilen filtrelerle yapılan sorguların siparişlerinin tümü "DataGridView"da gösterilir (Örn: Kurye seçimi sonrası seçilen kuryenin siparişleri).
* Raporlama sekmesinde yapılan işlemlerin loglarını gösteren "TextBox" mevcuttur, veritabanı ve "LINQ" işlemleri esnasında oluşan olası hatalar da burada loglanır.
![](ScreenShots/ss2.png)

#### Kayıt
Siparişlerin oluşturulması için gerekli bilgilerin kayıt ve silme işlemlerinin yapıldığı sekme.
![](ScreenShots/ss3.png)

#### Ayar
_Bu sekme geliştirilme sürecindedir_

#### Loglar
Tüm yazılımın operasyonel loglarını tutan log ekranı. Karşılaşılan hatalar da bu ekranda gösterilir.
![](ScreenShots/ss5.png)

## Anlık Bilgi Ekranı
Anlık olarak sipariş ve kurye bilgilerinin gösterildiği labelları içeren "GroupBox".

Gösterilen bilgiler;
	- Hazırlanma aşamasındaki sipariş sayısı
	- Teslimat aşamasındaki sipariş sayısı
	- Oturumda tamamlanan sipariş sayısı (yazılım açıldığından itibaren sayar, kapatıldığı zaman sıfırlanır)
	- Toplam tamamlanan sipariş sayısı
	- Dağıtımda olan kuryeler
	- Tarih ve saat

* Bu alandaki bilgiler anlık olarak "Timer" aracılığıyla saniyelik güncellenir.

# Delivery Management System [EN]