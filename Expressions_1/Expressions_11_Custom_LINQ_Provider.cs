using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expressions_11
{
    /// <summary>
    /// https://chatgpt.com/share/67483c51-19c8-8005-8536-905058abb108
    /// </summary>
    internal class Expressions_11_Custom_LINQ_Provider
    {
        //public static void Main()
        //{
        //    //Custom LINQ Providers: Batafsil Tushuntirish

        //        //LINQ(Language Integrated Query) — bu.NET uchun yuqori darajadagi so‘rovlar yozish texnologiyasi bo‘lib,
        //        //u turli xil ma’lumotlar manbalariga(masalan, ma’lumotlar bazalari, massivlar,
        //        //fayllar va boshqalar) so‘rovlar jo‘natishga imkon beradi.

        //        //Odatda, LINQ IQueryable yoki IEnumerable interfeyslari orqali ma'lumotlar manbalarini so‘raydi.
        //        //Ammo ba'zan mavjud LINQ provayderlaridan(masalan, Entity Framework yoki LINQ to Objects) foydalanib
        //        //bo‘lmaydigan, lekin ma'lumotlarga o‘xshash so‘rovlar bajarilishi kerak bo‘ladigan maxsus ma'lumot
        //        //manbalari bilan ishlashga to‘g‘ri keladi. Bunday holatda custom LINQ provider kerak bo‘ladi.



        //    //1.Custom LINQ Provider nima?
        //        //Custom LINQ Provider bu sizga o‘z ma'lumotlar manbangiz uchun LINQ’ni moslashtirishga
        //        //imkon beradigan texnologiya. Custom LINQ provider yaratish orqali siz LINQ so‘rovlarini
        //        //o‘zingizning ma'lumot manbangizga mos keladigan tarzda o‘zgartirishingiz mumkin.

        //    //Misol:
        //        //Ma'lumotlar manbasi: REST API yoki JSON fayl.
        //        //LINQ So‘rov: People.Where(p => p.Age > 30)
        //        //Ishlash printsipi: Ushbu so‘rovni REST API - ga GET / people ? age_gt = 30 tarzida jo‘natish.


        //    //2.Custom LINQ Provider qanday ishlaydi?
        //    //Custom LINQ provider ikkita asosiy qismdan iborat:
        //        //IQueryable<T> interfeysining implementatsiyasi.
        //        //Expression Tree’ni so‘rovga tarjima qiluvchi interpreter yoki executor.


        //    // 3. Asosiy Bosqichlar
        //        //1-bosqich: IQueryable va IQueryProvider ni Implementatsiya Qilish
        //        //IQueryable interfeysi LINQ so‘rovlarini so‘nggi ma'lumot manbaiga o‘tkazish uchun ishlatiladi.
        //        //Ushbu interfeys IQueryProvider bilan birga ishlaydi.
        //        //IQueryProvider esa so‘rovni qanday ishlashini belgilaydi.
        //}
    }
}
