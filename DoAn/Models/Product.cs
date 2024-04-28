    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    namespace DoAn.Models
    {
        public class Product
        {
            [Key]
            public long ProductID { get; set; }

            [Required(ErrorMessage = "Product name cannot be blank!")]
            [RegularExpression(@"^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ 0-9 ]*$"
            , ErrorMessage = "Cannot use special character")]
            [MinLength(10,ErrorMessage ="Product name cannot be less than 10 characters!")]
            public string ProductName { get; set; }

            [Required(ErrorMessage = "Price cannot be blank!")]
            [DisplayFormat(DataFormatString = "{0:N0}")]
            [Range(100000, 5000000)]
            public decimal Price { get; set; }
            [RegularExpression(@"^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ 0-9 ,]*$"
            , ErrorMessage = "Cannot use special character")]
            [Required(ErrorMessage = "Description cannot be blank!")]
            public string Description { get; set; }
            public string Status { get; set; }

            [Required]
            public Nullable<long> CategoryID { get; set; }

            [Required]
            public Nullable<long> BrandID { get; set; }
            public string Image {  get; set; }

            public virtual Brand Brand { get; set; }
            public virtual Category Category { get; set; }
        }
    }