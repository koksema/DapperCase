# DapperCase

DapperCase, **ASP.NET Core MVC** ve **Dapper** kullanılarak geliştirilmiş bir satış analiz ve raporlama uygulamasıdır.  
Uygulama, SQL Server üzerindeki `dbo.SalesImport` tablosundan verileri okuyarak hem bir **dashboard** ekranı hem de **sayfalı satış listesi** sunar.

## Proje Amacı

Bu proje, klasik ORM yerine **Dapper** kullanarak daha hafif ve performans odaklı bir veri erişim yapısı kurmayı amaçlar.  
Dashboard ekranında temel satış metrikleri, en iyi müşteri ve siparişler, ayrıca grafiksel özetler gösterilir.  
Sales ekranında ise satış kayıtları sayfalı biçimde listelenir.

## Kullanılan Teknolojiler

- ASP.NET Core MVC
- .NET 9
- Dapper
- Microsoft SQL Server
- Microsoft.Data.SqlClient
- Razor Views
- HTML / CSS / JavaScript

## Özellikler

### Dashboard
- Toplam satış tutarı
- Toplam kâr
- Toplam sipariş sayısı
- Toplam müşteri sayısı
- Ortalama sepet tutarı
- En yüksek ciroya sahip müşteri
- En yüksek revenue üreten sipariş
- En yüksek ciroya sahip müşteriler grafiği
- Kâr dağılımı grafiği
- Revenue / Profit karşılaştırma grafiği
- Top 5 müşteri listesi
- Top 5 sipariş listesi

### Sales Listesi
- Sayfalı veri listeleme
- Sipariş tarihi bazlı sıralama
- Sipariş, müşteri, adet, revenue ve profit görüntüleme
- Önceki / Sonraki sayfa geçişleri

## Proje Yapısı

```text
DapperCase
├── Context
│   └── DapperContext.cs
├── Controllers
│   ├── DashboardController.cs
│   └── SalesController.cs
├── Dtos
│   ├── DashboardDto.cs
│   └── SalesPageDto.cs
├── Services
│   ├── IDashboardService.cs
│   ├── DashboardService.cs
│   ├── ISalesService.cs
│   └── SalesService.cs
├── Views
│   ├── Dashboard
│   └── Sales
├── wwwroot
├── Program.cs
└── appsettings.json
