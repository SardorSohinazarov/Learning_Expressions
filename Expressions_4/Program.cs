using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace CodeExecutionApp
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Kiritiladigan C# kodni kiriting:");

            string inputCode = Console.ReadLine();

            try
            {
                // Kodni bajarish
                var result = await ExecuteCode(inputCode);
                Console.WriteLine($"Natija: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik: {ex.Message}");
            }
        }

        public static async Task<object> ExecuteCode(string code)
        {
            var options = ScriptOptions.Default
                .AddReferences(AppDomain.CurrentDomain.GetAssemblies()) // Barcha kutubxonalarni qo‘shish
                .AddImports("System", "System.Linq", "System.Collections.Generic"); // Kerakli namespace lar

            return await CSharpScript.EvaluateAsync(code, options);
        }
    }
}
