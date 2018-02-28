using playground_20180220.ValidateAttributes;
using Ryan.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace playground_20180220.ViewModels.Home
{
    public class IndexViewModel
    {
        //[Required]
        //[Emailzzz(ErrorMessage = "Hello, You Got Email ZZZZZ Error !!!")]
        [NoIs("ryansung", ErrorMessage = "{0} NoNoNO")]
        public string Name { get; set; }

        [StringLength(6, ErrorMessage = "{0} too much!")]
        [NotEqualTo("Name", ErrorMessage = "{0}幹嘛一樣")]
        public string Description { get; set; }

        public int Number { get; set; }

        [Display(Name = "上課日期")]
        [DayRange(3, 10, ErrorMessage = "{0} 不在範圍哦!")]
        public DateTime Date { get; set; }
    }
}