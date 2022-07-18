using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab1.Models.ViewModel
{
    public class EquipmentSelectViewModel
    {
        public Equipment SelectedEquipment { get; set; }
        public List<SelectListItem> EquipmentSelectItems { get; set; }

        public EquipmentSelectViewModel(ICollection<Equipment> equipment)
        {
            EquipmentSelectItems = new List<SelectListItem>();
            foreach(Equipment e in equipment)
            {
                EquipmentSelectItems.Add(new SelectListItem(e.EquipmentName,e.Id.ToString()));
            }
        }
    }
}
