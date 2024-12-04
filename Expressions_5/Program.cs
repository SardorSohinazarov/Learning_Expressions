using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace CodeExecutionApp
{
    /// <summary>
    /// https://chatgpt.com/share/674fe0ec-1f7c-8005-8b3a-f89801e10e4f
    /// </summary>
    /// test input : return int.Parse(input) * int.Parse(input);

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Foydalanuvchi tomonidan kiritiladigan kodni kiriting (Calculate funksiyasi tanasini):");
            string userCode = Console.ReadLine();

            var testCases = new (string input, int expectedOutput)[]
            {
                ("5", 25),
                ("3", 9),
                ("0", 0),
                ("-2", 4)
            };

            Console.WriteLine("Kiritilgan kod test qilinmoqda...");
            bool allPassed = true;

            foreach (var testCase in testCases)
            {
                try
                {
                    var result = await ExecuteAndTest(userCode, testCase.input);
                    if (result == testCase.expectedOutput)
                    {
                        Console.WriteLine($"✅ Test Case Passed: Input = {testCase.input}, Expected = {testCase.expectedOutput}, Got = {result}");
                    }
                    else
                    {
                        Console.WriteLine($"❌ Test Case Failed: Input = {testCase.input}, Expected = {testCase.expectedOutput}, Got = {result}");
                        allPassed = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Test Case Error: Input = {testCase.input}, Exception = {ex.Message}");
                    allPassed = false;
                }
            }

            if (allPassed)
            {
                Console.WriteLine("🎉 Barcha test case'lar muvaffaqiyatli o'tdi!");
            }
            else
            {
                Console.WriteLine("⚠️ Ba'zi test case'lar muvaffaqiyatsiz bo'ldi.");
            }
        }

        public static async Task<int> ExecuteAndTest(string userCode, string input)
        {
            string fullCode = $@"
                using System;

                public static class Solution
                {{
                    public static int Calculate(string input)
                    {{
                        {userCode}
                    }}
                }}

                // Ushbu qism test uchun qo'shiladi
                return Solution.Calculate(""{input}"");
            ";

            var options = ScriptOptions.Default
                .AddReferences(AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location)))
                .AddImports("System");

            return await CSharpScript.EvaluateAsync<int>(fullCode, options);
        }
    }
}
