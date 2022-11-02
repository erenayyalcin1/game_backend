using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mermi
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Mermi
    {
        public string MermiTuru;
        public float MermiCapi;
        public float MermiBoyu;
        public float MermiHasari;
        public Mermi(string mermituru, float mermicapi, float mermiboyu, float mermihasari)   // tanimlayici 
        {
           
            MermiTuru = mermituru;
            MermiCapi = mermicapi;
            MermiBoyu = mermiboyu;
            MermiHasari = mermihasari;
        }
    }
    class Silah
    {
        /// <summary>
        /// Silahin adini temsil eder 
        /// </summary>
        public SilahTuru SilahinAdi;
        
        /// <summary>
        /// Silahın sahip olabileceği maksimum mermi sayısı
        /// </summary>
        public byte SarjorKapasitesi;       

        /// <summary>
        /// Silahta anlık olarak var olan mermiler
        /// </summary>
        public Mermi[] Mermiler;
        /// <summary>
        /// Silahin ucretini temsil eder--- float tipinin sonuna $ isareti konulabilir
        /// </summary>
        public int SilahUcreti;      
        public Silah(SilahTuru silahinadi, byte sarjorkapatitesi, Mermi[] mermiler,int silahucreti)
        {
            SilahinAdi = silahinadi;
            SarjorKapasitesi = sarjorkapatitesi;
            
            if (mermiler != null && mermiler.Length < 30 && mermiler.Length > 0)
            {
                Mermiler = mermiler;
            }
            SilahUcreti = silahucreti;
        }
       

        /// <summary>
        /// Ateş eder. 
        /// </summary>
        /// <returns>Eğer mermi yoksa false, mermi varsa ve ateşlendiyse true döndürür.</returns>
        public bool AtesEt() 
        {
            
            if (Mermiler.Length==0)   //mermilerin sayisini kontrol ediyoruz 
            {      
                //silahin mermisi sifir olursa silahi atesleyemez 
                Console.WriteLine("silah ateslenemez");
                return false;
            }
            Console.WriteLine("silah atesleneblir ");//silahin sarjoru 0 dan buyuk olmasi SARTT    
            Mermiler = Mermiler.Where((deger, index) => index != 0).ToArray();//mermiler dizisinin ilk elemanini sildi cunku eleman ates ediyor.
            return true;
            //bu fonskiyon silah ateslendiyse true ateslenmediyse false cevirecek   sistemi hizlandirmak icin ilk basa true fonksiyonu konulabilir.
        }
    }
    class Bomba
    {
        /// <summary>
        /// Bombalarin alacagi ad
        /// </summary>
        public BombaAdi BombaAdi;
        /// <summary>
        /// Bombanin karsi oyuncuya yada kendisine verecegi hasar
        /// </summary>
        public byte BombaHasari;
        public Bomba(BombaAdi bomba_adi, byte bomba_hasari)
        {
            BombaAdi = bomba_adi;
            BombaHasari = bomba_hasari;
        }

    }
    class Envanter  
    {
        /// <summary>
        /// Silah sinifindan bir liste olusturdum 
        /// </summary>
        public List<Silah> SilahListesi;
        /// <summary>
        /// Bomba sinifindan bir liste olusturdum 
        /// </summary>
        public List<Bomba> BombaListesi;
         
     public Envanter(List<Silah> silah_listesi,List<Bomba> bomba_listesi )
        {
            if (silah_listesi!=null && silah_listesi.Count<3 && silah_listesi.Count>=0) //silah listesini kontrol ediyorum 
            {
                SilahListesi = silah_listesi;
            }
            if (bomba_listesi!=null && bomba_listesi.Count<4 && bomba_listesi.Count>=0)//bomba listesini kontrol ettim 
            {
                BombaListesi = bomba_listesi;
            }
             


        }
        public bool SilahEkle(Silah eklenecekSilah)   
        {
            //SilahListesi.Count = 0 dan + sonsuz 
            if (SilahListesi.Count > 1)  //1 den fazla silah varsa calisir
            {

                return false;
            }
            //Silah sayisi 2 den kucukse bu satira gelir.
            //SilahListesi.Count = 1 veya 0 
                SilahListesi.Add(eklenecekSilah);
                return true;
        }
        public bool BombaEkle(Bomba eklenecekBomba)
        {
           
            if (BombaListesi.Count > 2)
            {
                return false;
            }         
                BombaListesi.Add(eklenecekBomba);         
            return true;
        }
        public bool SilahSil(Silah silinecekSilah)
        {           
            if (SilahListesi.Count == 0 )
            {
                return false;
            }
            
                SilahListesi.Remove(silinecekSilah);        
            return true;
        }
        public bool BombaSil(Bomba silinecekBomba)
        {
            if (BombaListesi.Count==0)
            {
                return false;
            }
                BombaListesi.Remove(silinecekBomba);
            return true;
        }
    }
    /// <summary>
    /// Karakterin ic ozelliklerini icerir
    /// </summary>
    class Karakter
    {
        /// <summary>
        /// karakterin adini temsil eder 
        /// </summary>
        public string KarakterAdi;
        /// <summary>
        /// Karakterin sahip oldugu parayi temsil eder.Dolar cinsinden ifade edilebilir $
        /// </summary>
        public int SahipOlduguPara;
        /// <summary>
        /// Karakterin envanterini temsil eder 
        /// </summary>
        public Envanter KarakterEnvanteri;
        /// <summary>
        /// Karakterin canini temsil eder 
        /// </summary>
        public int KarakterinCani;
        

        public Karakter(string karakter_adi,int sahip_oldugu_para,Envanter karakter_envanteri,int karakterin_cani)
        {
            KarakterAdi = karakter_adi;
            SahipOlduguPara = sahip_oldugu_para;
            KarakterEnvanteri = karakter_envanteri;
            KarakterinCani = karakterin_cani;

        }
        /// <summary>
        /// <paramref name="SatinAlinacakSilah"/> 'i envantere eklemeye calisir.Eger eklerse hesapdan bakiyeyi duser.
        /// </summary>
        public void SilahSatinAl(Silah SatinAlinacakSilah)
        {
            //Sahip oldugu para Silah ucretine yatiyor mu kontrol edilecek
            //Silah ucreti buyukse sahip oldugu paradan silahi alamazsin.
            if (SatinAlinacakSilah.SilahUcreti > SahipOlduguPara)
            {
                //Silahi alamaz.
                Console.WriteLine("silahi alamazsin");
                return;
            }
            //sahip oldugum para silah ucretinden buyuk ve esitse silahi alirim ve envanterde yer varsa  
            //TRUE dondururuse parayi hesapdan dusecek ||||||||||     FALSE dondururse hic bir sey yapmayacak.
            if (KarakterEnvanteri.SilahEkle(SatinAlinacakSilah)) //envanterde yer varsa silahi ekleyecek ve true dondurecek.Eger ekleyemezse false dondurur.
            {
                //silah eklendi ve alt satirda parayi dusecegim.
                SahipOlduguPara = SahipOlduguPara - SatinAlinacakSilah.SilahUcreti;//Bakiyeden dusuyorum. 
                Console.WriteLine("Silah alindi.");
            }
            else
            {
                Console.WriteLine("Paran yetersiz.Birazcik daha yaratik oldur.");
            }
        }
    }
    public enum SilahTuru
    {
            Ak47,
            M4A4,
            Phantom,
            Vandal
    }
    public enum BombaAdi
    {
        Flas_bombasi,   
        El_bombasi,
        Sis_bombasi,
        Molotof
    }
}
