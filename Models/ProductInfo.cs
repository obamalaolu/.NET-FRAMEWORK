//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectTise.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public partial class ProductInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductInfo()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int productId { get; set; }
        public string Product_Name { get; set; }
        public string Product_Number { get; set; }
        public string Product_Description { get; set; }
        public double Product_Price { get; set; }
        public string Image { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
