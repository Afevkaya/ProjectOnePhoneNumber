using System;
using System.Collections.Generic;

namespace ProjectOne // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Phone> phones = new List<Phone>(){
                new Phone{
                    Name = "Ahmet",
                    Surname = "Evkaya",
                    PhoneNumber = "5541856651"
                },
                new Phone{
                    Name = "Feride",
                    Surname = "Evkaya",
                    PhoneNumber = "5541856652"
                },
                new Phone{
                    Name = "Betül",
                    Surname = "Evkaya",
                    PhoneNumber = "5541856653"
                },
                new Phone{
                    Name = "Muhammet",
                    Surname = "Evkaya",
                    PhoneNumber = "5541856654"
                },
                new Phone{
                    Name = "Nursel",
                    Surname = "Danaci",
                    PhoneNumber = "5541856655"
                },
            };

            Anamenu(phones);
            
            
            
        }

        //Anamenu
        static void Anamenu(List<Phone> phones){
            Console.WriteLine("Lütfen yapmak istediğiniz işlemiz seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncellemek");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapma");

            int secim = Convert.ToInt32(Console.ReadLine());
            
            if (secim == 1)
            {
                Add(phones);
            }
            else if (secim == 2)
            {
                Remove(phones);
            }
            else if (secim == 3)
            {
                Update(phones);
            }
            else if (secim == 4)
            {
                ListPhoneNumber(phones);
            }
            else if (secim == 5)
            {
                SearchPhoneNumber(phones);
            }
            else
            {
                Console.WriteLine("Yanlis Secim Yaptınız");
            }
        }


        //Ekleme
        static void Add(List<Phone> phones){
            Phone phone = new Phone(); 

            Console.WriteLine("Lütfen ismi giriniz: ");
            phone.Name = Convert.ToString(Console.ReadLine());
            
            Console.WriteLine("Luften soyismi giriniz: ");
            phone.Surname = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Lutfen telefon numarasını giriniz: ");
            phone.PhoneNumber = Convert.ToString(Console.ReadLine());

            phones.Add(phone);
            ListPhoneNumber(phones);
        }


        //Silme
        static void Remove(List<Phone> phones){

            Phone phone;
            int secim;
            string secim2;
            
            phone = Search(phones);

            if(phone == null){
                
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lutfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için: (1)");
                Console.WriteLine("* Yeniden denemek için: (2)");
                secim = Convert.ToInt32(Console.ReadLine());
                if(secim == 1){
                    Anamenu(phones);
                }
                else if(secim == 2)
                {
                    Remove(phones);
                }
                else
                {
                    Console.WriteLine("Yanlış seçim yaptınız...");
                    Anamenu(phones);
                }
            }
            else
            {
                Console.WriteLine(phone.Name + " isimli kişiyi silinmek üzere, onaylıyor musunuz ?(y/n)");
                secim2 = Console.ReadLine();
                if (secim2 == "y" || secim2 == "Y")
                {
                    phones.Remove(phone);
                }
            }
            ListPhoneNumber(phones);
            
            
        }


        //Güncelleme
        static void Update(List<Phone> phones){

            Phone phone;
            phone = Search(phones);
            
            if(phone == null){
                Console.WriteLine("Araduğınız kişi bulunamadı");
                Anamenu(phones);
            }
            else
            {
                Console.WriteLine("Lutfen adı giriniz: ");
                phone.Name = Console.ReadLine();
                Console.WriteLine("Lutfen soyadı giriniz: ");
                phone.Surname = Console.ReadLine();
                Console.WriteLine("Lutfen telefon numarasını giriniz: ");
                phone.PhoneNumber = Console.ReadLine();

                ListPhoneNumber(phones);
            
            }


            

            ListPhoneNumber(phones);
        }

        //Listeleme
        static void ListPhoneNumber(List<Phone> phones){
            foreach (var phone in phones)
            {
                Console.WriteLine(phone.Name+ " "+phone.Surname+" "+phone.PhoneNumber + "\n");
            }
            Anamenu(phones);
        }

        //Rehberde arama
        static void SearchPhoneNumber(List<Phone> phones){
            
            Phone phone = Search(phones);
            if(phone == null){
                Console.WriteLine("Aradığınız kişi bulunmamaktadır.");
                Anamenu(phones);
            }
            else
            {
                Console.WriteLine("Aradığınız kişinin adı: "+phone.Name+ " soyadı: "+phone.Surname+" telefon numarası: "+phone.PhoneNumber);
            }
            


        }


        //Search
        static Phone Search(List<Phone> phones){
            Console.WriteLine("Lufen arama yapmak istediğiniz kişinin adını ya da soyadını giriniz: ");
            string nameSurname = Console.ReadLine();
            Phone phone = null;

            for (int i = 0; i < phones.Count; i++)
            {
                if (nameSurname == phones[i].Name || nameSurname == phones[i].Surname)
                {
                    phone = phones[i];
                }
            }

            return phone;
        }
        
    }
}