﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoneyCeeper
{
    public static class Advices
    {
        public static string[] KeyWords = new string[]
        { "Как обычно", "По привычке", "По нужде",
        "Случайно", "Не сдержался" , "Было нужно",
        "Проголодался", "Сходил в магазин"};


        public static string[] AdvicesList = new string[]
        {   
            "Как обычно, всё отлично! Однако ваше 'обычно' уже не обычно" +
            $"*\nУ вас более 5-ти совпадений по слову '{KeyWords[0]}' за неделю*.\n" +
            "Многие вещи кажутся нам обычными и очевидными. Но если поглядеть глубже, то " +
            "можно найти интересную информацию о них и о том, как они тратят ваши деньги.",

            "Судя по всему, у вас имеется какая-то вредная привычка."
            + $"*\nУ вас более 5-ти совпадений по слову '{KeyWords[1]}' за неделю*.\n" +
            "Вам стоит пересмотреть некоторые свои интересы и привычки, ведь они уносят ваши " +
            "заработанрные финансы.",

            "Мы все в чём-то нуждаемся. Но вы нуждаетесь больше, чем остальные."
             + $"*\nУ вас более 5-ти совпадений по слову '{KeyWords[2]}' за неделю*.\n" +
            "Возможно, эти нужды и не нужда вовсе. Вам стоит проанализировать ситуацию, может, не всё так " +
            "критично, как вам кажется.",

            "Случайности не случайны - Мастер Уг Вэй"
             + $"*\nУ вас более 5-ти совпадений по слову '{KeyWords[3]}' за неделю*.\n" +
            "Вы либо везучий, либо невезучий, либо человек случая. А может, есть влияние со стороны?" +
            "(тут нет намёка на параною). Посто подумайте о ваших случайностях.",

            "Не хотелось бы такое говорить, но вы себя не сдерживаете"
             + $"*\nУ вас более 5-ти совпадений по слову '{KeyWords[4]}' за неделю*.\n" +
            "Здесь можно пореккомендовать только одно: нужно стать дисциплинированние. Иначе " +
            "ваш кошелёк не сдержится и уйдёт от вас.",

            "А это точно было нужно?"
             + $"*\nУ вас более 5-ти совпадений по слову '{KeyWords[5]}' за неделю*.\n" +
            "Возможно, вы подумаете, что этот совет похож на предыдущий, однако природа этого явления " +
            "немного другая. Скорее всего, у вас не лучшие времена(как и у создателя программы) " +
            "так что в один момент обдумайте эту фразу, глядишь, придёт ответ.",

            "Похоже, вы слишком часто тратите деньги на еду. " +
            $"*\nУ вас более 5-ти совпадений по слову '{KeyWords[6]}' за неделю*.\n" +
            "Возможно, это связанно с зависимостью, или болезнью. " +
            "Тем не менее, вам следует посетить психолога и обговорить с ним эту проблему.",

            "Покупка еды, чтобы прожить до зарплаты - одно, но вы, " +
            "кажись, ходите в магазин за другими вещами."
             + $"*\nУ вас более 5-ти совпадений по слову '{KeyWords[7]}' за неделю*.\n" +
            "Может, вы шопоголик, а может, вы оптовый покупатель или малый предприниматель(тогда " +
            "зачем вы используете эту программу?). Но если вы ходите в магазин и тратите деньги не понимая " +
            "почему, то стоит сходить к психологу"
        };

    }
}
