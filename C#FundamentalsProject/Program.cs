using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        // Ana program döngüsü
        bool continueProgram = true;
        while (continueProgram)
        {
            // Ana menüyü göster
            Console.Clear();
            Console.WriteLine("Ana Menü");
            Console.WriteLine("1 - Rastgele Sayı Bulma Oyunu");
            Console.WriteLine("2 - Hesap Makinesi");
            Console.WriteLine("3 - Ortalama Hesaplama");
            Console.WriteLine("4 - Çıkış");
            Console.Write("Lütfen bir seçenek girin (1-4): ");

            // Kullanıcı girişini al ve doğrula
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Lütfen geçerli bir sayı girin.");
                ContinueMessage();
                continue;
            }

            // Seçime göre ilgili fonksiyonu çağır
            switch (choice)
            {
                case 1:
                    RandomNumberGame();
                    break;
                case 2:
                    Calculator();
                    break;
                case 3:
                    AverageCalculation();
                    break;
                case 4:
                    Console.WriteLine("Programdan çıkılıyor...");
                    continueProgram = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim! Lütfen 1 ile 4 arasında bir sayı girin.");
                    break;
            }

            if (continueProgram)
            {
                ContinueMessage();
            }
        }
    }

    static void RandomNumberGame()
    {
        Console.Clear();
        Console.WriteLine("Rastgele Sayı Bulma Oyunu");

        // Rastgele sayı üret
        Random random = new Random();
        int randomNumber = random.Next(1, 101);

        int guessCount = 5;

        // Tahmin döngüsü
        for (int i = 0; i < guessCount; i++)
        {
            Console.WriteLine("1-100 arasında bir sayı tahmininde bulunun.");
            int guess = Convert.ToInt32(Console.ReadLine());

            if (guess == randomNumber)
            {
                Console.WriteLine("Tebrikler, doğru tahmin!");
                return;
            }
            else
            {
                // Yanlış tahmin durumunda ipucu ver
                Console.WriteLine("Yanlış tahmin, tekrar deneyin.");
                if (guess < randomNumber)
                {
                    Console.WriteLine("Daha yüksek bir sayı deneyin.");
                }
                else
                {
                    Console.WriteLine("Daha düşük bir sayı deneyin.");
                }

                Console.WriteLine($"Kalan tahmin hakkınız: {guessCount - (i + 1)}");
            }
        }

        // Tahmin hakkı bittiğinde doğru sayıyı göster
        Console.WriteLine($"Tahmin hakkınız bitti. Doğru sayı: {randomNumber}");
    }

    static void Calculator()
    {
        Console.Clear();
        Console.WriteLine("Hesap Makinesi");

        try
        {
            // Kullanıcıdan iki sayı al
            Console.Write("İlk sayıyı giriniz: ");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("İkinci sayıyı giriniz: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            // İşlem seçeneklerini göster
            Console.WriteLine("\nYapmak istediğiniz işlemi seçin:");
            Console.WriteLine("+ : Toplama");
            Console.WriteLine("- : Çıkarma");
            Console.WriteLine("* : Çarpma");
            Console.WriteLine("/ : Bölme");
            Console.Write("İşleminiz (+, -, *, /): ");

            string operation = Console.ReadLine();

            // Seçilen işleme göre hesaplama yap
            switch (operation)
            {
                case "+":
                    Console.WriteLine($"Toplam: {number1 + number2}");
                    break;
                case "-":
                    Console.WriteLine($"Fark: {number1 - number2}");
                    break;
                case "*":
                    Console.WriteLine($"Çarpım: {number1 * number2}");
                    break;
                case "/":
                    // Sıfıra bölme kontrolü
                    if (number2 == 0)
                    {
                        Console.WriteLine("Hata: Sıfıra bölme işlemi yapılamaz.");
                    }
                    else
                    {
                        Console.WriteLine($"Bölüm: {number1 / number2}");
                    }
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem seçildi.");
                    break;
            }
        }
        // Hata yakalama
        catch (FormatException)
        {
            Console.WriteLine("Hata: Lütfen geçerli bir sayı giriniz.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu: {ex.Message}");
        }
    }

    static void AverageCalculation()
    {
        Console.Clear();
        Console.WriteLine("Ders Notu Hesaplayıcı");

        // Üç ders notu al ve doğrula
        double grade1 = GetAndValidateGrade("Birinci ders notunu girin: ");
        if (grade1 == -1) return;

        double grade2 = GetAndValidateGrade("İkinci ders notunu girin: ");
        if (grade2 == -1) return;

        double grade3 = GetAndValidateGrade("Üçüncü ders notunu girin: ");
        if (grade3 == -1) return;

        // Ortalamayı hesapla
        double average = (grade1 + grade2 + grade3) / 3;

        // Sonuçları göster
        Console.WriteLine($"Not ortalamanız: {average:F2}");
        Console.WriteLine($"Harf notunuz: {DetermineLetterGrade(average)}");
    }

    // Not girişi ve doğrulama fonksiyonu
    static double GetAndValidateGrade(string message)
    {
        Console.Write(message);
        if (!double.TryParse(Console.ReadLine(), out double grade))
        {
            Console.WriteLine("Hata: Geçerli bir sayı girilmedi. Program sonlandırılıyor.");
            return -1;
        }
        if (grade < 0 || grade > 100)
        {
            Console.WriteLine("Hata: Not 0-100 aralığında olmalıdır. Program sonlandırılıyor.");
            return -1;
        }
        return grade;
    }

    // Harf notu belirleme fonksiyonu
    static string DetermineLetterGrade(double average)
    {
        if (average >= 90) return "AA";
        if (average >= 85) return "BA";
        if (average >= 80) return "BB";
        if (average >= 75) return "CB";
        if (average >= 70) return "CC";
        if (average >= 65) return "DC";
        if (average >= 60) return "DD";
        if (average >= 55) return "FD";
        return "FF";
    }

    // Ana menüye dönüş mesajı
    static void ContinueMessage()
    {
        Console.WriteLine("\nAna menüye dönmek için bir tuşa basın...");
        Console.ReadKey();
    }
}