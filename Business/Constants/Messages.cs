namespace Business.Constants
{
    public static class Messages
    {
        #region Sucess Messages Of Car Entity
        public static string CarAdded = "Araç ekleme işlemi başarılı.";
        public static string CarDeleted = "Araç silme işlemi başarılı.";
        public static string CarUpdated = "Araç başarıyla güncellendi";
        public static string CarDetailsGetted = "Araç bilgileri başarıyla listelendi";
        #endregion

        #region Error Messages Of Car Entity
        public static string CarNameIsValid = "Araç Bilgileri Geçersiz.";
        public static string ErrorOfCarAdded = "Araç ekleme işlemi sırasında bir hata oluştu";
        public static string ErrorOfCarDeleted = "Araç silme işlemi sırasında bir hata oluştu";
        public static string ErrorOfCarUpdated = "Araç güncelleme işlemi sırasında bir hata oluştu";
        public static string ErrorOfCarAddedByBrandCount = "Bir markadan en fazla 10 adet araç ekleyebilirsiniz.";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
        #endregion

        #region User Success Messages
        public static string UserRegistered = "Kullanıcı Kaydı Başarıyla Oluşturuldu";
        public static string UserLogined = "Oturum açma işlemi başarılı. Anasayfaya yönlendiriliyorsunuz...";
        public static string UserNotFound = "Kullanıcı bulunamadı...";
        public static string PasswordError = "Kullanıcı adı veya şifre yanlış";
        #endregion

        //public static string 
    }
}
