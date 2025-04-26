using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AutoBaseSystem.Models.RequestViewModel {
    public class RequestCreateViewModel {
        [Display(Name = "Дата прибуття")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Кількість пасажирів")]
        public int PassengersCount { get; set; }
        [Display(Name = "Клас авто")]
        public Guid CarCategoryId { get; set; }

        public List<SelectListItem> AvailableCategories { get; set; } = new List<SelectListItem>();
    }
}
