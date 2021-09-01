using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime ="Sistem bakimda";
        public static string ProductListed = "Ürünler listelendi";

        public static string UnitPriceInvalid = "Birim fiyat geçersiz";
        public static string ProductCountOfCategoryError="Kategorideki ürün sayısı limitini aştınız.";
        public static string ProductNameAlreadyExist="Bu isimde başka bir ürün var.";
        public static string CategoryLimitExceded = "Kategori sayisi limiti doldu. ";
    }
}
