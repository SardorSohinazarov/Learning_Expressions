using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Expressions_10
{
    public class Expressions_10_Optimazing
    {
        //public static void Main()
        //{
        //    //Expression Trees ni Optimallashtirish va Ishlash Tezligini Oshirish
        //    //Expression Trees – bu murakkab amallarni dinamik ravishda yaratish
        //    //va bajarish imkonini beruvchi vosita.
        //    //Lekin bu jarayonni optimallashtirish orqali kodni tezroq va samaraliroq ishlatish mumkin.
        //    //Keling, bu boradagi texnikalarni batafsil ko‘rib chiqamiz.



        //    //Expression Trees orqali yaratilgan kod har doim ham optimal bo‘lmaydi.

        //    //Ba'zi hollarda, quyidagi muammolar paydo bo‘lishi mumkin:
        //    //Ortib qolgan oraliq amallar: Keraksiz qo‘shimcha amallar va qo‘shma amallar.
        //    //Qayta - qayta ishlovchi kodlar: Bir xil amal bir necha marta qayta ishlovchi konstruktsiyalar.
        //    //Kompilyatsiya vaqtida kechikish: Murakkab Expression Trees uzoqroq vaqt kompilyatsiya qilinishi mumkin.

        //    //Optimallashtirish orqali biz:
        //    //Kod tezligini oshirish.
        //    //Kompilyatsiya vaqtini qisqartirish.
        //    //Oraliq amallarni minimallashtirish orqali ish faoliyatini yaxshilashimiz mumkin.

        //    //Texnika                                   Afzallik
        //    //Constant Folding                          Kompilyatsiya vaqtini qisqartiradi
        //    //Keraksiz tugunlarni olib tashlash         Kod hajmini kamaytiradi
        //    //Inlining                                  Oraliq hisob - kitoblarni minimallashtiradi
        //    //ExpressionVisitor                         Murakkab Expression Trees'larni boshqarish



        //    //Expression Tree Visitor Pattern: Batafsil Tavsif

        //    //Expression Tree Visitor Pattern — bu Expression Trees ichidagi har bir tugunni travers qilish(ko‘rib chiqish),
        //    //o‘zgartirish va qayta yaratish uchun ishlatiladi.
        //    //Bu nafaqat Expression Tree’ni optimallashtirish uchun,
        //    //balki murakkab manipulyatsiyalar va transformatsiyalar uchun ham qo‘l keladi.

        //    //ExpressionVisitor — bu.NET kutubxonasidagi bazaviy klass bo‘lib,
        //    //u orqali biz har bir turdagi Expression tugunini boshqarishimiz mumkin.



        //    //Expression Tree Visitor Pattern: Batafsil Tavsif
        //    //Expression Tree Visitor Pattern — bu Expression Trees ichidagi har bir tugunni travers qilish(ko‘rib chiqish),
        //    //o‘zgartirish va qayta yaratish uchun ishlatiladi. Bu nafaqat Expression Tree’ni optimallashtirish uchun,
        //    //balki murakkab manipulyatsiyalar va transformatsiyalar uchun ham qo‘l keladi.

        //    //ExpressionVisitor — bu.NET kutubxonasidagi bazaviy klass bo‘lib,
        //    //u orqali biz har bir turdagi Expression tugunini boshqarishimiz mumkin.

        //    //1.Nima uchun ExpressionVisitor kerak?
        //    //ExpressionVisitor sizga murakkab Expression Trees bilan ishlashda quyidagi imkoniyatlarni beradi:

        //    //Expression Tree’ni o‘zgartirish: Masalan, ma'lum bir tugunni boshqa tugun bilan almashtirish.
        //    //Amallarni optimallashtirish: Qayta - qayta ishlatilayotgan yoki keraksiz tugunlarni olib tashlash.
        //    //Dinamik so‘rovlar yaratish: Foydalanuvchi kirita oladigan shartlar
        //    //va qidiruv mezonlariga asoslangan dinamik LINQ so‘rovlarini yaratish.
        //    //Kod yozishni avtomatlashtirish: Bir xil amallarni bir necha joyda qo‘llashni osonlashtirish.





        //    //2.ExpressionVisitor: Tuzilishi
        //    //ExpressionVisitor bu Abstract Class bo‘lib, har bir turdagi Expression uchun mos metodlarni ta’minlaydi:

        //    //Metod                                   Vazifasi
        //    //Visit(Expression)                       Har qanday umumiy Expressionni ko‘rib chiqadi va qayta ishlaydi.
        //    //VisitBinary(BinaryExpression)           Binary(ikki operandli) amallarni boshqaradi(+, -, *, / va h.k.).
        //    //VisitConstant(ConstantExpression)       Konstanta tugunlarini boshqaradi.
        //    //VisitParameter(ParameterExpression)     Parametr tugunlarini boshqaradi.
        //    //VisitLambda(LambdaExpression)           Lambda ifodalarni boshqaradi.



        //    //ExpressionVisitor yordamida:
        //    //Expression Trees ni o‘zgartirish va optimallashtirish imkoniyatiga ega bo‘lasiz.
        //    //Konstanta qiymatlarni oldindan hisoblash, parametrlarni almashtirish,
        //    //va dinamik so‘rovlar yaratish orqali murakkab amallarni boshqarishingiz mumkin.
        //}
    }
}
