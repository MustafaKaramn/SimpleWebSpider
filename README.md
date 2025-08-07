# Web Spider

Bu proje, verilen bir başlangıç URL'sinden başlayarak sayfaları gezip içeriklerini yerel dosya sistemine kaydeden basit bir web spider'dır.

---

## 🚀 Kurulum ve Kullanım

### 1. ChromeDriver İndir
Chrome sürümünüze ve işletim sisteminize uygun `chromedriver.exe` dosyasını indirmeniz gerekmektedir.

🔗 [ChromeDriver İndir (Google Chrome for Testing)](https://googlechromelabs.github.io/chrome-for-testing/)

---

### 2. ChromeDriver'ı Doğru Klasöre Yerleştirin
İndirdiğiniz `chromedriver.exe` dosyasını aşağıdaki klasöre taşıyın:

```
\bin\Debug\net8.0\webdriver\
```

> Bu klasör yoksa manuel olarak oluşturabilirsiniz.

---

### 3. Başlangıç URL'sini Değiştirin
`Program.cs` dosyasında yer alan `startUrl` değişkenini, taramak istediğiniz siteyle değiştirin:

```csharp
string startUrl = "https://ornek-site.com";
```

---

### 4. Programı Çalıştırın
Uygulamayı çalıştırdığınızda, verilen sitedeki bağlantılar otomatik olarak gezilir ve her sayfanın içeriği yerel olarak kaydedilir.

---

### 5. Çıktıların Konumu
Tarama sonucunda içerikler şu klasöre kaydedilir:

```
\bin\Debug\net8.0\outputs\
```

Ve her site için içerikler şu yapıda saklanır:

```
outputs/
├── site1/
│   ├── sayfa1.txt
│   └── sayfa2.txt
├── site2/
│   ├── sayfa1.txt
│   └── sayfa2.txt
```

---

## 📌 Notlar

- `outputs/` ve `webdriver/` klasörleri sürüm kontrolünde yalnızca klasör olarak tutulur, içerikleri `.gitignore` ile dışlanmıştır.
- Tarama sırasında `Thread.Sleep(200)` gibi kısa bekleme süresi kullanılmıştır. Bu süre bazı sitelerde yeterli olmayabilir.

---

## 📄 Lisans
Bu proje MIT lisansı ile lisanslanmıştır. Detaylar için `LICENSE.txt` dosyasına bakabilirsiniz.
