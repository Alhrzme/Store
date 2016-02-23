using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Item
    {
        public int ItemID
        {
            get;
            set;
        }

        [Required(ErrorMessage ="Введите название товара")]
        public string Name
        {
            get;
            set;
        }

        [RegularExpression(@"[0-9,.]+", ErrorMessage = "Цена товара может состоять только из цифр и разделителя")]
        [Required(ErrorMessage = "Введите цену товара")]
        public decimal Price
        {
            get;
            set;
        }

        [RegularExpression("[a-zа-яА-ЯA-Z][а-яА-Яa-zA-Z0-9-_. ]{2,30}$", ErrorMessage = "Некорректная категория товара")]
        [Required(ErrorMessage = "Введите категорию товара")]
        public string Category
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Введите описание товара")]
        public string Description
        {
            get;
            set;
        }

        [RegularExpression(@"[0-9,.]+", ErrorMessage = "Вес товара может состоять только из цифр и разделителя")]
        [Required(ErrorMessage = "Введите вес товара")]
        public decimal Weight
        {
            get;
            set;
        }
        
        public byte[] Image
        {
            get;
            set;
        }
    }
}