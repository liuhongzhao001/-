﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Question
    {

        public int question_id { get; set; }
        public int test_id { get; set; }
        [Required]
        [DisplayName("问题")]
        public string question_name { get; set; }
        [DisplayName("选项A")]
        public string question_chooseA { get; set; }
        [DisplayName("选项B")]
        public string question_chooseB { get; set; }
        [DisplayName("选项C")]
        public string question_chooseC { get; set; }
        [DisplayName("选项D")]
        public string question_chooseD { get; set; }
        public string question_answer { get; set; }
    }
}
