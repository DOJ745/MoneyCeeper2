using MoneyCeeper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCeeper
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum CategoryEnum
    {
        [Description("Еда")]
        Food,

        [Description("Одежда")]
        Cloth,

        [Description("Подарки")]
        Prezents,

        [Description("Дети")]
        Kids,

        [Description("Забота о себе")]
        Care,

        [Description("Здоровье(спортзал)")]
        Heatlh,

        [Description("Кафе, рестораны")]
        Cafe,

        [Description("Образование")]
        Education,

        [Description("Развлечения(кино, игры)")]
        Entertainment,

        [Description("Транспорт")]
        Transport,

        [Description("Комунальные услуги")]
        Commission

        // Care - забота о себе
        // Entertainment - развлечения различного рода
        // Comission - комунальные услуги
    }
}
