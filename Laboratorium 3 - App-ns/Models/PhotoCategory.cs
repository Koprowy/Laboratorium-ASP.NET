using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App_ns.Models
{
    public enum PhotoCategory
    {
        [Display(Name = "Portret")]
        Portrait,

        [Display(Name = "Krajobraz")]
        Landscape,

        [Display(Name = "Miejski")]
        Urban,
    }
}