//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Travel_Expense_Application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Travel_Expense_Application()
        {
            this.ApplyDetail = new HashSet<ApplyDetail>();
        }
    
        public int ApplyNumber { get; set; }
        public int EmployeeID { get; set; }
        public string Reason { get; set; }
        public System.DateTime ApplyDate { get; set; }
        public System.DateTime TravelStartTime { get; set; }
        public System.DateTime TravelEndTime { get; set; }
        public int CostCategory { get; set; }
        public decimal Amont { get; set; }
        public int CheckStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplyDetail> ApplyDetail { get; set; }
        public virtual CheckStatus CheckStatus1 { get; set; }
        public virtual Cost Cost { get; set; }
        public virtual User User { get; set; }
    }
}
