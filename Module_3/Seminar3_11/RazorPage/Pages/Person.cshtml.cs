using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage.Pages
{
    public class PersonModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Введите значения: ";
        }

        public void OnPost(double a, double b, double c)
        {
            var D = Math.Pow(b, 2) - 4 * a * c;
            switch (D)
            {
                case > 0:
                case 0:
                {
                    var x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    var x2 = (-b - Math.Sqrt(D)) / (2 * a);
                    Message = $"{x1} x2= {x2}";
                    break;
                }
                default:
                    Message = "Действительных корней нет";
                    break;
            }
        }
    }
}
