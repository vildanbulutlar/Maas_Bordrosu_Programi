# 💼 Maaş Bordrosu Programı

Katmanlı mimariyle geliştirilmiş bir **.NET Console/Web uygulaması**.  
Bu uygulama, çalışan maaşlarını performans, prim, mesai gibi kriterlere göre hesaplayarak **JSON formatında bordrolar** üretir.  
Gelecekte web tabanlı arayüz ve veri saklama özellikleriyle genişletilebilir bir altyapıya sahiptir.

---

## 🚀 Özellikler

### ⚙️ Temel Özellikler
- Çalışan maaşlarını **otomatik hesaplar**  
- Çalışan bilgilerini **JSON dosyasında saklar**  
- Bordro hesaplama için **katmanlı mimari (Clean Architecture)** yapısı kullanır  
- **Performans, prim, fazla mesai** gibi dinamik maaş bileşenlerini destekler  
- Bordro verilerini **ZIP formatında dışa aktarabilir**

---

### 🧱 Katman Yapısı

| Katman | Açıklama |
|--------|-----------|
| **Domain** | Uygulamanın beyni — iş kuralları, entity tanımları |
| **Application** | Servisler, DTO’lar ve iş akış mantığı |
| **Infrastructure** | Veri erişimi, dosya okuma/yazma, JSON işlemleri |
| **UI (Console/Web)** | Kullanıcı etkileşimi, menü yapısı ve sonuçların gösterimi |

---

### 📊 Gelişmiş Özellikler
- ✅ **ValidationHelper:** E-posta, şifre, telefon gibi giriş kontrolleri  
- ⚠️ **Exception Handling:** Hataları özel mesajlarla yakalar ve yönetir  
- 🧩 **Soft Delete:** Çalışan verileri silinmez, “Inactive” durumuna çekilir  
- 🔁 **Dependency Injection:** Servis bağımlılıklarını yönetir  
- ⚙️ **Extensible:** Yeni maaş politikaları kolayca eklenebilir  

---

## 🛠️ Kurulum ve Çalıştırma
