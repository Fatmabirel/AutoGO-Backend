using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // Success Messages
        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarDeleted = "Araba başarıyla silindi.";
        public static string CarUpdated = "Araba başarıyla güncellendi.";
        public static string CarListed = "Arabalar başarıyla getirildi.";
        public static string CarFound = "Araba başarıyla getirildi.";
        public static string CarDetailsListed = "Araba detayları başarıyla getirildi."; 

        // Error Messages
        public static string CarAddFailed = "Araba eklenirken bir hata oluştu.";
        public static string CarDeleteFailed = "Araba silinirken bir hata oluştu.";
        public static string CarUpdateFailed = "Araba güncellenirken bir hata oluştu.";
        public static string CarNotFound = "Araba bulunamadı.";
        public static string CarDetailsNotFound = "Araba detayları bulunamadı.";

        // Validation Messages
        public static string InvalidCarPrice = "Araba günlük fiyatı 0'dan büyük olmalıdır.";
        public static string InvalidCarDescription = "Araba açıklaması en az 2 karakter uzunluğunda olmalıdır.";
        public static string InvalidCarDetails = "Geçersiz araba bilgileri.";

        // Brand Messages
        public static string BrandAdded = "Marka başarıyla eklendi.";
        public static string BrandDeleted = "Marka başarıyla silindi.";
        public static string BrandUpdated = "Marka başarıyla güncellendi.";
        public static string BrandListed = "Markalar başarıyla getirildi.";
        public static string BrandFound = "Marka başarıyla getirildi.";
        public static string BrandNotFound = "Marka bulunamadı.";
        public static string InvalidBrandName = "Marka adı en az 2 karakter uzunluğunda olmalıdır.";

        // Color Messages
        public static string ColorAdded = "Renk başarıyla eklendi.";
        public static string ColorDeleted = "Renk başarıyla silindi.";
        public static string ColorUpdated = "Renk başarıyla güncellendi.";
        public static string ColorListed = "Renkler başarıyla getirildi.";
        public static string ColorFound = "Renk başarıyla getirildi.";
        public static string ColorNotFound = "Renk bulunamadı.";

        // User Messages
        public static string UserAdded = "Kullanıcı başarıyla eklendi.";
        public static string UserDeleted = "Kullanıcı başarıyla silindi.";
        public static string UsersListed = "Kullanıcılar başarıyla getirildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi.";

        // Customer Messages
        public static string CustomerAdded = "Müşteri başarıyla eklendi.";
        public static string CustomerDeleted = "Müşteri başarıyla silindi.";
        public static string CustomersListed = "Müşteriler başarıyla getirildi.";
        public static string CustomerNotFound = "Müşteri bulunamadı.";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi.";

        // Rental Messages
        public static string RentalAdded = "Kiralama başarıyla eklendi.";
        public static string RentalDeleted = "Kiralama başarıyla silindi.";
        public static string RentalsListed = "Kiralamalar başarıyla getirildi.";
        public static string RentalNotFound = "Kiralama bulunamadı.";
        public static string RentalUpdated = "Kiralama başarıyla güncellendi.";
        public static string CarIsAlreadyRented = "Bu araba zaten kiralanmış.";


    }
}
