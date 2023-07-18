namespace Заявки_на_доработку_ПО.Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Ticket
    {
        public int Id { get; set; }
        public int IdПО { get; set; }

        [Required(ErrorMessage = "Поле Название обязательно для заполнения.")]
        public string Название { get; set; }

        [Required(ErrorMessage = "Поле Email обязательно для заполнения.")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Описание обязательно для заполнения.")]
        public string Описание { get; set; }

        [Required(ErrorMessage = "Поле Дата окончания разработки обязательно для заполнения.")]
        [DataType(DataType.Date)]
        [DateNotPast(ErrorMessage = "Дата не может быть в прошлом.")]
        public DateTime ДатаОкончанияРазработки { get; set; }

        public Software? ПО { get; set; }
    }

    public class DateNotPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if ((DateTime)value > DateTime.Now)
            {
                return true;
            }

            return false;
        }
    }

}
